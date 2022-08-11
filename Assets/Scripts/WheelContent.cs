namespace CardGame
{
    using System;
    using UnityEngine;
    using Sirenix.OdinInspector;
    using DG.Tweening;

    [CreateAssetMenu(fileName = "wheel_content", menuName = "CardGame/WheelContent")]
    public class WheelContent : ScriptableObject
    {
        [InfoBox("Don't try to resize array", InfoMessageType.Warning, nameof(_isArraySizeWrong))]
        public WheelContentData[] Slices = new WheelContentData[GameValues.WheelSliceCount];

        bool _isArraySizeWrong = false;

        void OnValidate()
        {
            if (Slices.Length != GameValues.WheelSliceCount)
            {
                _isArraySizeWrong = true;
                Array.Resize(ref Slices, GameValues.WheelSliceCount);
            }
            else
            {
                _isArraySizeWrong = false;
            }
        }
    }
}

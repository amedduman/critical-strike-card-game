namespace CardGame
{
    using System;
    using UnityEngine;
    using Sirenix.OdinInspector;
    using DG.Tweening;

    [CreateAssetMenu(fileName = "wheel_content", menuName = "CardGame/WheelContent")]
    public class WheelContent : ScriptableObject
    {
        public WheelContentData[] Slices = new WheelContentData[GameValues.WheelSliceCount];

        void OnValidate()
        {
            if (Slices.Length != GameValues.WheelSliceCount)
            {
                Array.Resize(ref Slices, GameValues.WheelSliceCount);
            }
        }
    }
}

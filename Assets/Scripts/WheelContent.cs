namespace CardGame
{
    using System;
    using UnityEngine;
    using UnityEngine.UI;
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

            for(int i = 0; i < Slices.Length; i++)  
            {
                if(Slices[i].Drop == null) return;
                Sprite dropSprite = Slices[i].Drop.GetComponent<Image>().sprite;
                if(dropSprite == null) return;
                if(dropSprite == GameValues.DeathSprite)
                {
                    Slices[i].IsDeath = true;
                }
                else
                {
                    Slices[i].IsDeath = false;
                }
            }
        }
    }
}

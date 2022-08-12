namespace CardGame
{
    using System;
    using UnityEngine;

    [CreateAssetMenu(fileName = "wheel_content", menuName = "CardGame/WheelContent")]
    public class WheelContent : ScriptableObject
    {
        [SerializeField] GameValues _gameValues;
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

                if(Slices[i].Drop.name == _gameValues.DeathDrop.name)   
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

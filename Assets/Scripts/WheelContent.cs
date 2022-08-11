namespace CardGame
{
    using System.Collections.Generic;
    using UnityEngine;
    
    [CreateAssetMenu(fileName = "WheelContent", menuName = "CardGame/WheelContent")]
    public class WheelContent : ScriptableObject
    {
        [SerializeField] GameObject[] _drops;
        [SerializeField] GameObject _drop;
        [SerializeField] int _dropCount = 1;
        [SerializeField] [Range(0, 1)] float _dropRate = 0.125f;
    }
}

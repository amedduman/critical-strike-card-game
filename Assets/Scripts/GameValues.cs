using UnityEngine;
using Sirenix.OdinInspector;

[CreateAssetMenu(fileName = "game_values", menuName = "CardGame/GameValues")]
public class GameValues : ScriptableObject
{
    public static int WheelSliceCount {get; private set;} = 8;
    public static Sprite DeathSprite {get; private set;}

    [ReadOnly] [SerializeField] int _wheelSliceCount = 8;
    [SerializeField] Sprite _deathSprite;

    void OnValidate()
    {
        WheelSliceCount = _wheelSliceCount;
        DeathSprite = _deathSprite;
    }
    
}

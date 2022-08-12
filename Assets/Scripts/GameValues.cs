using UnityEngine;
using Sirenix.OdinInspector;

[CreateAssetMenu(fileName = "game_values", menuName = "CardGame/GameValues")]
public class GameValues : ScriptableObject
{
    public static int WheelSliceCount {get; private set;} = 8;
    [field: SerializeField] public GameObject DeathDrop {get; private set;}
}

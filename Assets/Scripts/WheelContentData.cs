namespace CardGame
{
    using System.Linq;
    using System.Collections;
    using System;
    using UnityEngine;
    using UnityEngine.UI;
    using Sirenix.OdinInspector;

    [System.Serializable]
    public class WheelContentData
    {
#if UNITY_EDITOR
        [ValueDropdown(nameof(GetAllDropPrefabs), IsUniqueList = true)]
#endif
        public GameObject Drop;
        [Range(0, 25)] public int DropCount = 1;
        [Range(0, 1)] public float DropRate = 1;
        [ReadOnly][SerializeField] public bool IsDeath;

#if UNITY_EDITOR
        private static IEnumerable GetAllDropPrefabs()
        {
            var root = "Assets/Game/Prefabs/Drops/";

            return UnityEditor.AssetDatabase.GetAllAssetPaths()
                .Where(x => x.StartsWith(root))
                .Select(x => x.Substring(root.Length))
                .Select(x => new ValueDropdownItem(x, UnityEditor.AssetDatabase.LoadAssetAtPath<UnityEngine.Object>(root + x)));
        }
#endif
    }

}
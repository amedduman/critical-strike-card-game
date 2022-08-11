namespace CardGame
{
    using System.Linq;
    using System.Collections;
    using System;
    using UnityEngine;
    using Sirenix.OdinInspector;

    [System.Serializable]
    public class WheelContentData
    {
        [ValueDropdown(nameof(GetAllDropPrefabs), IsUniqueList = true)]
        public GameObject Drop;
        [SerializeField] int _dropCount = 1;
        [SerializeField][Range(0, 1)] float _dropRate = 0.125f;

        private static IEnumerable GetAllDropPrefabs()
        {
            var root = "Assets/Game/Prefabs/Drops/";

            return UnityEditor.AssetDatabase.GetAllAssetPaths()
                .Where(x => x.StartsWith(root))
                .Select(x => x.Substring(root.Length))
                .Select(x => new ValueDropdownItem(x, UnityEditor.AssetDatabase.LoadAssetAtPath<UnityEngine.Object>(root + x)));
        }
    }

}
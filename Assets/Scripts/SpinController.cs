namespace CardGame
{
    using UnityEngine;
    using UnityEngine.UI;

    public class SpinController : MonoBehaviour
    {
        [SerializeField] Button _spinButton;
        [SerializeField] SpinEntity _spinEntity;

        void OnValidate()
        {
            if(_spinButton == null)
            {
                Debug.LogWarning($"spin button field is required", gameObject);
                return;
            }
            _spinButton.onClick.RemoveAllListeners();
            _spinButton.onClick.AddListener(SpinButtonAction);

            if(_spinEntity == null)
            {
                Debug.LogWarning($"spin entity field is required", gameObject);
            }
        }

        void OnDisable()
        {
            _spinButton.onClick.RemoveAllListeners();
        }

        void SpinButtonAction()
        {
            _spinEntity.Spin();
        }
    }

}
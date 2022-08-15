namespace CardGame
{
    using UnityEngine;
    using UnityEngine.UI;
    using UnityEngine.SceneManagement;

    public class SpinController : MonoBehaviour
    {
        [SerializeField] Button _spinButton;
        [SerializeField] Button _playAgainButton;
        [SerializeField] WheelEntity _wheel;

        void OnValidate()
        {
            if(_spinButton == null)
            {
                Debug.LogWarning($"spin button field is required", gameObject);
            }
            else
            {
                _spinButton.onClick.RemoveAllListeners();
                _spinButton.onClick.AddListener(SpinButtonAction);
            }

            if(_playAgainButton == null)
            {
                Debug.LogWarning($"play again button field is required", gameObject);
            }
            else
            {
                _playAgainButton.onClick.RemoveAllListeners();
                _playAgainButton.onClick.AddListener(PlayAgainButtonAction);
            }
           

            if(_wheel == null)
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
            _wheel.Spin();
        }

        void PlayAgainButtonAction()
        {
            SceneManager.LoadScene(0);
        }
    }

}
namespace CardGame
{
    using System;
    using UnityEngine;
    using UnityEngine.UI;
    using TMPro;
    using DG.Tweening;

    public class WheelEntity : MonoBehaviour
    {
        [SerializeField] GameObject _gameOverPanel;
        [SerializeField] WheelContent[] _contents;
        [SerializeField] GameObject[] _sliceSpots = new GameObject[GameValues.WheelSliceCount];
        [SerializeField] float _rotSpeed = 450;
        int _degree;
        int _contentIndex; 
        bool _isSpinning;

        void Start()
        {
            GenerateWheelContent();
        }

        void GenerateWheelContent()
        {
            WheelContent content = _contents[_contentIndex];
            for (int i = 0; i < content.Slices.Length; i++)
            {
                Image sliceImage = _sliceSpots[i].GetComponentInChildren<Image>();
                TextMeshProUGUI sliceCountText = _sliceSpots[i].GetComponentInChildren<TextMeshProUGUI>();

                Image contentSliceImage = content.Slices[i].Drop.gameObject.GetComponent<Image>();

                sliceImage.transform.localScale = content.Slices[i].Drop.gameObject.transform.localScale;
                sliceImage.sprite = contentSliceImage.sprite;
                sliceImage.rectTransform.sizeDelta = new Vector2(contentSliceImage.sprite.rect.width, contentSliceImage.sprite.rect.height);

                sliceCountText.text = $"x{content.Slices[i].DropCount.ToString()}";
            }
        }

        public void Spin()
        {
            if(_isSpinning) return;
            _isSpinning = true;
            _degree = 360 / GameValues.WheelSliceCount;
            int fullRotAmount = UnityEngine.Random.Range(3, 5);
            int randomSliceIndex = GetIndex();
            int rotDegree = _degree * randomSliceIndex; 
            
            Debug.Log($"{_contents[_contentIndex].Slices[randomSliceIndex].Drop.gameObject.GetComponent<Image>().sprite}");

            transform.DORotate(new Vector3(0, 0, rotDegree - 360 * fullRotAmount), _rotSpeed, RotateMode.LocalAxisAdd).SetSpeedBased()
            .OnComplete( ()=> {SpinResult(randomSliceIndex);});
        }

        void SpinResult(int sliceIndex)
        {
            if(_contents[_contentIndex].Slices[sliceIndex].IsDeath)
            {
                DOVirtual.DelayedCall(1, ()=> _gameOverPanel.SetActive(true));
            }
            DOVirtual.DelayedCall(1, ResetWheel);
        }

        void ResetWheel()
        {
            _contentIndex++;
            if(_contentIndex >= _contents.Length)
            {
                _contentIndex = 0;
            }
            transform.rotation = Quaternion.Euler(0, 0, 0);
            GenerateWheelContent();
            _isSpinning = false;
        }

        int GetIndex()
        {
            float total = 0;
            WheelContent content = _contents[_contentIndex];

            for (int i = 0; i < content.Slices.Length; i++)
            {
                total += content.Slices[i].DropRate;
            }

            float randomPoint = UnityEngine.Random.value * total;

            for (int j = 0; j < content.Slices.Length; j++)
            {
                if (randomPoint < content.Slices[j].DropRate)
                {
                    return j;
                }
                else
                {
                    randomPoint -= content.Slices[j].DropRate;
                }
            }

            return content.Slices.Length - 1;
        }

        void OnValidate()
        {
            if (_sliceSpots.Length != GameValues.WheelSliceCount)
            {
                Array.Resize(ref _sliceSpots, GameValues.WheelSliceCount);
            }
        }
    }
}
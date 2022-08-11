namespace CardGame
{
    using System;
    using UnityEngine;
    using UnityEngine.UI;
    using DG.Tweening;

    public class WheelEntity : MonoBehaviour
    {
        [SerializeField] WheelContent _content;
        [SerializeField] Image[] _sliceSpots = new Image[GameValues.WheelSliceCount];
        [SerializeField] float _rotSpeed = 450;
        int _degree;

        void Start()
        {
            GenerateWheelContent();
        }

        void GenerateWheelContent()
        {
            for (int i = 0; i < _content.Slices.Length; i++)
            {
                Image slice = _sliceSpots[i];
                slice.transform.localScale = _content.Slices[i].Drop.gameObject.transform.localScale;
                Image contentSlice = _content.Slices[i].Drop.gameObject.GetComponent<Image>();
                slice.sprite = contentSlice.sprite;
                slice.rectTransform.sizeDelta = new Vector2(contentSlice.sprite.rect.width, contentSlice.sprite.rect.height);
            }
        }

        public void Spin()
        {
            _degree = 360 / GameValues.WheelSliceCount;
            int fullRotAmount = UnityEngine.Random.Range(1, 5);
            // int randomSliceIndex = UnityEngine.Random.Range(1, GameValues.WheelSliceCount);
            int randomSliceIndex = GetIndex();
            int rotDegree = _degree * randomSliceIndex; 

            Debug.Log($"{randomSliceIndex}");
            Debug.Log($"{_content.Slices[randomSliceIndex].Drop.gameObject.GetComponent<Image>().sprite}");

            // transform.DORotate(new Vector3(0, 0, -1 * ((360 * fullRotAmount) + rotDegree)), _rotSpeed, RotateMode.LocalAxisAdd).SetSpeedBased();
            transform.DORotate(new Vector3(0, 0, rotDegree), _rotSpeed, RotateMode.LocalAxisAdd).SetSpeedBased().OnComplete(ResetWheel);
        }

        void ResetWheel()
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }

        int GetIndex()
        {
            float total = 0;

            for (int i = 0; i < _content.Slices.Length; i++)
            {
                total += _content.Slices[i].DropRate;
            }

            float randomPoint = UnityEngine.Random.value * total;

            for (int j = 0; j < _content.Slices.Length; j++)
            {
                if (randomPoint < _content.Slices[j].DropRate)
                {
                    return j;
                }
                else
                {
                    randomPoint -= _content.Slices[j].DropRate;
                }
            }

            return _content.Slices.Length - 1;
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
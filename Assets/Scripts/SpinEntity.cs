namespace CardGame
{
    using UnityEngine;
    using DG.Tweening;

    public class SpinEntity : MonoBehaviour
    {
        [SerializeField] float _rotSpeed = 450;
        const int _sliceCount = 8;
        int _degree;

        public void Spin()
        {
            _degree = 360 / _sliceCount;
            int fullRotAmount = Random.Range(1, 5);
            int rotDegree = _degree * Random.Range(1, _sliceCount);

            transform.DORotate(new Vector3(0, 0, -1 * ((360 * fullRotAmount) + rotDegree)), _rotSpeed, RotateMode.LocalAxisAdd).SetSpeedBased();
        }
    }
}
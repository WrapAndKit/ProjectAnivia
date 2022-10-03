using UnityEngine;

namespace Assets.Logic.Environment.Parallax {
    /// <summary>
    /// Parallax effect based on Main camera distance
    /// </summary>
    public sealed class ParallaxObject : MonoBehaviour {

        #region Data

        private Camera _camera;

        private Vector3 _lastCameraPos;

        private Vector3 _Travel => _camera.transform.position - _lastCameraPos;

        private float _DistanceToSubject => transform.position.z - GameInfo.CameraTarget.transform.position.z;

        private float _ClippingPlane => (_camera.transform.position.z + (_DistanceToSubject > 0 ? _camera.farClipPlane : _camera.nearClipPlane));

        private float _ParallaxFactor => Mathf.Abs(_DistanceToSubject) / _ClippingPlane;


        #endregion


        void Start() {
            _camera = Camera.main;
            _lastCameraPos = _camera.transform.position;
        }

        void OnEnable() {
            _lastCameraPos = Camera.main.transform.position;
        }

        void Update() {
            transform.position += _Travel * _ParallaxFactor;
            _lastCameraPos = _camera.transform.position;
        }
    }
}
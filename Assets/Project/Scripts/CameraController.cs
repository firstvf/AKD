using UnityEngine;

namespace Assets.Project.Scripts
{
    public class CameraController : MonoBehaviour
    {
        [SerializeField] private float _sensivity = 2f;
        [SerializeField] private float _maxYAngle = 75f;

        public float RotationX { get; private set; }

        private void Update()
        {
            MouseInput();
        }

        private void MouseInput()
        {
            var mouseX = Input.GetAxis("Mouse X");
            var mouseY = Input.GetAxis("Mouse Y");

            transform.parent.Rotate(_sensivity * mouseX * Vector3.up);

            RotationX -= mouseY * _sensivity;
            RotationX = Mathf.Clamp(RotationX, -_maxYAngle, _maxYAngle);
            transform.localRotation = Quaternion.Euler(RotationX, 0f, 0f);
        }
    }
}
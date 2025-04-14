using UnityEngine;

namespace Lesson7
{
    public class CameraController : MonoBehaviour
    {
        [SerializeField] private Transform _pitchAnchor;
        [SerializeField] private Transform _yawAnchor;
        [SerializeField] private float _sensitivity = 100f;

        private float _pitch = 20f;
        private float _yaw = 0f;

        private void Start()
        {
            // Прячем и блокируем курсор
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;

            // Сохраняем изначальный поворот
            _yaw = _yawAnchor.localEulerAngles.y;
        }

        private void LateUpdate()
        {
            // Получаем ввод мыши напрямую
            float mouseX = Input.GetAxis("Mouse X");
            float mouseY = Input.GetAxis("Mouse Y");

            _pitch -= mouseY * _sensitivity * Time.deltaTime;
            _yaw += mouseX * _sensitivity * Time.deltaTime;

            _pitch = Mathf.Clamp(_pitch, -80f, 80f);

            _pitchAnchor.localRotation = Quaternion.Euler(_pitch, 0f, 0f);
            _yawAnchor.localRotation = Quaternion.Euler(0f, _yaw, 0f);
        }

        public void SetYawAnchor(Transform yawAnchor)
        {
            _yawAnchor = yawAnchor;
            _yaw = _yawAnchor.localEulerAngles.y;
        }
    }
}

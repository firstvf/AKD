using System;
using UnityEngine;

namespace Assets.Project.Scripts
{
    public class PlayerInput : MonoBehaviour
    {
        [SerializeField] private float _movementSpeed = 4f;
        private CharacterController _characterController;

        private void Awake()
        {
            _characterController = GetComponent<CharacterController>();
        }

        private void Start()
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }

        private void Update()
        {
            MovementInput();
        }

        private void MovementInput()
        {
            var horizontal = Input.GetAxis("Horizontal");
            var vertical = Input.GetAxis("Vertical");

            var moveDirection = transform.forward * vertical + transform.right * horizontal;

            moveDirection.y -= 9.81f * Time.deltaTime;  

            _characterController.Move(_movementSpeed * Time.deltaTime * moveDirection);
        }
    }
}
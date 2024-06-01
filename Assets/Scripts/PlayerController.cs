using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

namespace HackedDesign
{
    [RequireComponent(typeof(ShipController))]
    public class PlayerController : MonoBehaviour
    {
        [Header("GameObjects")]
        [SerializeField] private PlayerInput playerInput;
        [SerializeField] private Camera mainCamera;
        [SerializeField] private ShipController ship;

        private InputAction moveAction;
        private InputAction lookAction;
        private InputAction strafeAction;

        void Awake()
        {
            if (playerInput == null)
            {
                playerInput = GetComponent<PlayerInput>();
            }

            moveAction = playerInput.actions["Move"];
            lookAction = playerInput.actions["Look"];
            strafeAction = playerInput.actions["Strafe"];
        }

        void Start()
        {
            Reset();
        }

        public void Reset()
        {

        }

        public void UpdateBehaviour()
        {
            ship.UpdateRotation(moveAction.ReadValue<Vector2>().x);
        }

        public void FixedUpdateBehaviour()
        {
            ship.UpdateMovement(moveAction.ReadValue<Vector2>().y, strafeAction.ReadValue<float>());
        }
    }
}
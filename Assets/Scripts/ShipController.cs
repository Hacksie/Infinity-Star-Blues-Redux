using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

namespace HackedDesign
{
    public class ShipController : MonoBehaviour
    {
        [Header("GameObjects")]
        [SerializeField] private Rigidbody rb;
        [SerializeField] private float rotationSpeed = 180;
        [SerializeField] private float forwardThrustMultiplier = 2;
        [SerializeField] private float strafeThrustMultiplier = 1;

        private void Awake()
        {
            if (rb == null)
            {
                rb = GetComponent<Rigidbody>();
            }
            rb.maxLinearVelocity = 10;
        }

        public void UpdateMovement(float thrust, float strafe)
        {
            UpdateThrust(thrust, strafe);

        }

        private void UpdateThrust(float thrust, float strafe)
        {
            rb.AddForce(transform.forward * forwardThrustMultiplier * Mathf.Clamp01(thrust));
            rb.AddForce(transform.right * strafeThrustMultiplier * strafe);

        }

        public void UpdateRotation(float turn)
        {
            var rotationAngle = transform.rotation.eulerAngles.y + (turn * rotationSpeed * Time.deltaTime);
            transform.rotation = Quaternion.AngleAxis(rotationAngle, Vector3.up);
        }

        public void Stop()
        {
            rb.linearVelocity = Vector3.zero;
        }

    }
}
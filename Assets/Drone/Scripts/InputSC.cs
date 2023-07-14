using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Drone
{
    public class InputSC : MonoBehaviour
    {
        private Vector2 move;
        private float yaw;
        private float throttle;

        public Vector2 Move { get => move; }
        public float Yaw { get => yaw; }
        public float Throttle { get => throttle; }

        void Update()
        {
            
        }
        private void OnMove(InputValue value)
        {
            move = value.Get<Vector2>();
        }
        private void OnYaw(InputValue value)
        {
            yaw = value.Get<float>();
        }
        private void OnThrottle(InputValue value)
        {
            throttle = value.Get<float>();
        }
    }
}
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace Drone
{
    public class Controller : RigidbodySC
    {
        [SerializeField] float pitchMaxMin = 30f;
        [SerializeField] float rollMaxMin = 30f;
        [SerializeField] float yawPower = 4f;
        [SerializeField] float lerpSpeed = 2f;
        InputSC input;
        List<EngineInterface> engines = new List<EngineInterface>();
        float yaw;
        float finalPitch;
        float finalRoll;
        float finalYaw;
        void Start()
        {
            input = GetComponent<InputSC>();
            engines = GetComponentsInChildren<EngineInterface>().ToList<EngineInterface>();
        }
        protected override void HandlePhysics()
        {
            HandleEngines();
            HandleControls();
        }

        protected virtual void HandleEngines()
        {
            //rb.AddForce(Vector3.up * (rb.mass * Physics.gravity.magnitude));
            foreach(EngineInterface engine in engines){
                engine.UpdateEngine(rb, input);
            }
        }
        protected virtual void HandleControls()
        {
            float pitch = input.Move.y * pitchMaxMin;
            float roll = -input.Move.x * rollMaxMin;
            yaw += input.Yaw * yawPower;

            finalPitch = Mathf.Lerp(finalPitch, pitch, Time.deltaTime * lerpSpeed);
            finalRoll = Mathf.Lerp(finalRoll, roll, Time.deltaTime * lerpSpeed);
            finalYaw = Mathf.Lerp(finalYaw, yaw, Time.deltaTime * lerpSpeed);

            Quaternion rotation = Quaternion.Euler(finalPitch, finalYaw , finalRoll);
            rb.MoveRotation(rotation);
        }
    }
}
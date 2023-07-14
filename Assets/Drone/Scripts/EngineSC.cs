using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Drone 
{
    public class EngineSC : MonoBehaviour, EngineInterface
    {
        [SerializeField] float maxPower = 4f;
        [SerializeField] Transform propeller;
        [SerializeField] float spinSpeed = 100f;
        void EngineInterface.StartEngine()
        {
            throw new System.NotImplementedException();
        }

        void EngineInterface.UpdateEngine(Rigidbody rb, InputSC input)
        {
            Vector3 engineForce = Vector3.zero;
            engineForce = transform.up * ((rb.mass * Physics.gravity.magnitude) + (input.Throttle * maxPower)) / 4f;
            rb.AddForce(engineForce, ForceMode.Force);
            SpinPropeller();
        }
        void SpinPropeller()
        {
            if(!propeller){ return; }
            propeller.Rotate(Vector3.up, spinSpeed);
        }
    }
}
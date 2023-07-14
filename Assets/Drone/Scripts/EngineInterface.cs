using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Drone
{
    public interface EngineInterface
    {
        void StartEngine();
        void UpdateEngine(Rigidbody rb, InputSC input);
    }
}
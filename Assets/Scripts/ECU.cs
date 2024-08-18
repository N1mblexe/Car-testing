using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

namespace CarCore
{
    public class ECU : MonoBehaviour
    {
        private const float centreOfGravityOffset = -1f;

        private class ECUData
        {
            private float maxRPM;
            private float maxSpeed;

            private float steeringRange;
            private float steeringSpeed;
            private float steeringRangeAtMaxSpeed;

            ECUData(float maxRPM, float maxSpeed, float steeringRange, float steeringSpeed, float steeringRangeAtMaxSpeed)
            {
                this.maxRPM = maxRPM;
                this.maxSpeed = maxSpeed;
                this.steeringRange = steeringRange;
                this.steeringSpeed = steeringSpeed;
                this.steeringRangeAtMaxSpeed = steeringRangeAtMaxSpeed;
            }
        }
        [SerializeField] ECUData ECUdata;
        ECU(ECUData ECUData)
        {
            this.ECUdata = ECUData;
        }

        //Initiliaze parts
        private Engine engine;
        private WheelControl[] wheels;
        private Gearbox gearbox;
        
        private Rigidbody rb;

        private void InitParts()
        {
            rb = GetComponent<Rigidbody>();

            rb.centerOfMass += Vector3.up * centreOfGravityOffset;

            engine = GetComponent<Engine>();
            wheels = GetComponentsInChildren<WheelControl>();
            gearbox = GetComponent<Gearbox>();
        }

    } 
}

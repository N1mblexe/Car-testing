using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Xml.Serialization;
using UnityEngine;

namespace CarCore
{
    public class ECU : MonoBehaviour
    {
        private const float centreOfGravityOffset = -1f;

        /// <summary>
        /// Stores the data of Electronic Control Unit (ECU).
        /// </summary>
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
        ECU(ECUData ECUData)
        {
            this.ECUdata = ECUData;
        }

        [SerializeField] ECUData ECUdata;

        //Initiliaze parts
        private Engine engine;
        private WheelControl[] wheels;
        private Gearbox gearbox;
        
        private Rigidbody rb;

        #region Parts
        private void InitParts()
        {
            rb = GetComponent<Rigidbody>();

            rb.centerOfMass += Vector3.up * centreOfGravityOffset;

            engine = GetComponent<Engine>();
            wheels = GetComponentsInChildren<WheelControl>();
            gearbox = GetComponent<Gearbox>();

            if (!CheckParts())
                Debug.Log("Failed to initiliaze parts");
        }

        private bool CheckParts()
        {
            return engine != null && 
                wheels != null && 
                gearbox != null &&
                rb != null &&
                ECUdata != null;
        }

        #endregion

        #region ENGINE

        private void PowerEngine()
        {
             if(!CheckParts())
            {
                Debug.Log("Failed to initilaze parts!!");
                return;
            }

            if (engine.isEngineRunning())
                engine.StopEngine();
            else
                engine.StartEngine();
        }

        #endregion


        #region STEERING

        #endregion


        #region GEARBOX

        #endregion

    }
}

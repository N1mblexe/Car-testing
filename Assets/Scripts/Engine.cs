using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Rendering;

namespace CarCore
{
    public class Engine : MonoBehaviour
    {
        private const int idleRPM = 900;

        private class EngineData
        {
            public string name;
            public string description;

            public bool running;

            public int horsePower;
            public int rpm { get => running ? rpm : -1; set => rpm = value; }

            public EngineData(string name, string description, int rpm)
            {
                this.name = name;
                this.description = description;
                this.rpm = rpm;

                this.running = false;
            }
        }

        [SerializeField] private EngineData engineData;
        
        Engine(EngineData engineData)
        {
            this.engineData = engineData;
        }

        public bool isEngineRunning()
        { 
            return engineData.running; 
        }

        public void StartEngine()
        {
            engineData.running = true;

            engineData.rpm = idleRPM;
        }

        public void StopEngine()
        {
            engineData.running = false;
            engineData.rpm = -1;
        }
    }
}
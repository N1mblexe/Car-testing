using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Engine : MonoBehaviour
{
    class EngineData
    {
        public string name;
        public string description;

        public bool running;

        public int horsePower;
        public int rpm { get => running ? rpm : -1; set => rpm = value; }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RpmTestManager : MonoBehaviour
{
    [Range(1, 1000)] public float horsePower;
    [Range(1000, 10000)] public float rpm;

    [Range(0, 5)] public int currentGear;
    public float[] gearRatios;
    public float finalDriveAxleRatio;

    public int wheelAmount = 2;

    [Range(0f, 1f)] public float gasPedalInput;

    //BU DEĞER TEKERLERİN SÜRTÜNME DURUMUNA GÖRE GELECEK
    public float rpmSensitivity = 1000f;

    public bool shiftUp;
    public bool shiftDown;

    private float previousRpm;

    void Start()
    {
        InitializeGearRatios();
        finalDriveAxleRatio = 4.31f;
        previousRpm = rpm;
    }

    void Update()
    {
        UpdateRpm();
        Debug.Log($"RPM: {rpm}");
        Debug.Log($"Torque: {CalculateTorque()}");
    }

    void InitializeGearRatios()
    {
        gearRatios = new float[6];
        gearRatios[0] = -3.25f; // Revers (geri vites)
        gearRatios[1] = 3.17f;
        gearRatios[2] = 1.90f;
        gearRatios[3] = 1.31f;
        gearRatios[4] = 0.89f;
        gearRatios[5] = 0.73f;
    }

    void UpdateRpm()
    {
        if (gasPedalInput > 0)
        {
            rpm += gasPedalInput * rpmSensitivity * Time.deltaTime;
        }
        else
        {
            rpm -= rpmSensitivity * Time.deltaTime;
        }

        rpm = Mathf.Clamp(rpm, 1000, 10000);
    }

    public void ShiftGearUp()
    {
        if (currentGear < gearRatios.Length - 1)
        {
            float tempTorque = CalculateTorque();
            currentGear++;
            rpm = CalculateRpmFromTorque(tempTorque);
            previousRpm = rpm;
        }
    }

    public void ShiftGearDown()
    {
        if (currentGear > 0)
        {
            float tempTorque = CalculateTorque();
            currentGear--;
            rpm = CalculateRpmFromTorque(tempTorque);
            previousRpm = rpm;
        }
    }

    float CalculateEngineTorque()
    {
        return (5252 * horsePower / rpm);
    }

    float CalculateRpmFromTorque(float torque)
    {
        return (5252 * horsePower * gearRatios[currentGear] * finalDriveAxleRatio) / (torque * wheelAmount);
    }

    float CalculateTorque()
    {
        return (CalculateEngineTorque() * gearRatios[currentGear] * finalDriveAxleRatio) / wheelAmount;
    }
}

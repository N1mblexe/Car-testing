using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(RpmTestManager))]
public class RpmTestManagerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        RpmTestManager rpmTestManager = (RpmTestManager)target;

        // Normal inspektör GUI'yi çiz
        DrawDefaultInspector();

        // Vites arttırma butonu
        if (GUILayout.Button("Shift Up"))
        {
            rpmTestManager.ShiftGearUp();
        }

        // Vites düşürme butonu
        if (GUILayout.Button("Shift Down"))
        {
            rpmTestManager.ShiftGearDown();
        }
    }
}

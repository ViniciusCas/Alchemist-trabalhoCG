using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
[CustomEditor(typeof(WFCHandler))]
public class WFCInspector : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        WFCHandler myScript = (WFCHandler)target;
        if (GUILayout.Button("Create tilemap"))
        {
            myScript.CreateWFC();
            myScript.CreateTilemap();
        }
        if (GUILayout.Button("Save tilemap"))
        {
            myScript.SaveTilemap();
        }

    }
}

using UnityEngine;
#if UNITY_EDITOR
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
    }
}
#endif
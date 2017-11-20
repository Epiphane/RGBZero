using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(TrackCreatorScript))]
public class TrackCreatorEditor : Editor {
    public override void OnInspectorGUI() {
        DrawDefaultInspector();

        TrackCreatorScript path = (TrackCreatorScript)target;
        if (GUILayout.Button("Build Track")) {
            path.CreateTrack();
        }
    }
}
using System;
using UnityEditor;
using UnityEngine;

[InitializeOnLoad] // This attribute ensures that the code runs on startup
public class DrawFolderInSceneView : Editor
{
    static DrawFolderInSceneView()
    {
        SceneView.duringSceneGui += OnSceneGUI;
    }

    private static void OnSceneGUI(SceneView sceneView)
    {
        Handles.BeginGUI();

        GUIStyle style = new GUIStyle();
        style.normal.textColor = Color.white;
        style.fontSize = 12;

        // Define position and size of the text
        Rect rect = new Rect(5, sceneView.camera.pixelHeight - 15, sceneView.camera.pixelWidth-5, 20);

        // Draw the text
        string fullPath = Application.dataPath;
        string assetsPath = System.IO.Path.GetDirectoryName(fullPath);
        string projectPath = System.IO.Path.GetDirectoryName(assetsPath);

        Console.WriteLine(projectPath);
        GUI.Label(rect, projectPath, style);

        Handles.EndGUI();
    }
}
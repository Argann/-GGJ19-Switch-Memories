using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(Database))]
public class DatabaseEditor : Editor
{
    Database database;
    
    void OnEnable()
    {
        database = target as Database;
    }

    public override void OnInspectorGUI()
    {
        GUILayout.Space(20);

        if (GUILayout.Button("Rescan Folders", GUILayout.Height(60)))
        {
            database.characters = Extensions.GetAllInstances<Character>().ToList();
            database.unlockActions = Extensions.GetAllInstances<UnlockAction>().ToList();
            database.pictures = Extensions.GetAllInstances<Picture>().ToList();
        }

        GUILayout.Space(20);

        DrawDefaultInspector();
    }
}

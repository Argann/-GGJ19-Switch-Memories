using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public static class Extensions
{
    public static void Move<T>(this List<T> list, int oldIndex, int newIndex)
    {
        T obj = list[oldIndex];

        list.RemoveAt(oldIndex);

        if (newIndex > oldIndex) newIndex--;

        list.Insert(newIndex, obj);
    }

#if UNITY_EDITOR
    public static T[] GetAllInstances < T > () where T: ScriptableObject {
		string[] guids = AssetDatabase.FindAssets("t:" + typeof (T).Name);
		T[] a = new T[guids.Length];
		for (int i = 0; i < guids.Length; i++)
		{
			string path = AssetDatabase.GUIDToAssetPath(guids[i]);
			a[i] = AssetDatabase.LoadAssetAtPath < T > (path);
		}

		return a;
	}
#endif
}

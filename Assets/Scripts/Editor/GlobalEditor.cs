using UnityEditor;
using UnityEngine;
using MyEditor;
[CustomEditor(typeof(GlobalInfo))]
public class GlobalEditor : Editor
{
	public override void OnInspectorGUI()
	{
		if (GUILayout.Button("Open Global Config"))
			GlobalEditorWindow.Init();

	}
}
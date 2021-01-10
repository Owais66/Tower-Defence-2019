using UnityEditor;
using UnityEngine;
using MyEditor;
using MyDefinations;
[CustomEditor(typeof(CharInfo))]
public class CharecterEditor : Editor
{
	public override void OnInspectorGUI()
	{
		if (GUILayout.Button("Open Charecter Config"))
			GlobalEditorWindow.Init();

	}
}
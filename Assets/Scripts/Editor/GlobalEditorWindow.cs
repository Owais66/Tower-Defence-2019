using UnityEditor;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using MyDefinations;

namespace MyEditor
{
    public class GlobalEditorWindow : EditorWindow
    {
        public static GlobalEditorWindow globalEditorWindow;
        private GlobalInfo globalInfo;

        [MenuItem("Window/MyEditor/Global Editor")]
        public static void Init()
        {
            globalEditorWindow = EditorWindow.GetWindow<GlobalEditorWindow>(false, "Global", true);
            globalEditorWindow.Show();
            globalEditorWindow.Populate();
        }

        void Populate()
        {
            this.titleContent = new GUIContent("Global", (Texture)Resources.Load("Icons/Global"));


        }

        UnityEngine.Object _GInfo;

        #region foldout bools
        bool CharecterFold = false;
        bool StageFold = false;
        #endregion
        public void OnGUI()
        {
            if (globalInfo == null)
            {
                GUILayout.BeginHorizontal("GroupBox");
                GUILayout.Label("Select a Global Configuration file\nor create a new one.", "CN EntryInfo");
                GUILayout.EndHorizontal();
                EditorGUILayout.Space();

                _GInfo = EditorGUILayout.ObjectField(_GInfo, typeof(GlobalInfo), false);
                if (GUILayout.Button("Open"))
                {
                    globalInfo = (GlobalInfo)_GInfo;
                }

                return;
          }
            #region BasicInfo

            #endregion

            #region CharecterInfo
            CharecterFold = EditorGUILayout.Foldout(CharecterFold, "Charecters");
            if (CharecterFold)
            {
                if (globalInfo.characterInfos == null) globalInfo.characterInfos = new List<CharInfo>();
                for (int i = 0; i < globalInfo.characterInfos.Count; i++)
                {
                    if (globalInfo.characterInfos[i] != null){
                        EditorGUILayout.LabelField("Name:", globalInfo.characterInfos[i].Name);
                        globalInfo.characterInfos[i] = (CharInfo)EditorGUILayout.ObjectField(globalInfo.characterInfos[i], typeof(CharInfo), false);
                    }
                    else
                    {
                        globalInfo.characterInfos.RemoveAt(i);
                    }
                }
                ListButtons<CharInfo>(ref globalInfo.characterInfos, new CharInfo());
            }
            #endregion


            #region StageInfo
            StageFold = EditorGUILayout.Foldout(StageFold, "Stage Options");
            if (StageFold)
            {
                foreach (var stage in globalInfo.stageInfos)
                {

                }
            } 
            #endregion
        }


        #region Quick Gui Methods
        void ListButtons<T>(ref List<T> list, T EmptyObject)
            where T : Object
        {
            EditorGUILayout.BeginHorizontal();
            if (GUILayout.Button("+"))
            {
                list.Add(EmptyObject);
            }
            if (GUILayout.Button("-"))
            {
                list.RemoveAt(list.Count-1);
            }

            EditorGUILayout.EndHorizontal();
        }
        #endregion
    }
}
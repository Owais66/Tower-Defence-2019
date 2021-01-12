using UnityEditor;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using MyDefinations;
using Assets.Scripts;
using System;

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
        bool PlayerInfoFold = false;
        bool EnemyInfoFold = false;
        bool CharecterFold = false;
        bool StageFold = false;
        #endregion
        public void OnGUI()
        {
            EditorGUILayout.BeginHorizontal();
                _GInfo = EditorGUILayout.ObjectField(_GInfo, typeof(GlobalInfo), false);
                if (GUILayout.Button("Open"))
                {
                    globalInfo = (GlobalInfo)_GInfo;
                }
            EditorGUILayout.EndHorizontal();
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

            #region PlayerInfo EnemyInfo
            PlayerInfo PlayerBaseEditor(PlayerInfo _playerInfo)
            {
                _playerInfo.towersInfo.KingHealth = FloatField("King Health", _playerInfo.towersInfo.KingHealth);
                _playerInfo.towersInfo.Archer1Health = FloatField("Archer1 Health", _playerInfo.towersInfo.Archer1Health);
                _playerInfo.towersInfo.Archer2Health = FloatField("Archer2 Health", _playerInfo.towersInfo.Archer2Health);

                return _playerInfo;
            }

            PlayerInfoFold = EditorGUILayout.Foldout(PlayerInfoFold, "Player Info");
            if (PlayerInfoFold)
            {
                if (globalInfo.Player1 == null) globalInfo.Player1 = new PlayerInfo();

                if (globalInfo.Player1 == null) globalInfo.Player1 = new PlayerInfo();
                globalInfo.Player1 = PlayerBaseEditor(globalInfo.Player1);
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

            //Save Button
            if (GUILayout.Button("Save"))
            {
                EditorUtility.SetDirty(this);
                AssetDatabase.SaveAssets();
            }
        }


        #region Quick Gui Methods
        void ListButtons<T>(ref List<T> list, T EmptyObject)
            where T : UnityEngine.Object
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

        public int IntField(string name, int val)
        {
            return EditorGUILayout.IntField(name, val);
        }
        public float FloatField(string name, float val)
        {
            return EditorGUILayout.FloatField(name, val);
        }
        #endregion
    }
}
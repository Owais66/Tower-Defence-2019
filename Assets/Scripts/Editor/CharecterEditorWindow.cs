using UnityEditor;
using UnityEngine;
using MyDefinations;
namespace MyEditor
{
    public class CharecterEditorWindow : EditorWindow
    {
        public static CharecterEditorWindow charecterEditorWindow;
        private CharInfo charecterInfo;

        [MenuItem("Window/MyEditor/Charecter Editor")]
        public static void Init()
        {
            charecterEditorWindow = EditorWindow.GetWindow<CharecterEditorWindow>(false, "Charecter", true);
            charecterEditorWindow.Show();
            charecterEditorWindow.Populate();
        }

        void Populate()
        {
            


        }

        UnityEngine.Object _CInfo;

        #region foldout bools
        bool BasicInfo = false;
        bool CharSetup = false;
        #endregion
        public void OnGUI()
        {

                _CInfo = EditorGUILayout.ObjectField(_CInfo, typeof(CharInfo), false);
                if (GUILayout.Button("Open"))
                {
                    charecterInfo = (CharInfo)_CInfo;
                }

            //Basic Info
            BasicInfo = EditorGUILayout.Foldout(BasicInfo, "BasicInfo");
            if (BasicInfo)
            {
                charecterInfo.Name = EditorGUILayout.TextField("Name", charecterInfo.Name);
                charecterInfo.Prefab = (GameObject) EditorGUILayout.ObjectField("Prefab",charecterInfo.Prefab, typeof(GameObject), false);
            }

            //Charecter Setup
            CharSetup = EditorGUILayout.Foldout(CharSetup, "Charecter Setup");
            GameObject TempCharecter; 
            if (CharSetup)
            {
                EditorGUILayout.BeginHorizontal();
                if(GUILayout.Button("Open Charecter"))
                {
                    if (charecterInfo.Prefab != null)
                    {
                        TempCharecter = GameObject.Instantiate(charecterInfo.Prefab);

                    }else
                    Debug.LogError("Prefab is not  Set");
                }
                EditorGUILayout.EndHorizontal();
            }
        }
    }
}
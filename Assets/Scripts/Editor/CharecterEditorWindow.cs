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

                charecterInfo.SpawnTime = FloatField("SpawnTime", charecterInfo.SpawnTime);
                charecterInfo.speed = FloatField("speed", charecterInfo.speed);
                charecterInfo.HP = FloatField("HP", charecterInfo.HP);
                charecterInfo.Cost = FloatField("Cost", charecterInfo.Cost);
                charecterInfo.Attack = FloatField("Attack", charecterInfo.Attack);
                
                
            }

            //Charecter Setup
            CharSetup = EditorGUILayout.Foldout(CharSetup, "Charecter Setup");
            GameObject TempCharecter; 
            if (CharSetup)
            {
                //Combat Values
                charecterInfo.TargetDetectRange = FloatField("TargetDetectRange", charecterInfo.TargetDetectRange);
                charecterInfo.TargetEscapeRanege = FloatField("TargetEscapeRanege", charecterInfo.TargetEscapeRanege);
                charecterInfo.AttackRange = FloatField("AttackRange", charecterInfo.AttackRange);

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

            //Save Button

            if (GUILayout.Button("Save"))
            {
                EditorUtility.SetDirty(this);
                AssetDatabase.SaveAssets();
            }
        }

        public int IntField(string name,int val)
        {
            return EditorGUILayout.IntField(name,val);
        }
        public float FloatField(string name, float val)
        {
            return EditorGUILayout.FloatField(name, val);
        }
    }
}
using UnityEditor;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace MyDefinations
{
    [System.Serializable]
    [CreateAssetMenu(fileName = "CharecterInfo", menuName = "Definations/CharecterInfo", order = 1)]
    public class CharInfo : ScriptableObject
    {   
        //Basic Info
        public string Name;
        public GameObject Prefab;

        //Stat Info
        public float SpawnTime;
        public float speed;
        public float HP;
        public float Cost;
        public float Attack;

        public float TargetDetectRange;
        public float TargetEscapeRanege;
        public float AttackRange;


    }
}

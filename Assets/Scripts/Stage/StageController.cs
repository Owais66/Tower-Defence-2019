using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public class StageController : MonoBehaviour
    {   
        [System.Serializable]
        public class Towers
        {
            public Transform KingTower;
            public Transform ArcherTower1;
            public Transform ArcherTower2;
        }
        //Player Towers
        public Towers PlayerTowers;

        //Enemy Towers
        public Towers EnemyTowers;
    }
}
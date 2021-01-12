using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
    public class PlayerManager : PlayerBase
    {

        public EnemyManager enemyManager;
        void Start()
        {
            base.start();
            PlayerTowers = stageController.Player1Towers;
            EnemyTowers = stageController.Player2Towers;

            enemyManager = GameObject.FindObjectOfType<EnemyManager>();

            enemyManager.OnHitEvent += OnHurt;
        }

        void Update()
        {
            if (ControlManager.Instance.IsMouse0Down())
            {
                RaycastHit mouse0hit = ControlManager.Instance.mouse0hit;
                if (mouse0hit.point != Vector3.zero)
                {
                    NPCController.InstantiateNPC(GameManager.Instance.globalInfo.characterInfos[0], mouse0hit.point, this);

                }
            }
            
        }

        public void OnHurt(PlayerBase enemybase, NPCBase Attacker, NPCBase Victim)
        {
            base.OnHurt(Attacker, Victim);
            
        }
        
    }
}
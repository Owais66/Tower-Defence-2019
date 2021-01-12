using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    public class EnemyManager:PlayerBase
    {
        PlayerManager playerManager;
        private void Start()
        {
            base.start();
            playerManager = GameObject.FindObjectOfType<PlayerManager>();
            
            playerManager.OnHitEvent += OnHurt;
            base.OnHitEvent += OnHit;

            PlayerTowers = stageController.Player2Towers;
            EnemyTowers = stageController.Player1Towers;
        }

        private void Update()
        {
           
           
        }

        #region Combat
        //Hurt
        void OnHurt(PlayerBase playerBase, NPCBase Attacker, NPCBase Victim)
        {
            base.OnHurt(Attacker, Victim);
        }

        //Hit 
        void OnHit(PlayerBase playerBase, NPCBase Attacker, NPCBase Victim)
        {
            
        }

        #endregion
    }
}

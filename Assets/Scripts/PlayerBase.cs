using System.Collections;
using UnityEngine;
using MyDefinations;
namespace Assets.Scripts
{
    public class PlayerBase : MonoBehaviour
    {
        #region
        public delegate void OnHitHurtEventHandler(PlayerBase playerBase, NPCBase Attacker, NPCBase Victim);
        public event OnHitHurtEventHandler OnHurtEvent;
        public event OnHitHurtEventHandler OnHitEvent;
        #endregion
        #region Stage
        public StageController stageController;
        public PlayerInfo.TowersInfo PlayerTowers;
        public PlayerInfo.TowersInfo EnemyTowers;
        #endregion

        public float Elixer;
        protected void start()
        {
            stageController = FindObjectOfType<StageController>();
        }
        public virtual void OnHurt(NPCBase Attacker, NPCBase Victim)
        {
            if(OnHurtEvent != null)       
            OnHurtEvent(this, Attacker,Victim);
        }

        public virtual void OnHit(NPCBase Attacker, NPCBase Victim)
        {
            OnHitEvent(this, Attacker, Victim);
        }
    }
}
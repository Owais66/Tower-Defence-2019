using System;
using UnityEngine;
using MyDefinations;
namespace Assets.Scripts
{
    public abstract class NPCBase : MonoBehaviour
    {
        #region Events
        public delegate void OnNPCHitHurtHandler(NPCBase Attacker, NPCBase Victim);
        public event OnNPCHitHurtHandler OnHurtEvent;
        public event OnNPCHitHurtHandler OnHitEvent;
        public delegate void OnNPCStateChangeDel(NPCBase nPCController, NPCState nPCState);
        public event OnNPCStateChangeDel OnNPCStateChangeEvent;
        #endregion

        public enum NPCState { WalkToTower, WalkToTarget, AttackTower, AttackTarget }
        private NPCState _nPCState;
        public NPCState nPCState
        {
            set { _nPCState = value; if(OnNPCStateChangeEvent != null) OnNPCStateChangeEvent(this, value); }
            get { return _nPCState; }
        }

        [HideInInspector]public PlayerBase PlayerBase;
        [HideInInspector]public CharInfo charInfo;
        [HideInInspector]public Vector3 SpawnVector;
        
        [HideInInspector]public SkinnedMeshRenderer meshRenderer;
        [HideInInspector]public NPCGUIController npcguiController;
        [HideInInspector]public Animator animator;

        [HideInInspector] public float Health = 100;
        protected virtual void start()
        {   
            SpawnVector = transform.position;

            meshRenderer = GetComponentInChildren<SkinnedMeshRenderer>();
            npcguiController = GetComponentInChildren<NPCGUIController>();

            Health = charInfo.HP;

            //Suibscribe To Hit and Hurt Enents
            PlayerBase.OnHurtEvent += (PlayerBase playerBase,NPCBase Attacker, NPCBase Victim) => onHurtEvent(Attacker, Victim);
        }

        //Static Methods
        

        #region Events Methods
        protected void onHurtEvent(NPCBase Attacker, NPCBase Victim)
        {
            if(OnHurtEvent != null)
            OnHurtEvent(Attacker, Victim);

            Debug.Log(gameObject.name);
        }
        protected void onHitEvent(NPCBase Attacker, NPCBase Victim)
        {
            if(OnHitEvent != null)
            OnHitEvent(Attacker, Victim);

            PlayerBase.OnHit(Attacker, Victim);
        }
        #endregion

        #region Virtual Methods
        protected virtual void OnHitCheck(){
            
        }
        protected virtual void OnHurtCheck(){

        }
        #endregion
    }
}
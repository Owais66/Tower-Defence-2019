using System.Collections;
using System;
using UnityEngine;
using UnityEngine.AI;
using MyDefinations;
namespace Assets.Scripts
{
    public class NPCController : NPCBase
    {

        #region NPC info

        

        #endregion


        #region Navigation Variables
        NavMeshAgent nav;
        StageController stageController;
        #endregion



        #region Main
        public static void InstantiateNPC(CharInfo charInfo, Vector3 spawnPos, PlayerBase _playercontroller)
        {
            if (charInfo != null)
            {
                GameObject spawnedNPC = GameObject.Instantiate(charInfo.Prefab);
                spawnedNPC.GetComponentInChildren<SkinnedMeshRenderer>().enabled = false;
                spawnedNPC.transform.position = spawnPos;

                NPCController nPCController = spawnedNPC.GetComponent<NPCController>();
                nPCController.charInfo = charInfo;
                nPCController.PlayerBase = _playercontroller;
            }
            else
                Debug.LogError("Charecter Info Not Found");
        }
        private void Start()
        {
            base.start();
            
            stageController = GameManager.Instance.stageController;
            animator = GetComponent<Animator>();

            nav = GetComponent<NavMeshAgent>();
            AnimationStart();
            SpawnNPC();
            CombatStart();
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                //nPCState = NPCState.WalkToTarget;
                //onHurtEvent(50);
            }
            NavigationUpdate();
        }
        #region Combat
        void CombatStart()
        {
            base.OnHurtEvent += OnHurt;
        }
        [SerializeField]private Transform HitObject;
        //Triggered By OnHitAnimEvent

        //Hit
        protected override void OnHitCheck(){
            
            if(nPCState == NPCState.AttackTower)
            {
                Transform ClosestTower = GetClosestTower();
                
                base.onHitEvent(this,ClosestTower.GetComponent<TowerController>());
            }
        }

        //OnHurt
        void OnHurt(NPCBase Attacker, NPCBase Victim)
        {
            Health -= 20;
        }
        protected override void OnHurtCheck()
        {
            Debug.Log(gameObject.name + " is Hurt");
        }
        #endregion

        #region Overidden Methods

        #endregion

        #region Overidden Methods
            public void SpawnNPC()
            {   
                base.meshRenderer.enabled = true;
                GotoTower();

            }
        #endregion
        #endregion

        #region Raycast
            
        #endregion

        #region Navigation
        
        void NavigationUpdate()
        {   
            if (nav.remainingDistance <= nav.stoppingDistance)
            {
                switch (nPCState)
                {
                    case NPCState.WalkToTower:  nPCState = NPCState.AttackTower; break;
                }
            }
        }
        Transform GetClosestTowerDestination()
        {
            Transform EnemyArcher1, EnemyArcher2, EnemyKing;
            EnemyArcher1 = PlayerBase.EnemyTowers.Archer1Destination;
            EnemyArcher2 = PlayerBase.EnemyTowers.Archer2Destination;
            EnemyKing = PlayerBase.EnemyTowers.KingDestinaion;

            float ClosestDist;
            

            Transform ClosestTower = EnemyArcher1;
            ClosestDist = Vector3.Distance(transform.position, ClosestTower.position);
            
            if (Vector3.Distance(transform.position, EnemyArcher2.position) < ClosestDist)
            {
                ClosestTower = EnemyArcher2;
                ClosestDist = Vector3.Distance(transform.position, EnemyArcher2.position);
            }

            if (Vector3.Distance(transform.position, EnemyKing.position) < ClosestDist)
            {
                ClosestTower = EnemyKing;
            }
            return ClosestTower;
        }
        Transform GetClosestTower()
        {
            Transform ClosestTowerDestination = GetClosestTowerDestination();
            return ClosestTowerDestination.parent;
        }
        void GotoTower()
        {
            nav.SetDestination(GetClosestTowerDestination().position);
            
        }
        #endregion

        #region AnimationController
        void AnimationStart()
        {
            OnNPCStateChangeEvent += OnNPCStateChange;
        }

        enum AnimStates { Attack, Walk };
        void OnNPCStateChange(NPCBase nPCBase, NPCState nPCState)
        {   
            if (nPCState == NPCState.AttackTower)
            {
                base.animator.SetBool(AnimStates.Attack.ToString(), true);
            }
            else if(nPCState == NPCState.WalkToTower || nPCState == NPCState.WalkToTower){
                base.animator.SetBool(AnimStates.Walk.ToString(), true);
            }
        }

            #region Animation Events
                public void OnHitAnimEvent(){
                    OnHitCheck();
                }
            #endregion
        #endregion

    }
}
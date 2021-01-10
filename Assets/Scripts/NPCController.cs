using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using MyDefinations;
namespace Assets.Scripts
{
    public class NPCController : NPCBase
    {
        #region NPC info
        new CharInfo charInfo;
        #endregion


        #region Navigation Variables
        NavMeshAgent nav;
        StageController stageController;
        #endregion

        
        #region Main
        //public NPCController(int CharecterID,Transform SpawnParent,Vector3 SpawnPoint)
        //{
        //    base.SpawnVector = SpawnPoint;
        //    base.charInfo = GameManager.Instance.GetCharacterInfoByID(CharecterID);
        //    base.SpawnParent = this.SpawnParent;
        //}
        private void Start()
        {
            base.start(charInfo);
            //Debug.Log(base.charInfo.Name);
            stageController = GameManager.Instance.stageController;
            
            nav = GetComponent<NavMeshAgent>();
            SpawnNPC();
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                GotoTower();
            }
        }

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
        Transform GetClosestTower()
        {
            float ClosestDist;
            Transform ClosestTower = stageController.EnemyTowers.ArcherTower1;

            ClosestDist = Vector3.Distance(transform.position, stageController.EnemyTowers.ArcherTower1.position);
            if (Vector3.Distance(transform.position, stageController.EnemyTowers.ArcherTower2.position) < ClosestDist)
            {

                ClosestTower = stageController.EnemyTowers.ArcherTower2;
                ClosestDist = Vector3.Distance(transform.position, stageController.EnemyTowers.ArcherTower2.position);
            }

            if (Vector3.Distance(transform.position, stageController.EnemyTowers.KingTower.position) < ClosestDist)
            {
                ClosestTower = stageController.EnemyTowers.KingTower;
            }
            return ClosestTower;
        }
        void GotoTower()
        {
            nav.SetDestination(GetClosestTower().position);
        } 
        #endregion

    }
}
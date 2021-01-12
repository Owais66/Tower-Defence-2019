using UnityEngine;
namespace Assets.Scripts
{
    public class TowerController : NPCBase {

        #region Main
        private void Start()
        {   
            //Get PlayerBase By Tag
            if(tag == "EnemyNPC")
            {
                base.PlayerBase = GameObject.FindObjectOfType<EnemyManager>();
            }
            else if(tag == "PlayerNPC")
            {
                base.PlayerBase = GameObject.FindObjectOfType<PlayerManager>();
            }

            charInfo = GameManager.Instance.GetCharacterInfoByName("EnemyTower1");
            
            base.start();


            CombatStart();
        }
        #endregion
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.H))
            {
                OnHit(this, null);
            }
        }
        #region Combat
        void CombatStart()
        {
            base.OnHurtEvent += OnHurt;
        }
        //OnHit
        void OnHit(NPCBase Attacker, NPCBase Victim)
        {
            base.onHitEvent(Attacker, Victim);
        }

        //OnHurt
        void OnHurt(NPCBase Attacker, NPCBase Victim)
        {
            
        }

        #endregion
    }
}
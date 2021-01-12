using System.Collections;
using UnityEngine;
using MyDefinations;

namespace Assets.Scripts
{
    public class GameManager : MonoBehaviour
    {
        #region Common Delegates
        public delegate void FloatDel<T>(T source,float val1);
        #endregion
        #region Definations
        public GlobalInfo globalInfo;
        #endregion

        #region Singleton
        static GameManager mInstance;

        public static GameManager Instance
        {
            get
            {
                if (mInstance == null) mInstance = new GameObject("GameManager").AddComponent<GameManager>();

                return mInstance;
            }
        }
        private void Awake()
        {
            mInstance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        #endregion


        #region Stage
        StageController _stageController;
        public StageController stageController {
            get {
                if (_stageController == null) {
                    _stageController = GameObject.FindGameObjectWithTag("Stage").GetComponent<StageController>();
                }return _stageController;
            }
            set { _stageController = value; }
        }
        #endregion
        #region Controllers
        public PlayerManager PlayerManager;
        public EnemyManager enemyManager;
        #endregion

        #region Main
        private void Start()
        {
            PlayerManager = GameObject.FindObjectOfType<PlayerManager>();
            enemyManager = GameObject.FindObjectOfType<EnemyManager>();

            if(PlayerManager == null)
            {
                Debug.LogError("Player Manager was  Not Found in GameManager");
            }else if(enemyManager == null)
            {
                Debug.LogError("Enemy Manager was  Not Found in GameManager");
            }




            ///Development Code Remove in Production
            DisableActiveNPC();
        }

        #endregion

        #region Charecter
        public CharInfo GetCharacterInfoByID(int ID)
            {
            return globalInfo.characterInfos[ID];
            }
        public CharInfo GetCharacterInfoByName(string Name)
        {
            foreach (var item in globalInfo.characterInfos)
            {
                if (item.Name == Name) return item;
            }
            return null;
        }
        #endregion

        #region For DevolopmentOnly Remove in Production Code
        void DisableActiveNPC()
        {
            NPCController[] NPCS = GameObject.FindObjectsOfType<NPCController>();

            foreach (var item in NPCS)
            {
                item.gameObject.SetActive(false);
            }
        }
        #endregion
    }
}
using System.Collections;
using UnityEngine;
using MyDefinations;

namespace Assets.Scripts
{
    public class GameManager : MonoBehaviour
    {
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

        #region Charecter
            public CharInfo GetCharacterInfoByID(int ID)
            {
            return globalInfo.characterInfos[ID];
            }
        #endregion
    }
}
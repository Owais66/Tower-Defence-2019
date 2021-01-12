using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyDefinations;

[System.Serializable]
[CreateAssetMenu(fileName = "GlobalInfo", menuName = "Definations/GlobalInfo", order = 1)]
public class GlobalInfo : ScriptableObject
{   
    //Player Info
    public string Name = "globalInfo";
    public PlayerInfo Player1;

    #region Stage
    public List<StageInfo> stageInfos = new List<StageInfo>();
    public StageInfo GetStageByID(int ID)
    {
        if (stageInfos != null && stageInfos.Count > 0)
            return stageInfos[ID];
        return null;
    }
    #endregion

    #region
    public List<CharInfo> characterInfos = new List<CharInfo>();
    #endregion
}

public class PlayerInfo : System.ICloneable
{
    public PlayerInfo()
    {
        towersInfo = new TowersInfo();
    }

    public string PlayerName;
    public TowersInfo towersInfo;

    [System.Serializable]
    public class TowersInfo 
    {
        public Transform King;
        public Transform Archer1;
        public Transform Archer2;

        public Transform KingDestinaion;
        public Transform Archer1Destination;
        public Transform Archer2Destination;

        [HideInInspector] public float KingHealth = 0;
        [HideInInspector] public float Archer1Health = 0;
        [HideInInspector] public float Archer2Health = 0;
    }
    public object Clone()
    {
        throw new System.NotImplementedException();
    }
}



public class StageInfo
{
    public int StageID;
    public GameObject Prefab;
}

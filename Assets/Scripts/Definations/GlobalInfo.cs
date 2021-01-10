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
    public PlayerInfo Player1 = new PlayerInfo();

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

public class PlayerInfo{
    public string PlayerName;

    public TowersInfo towersInfo;

}
public class TowersInfo{
    public int ArcherTowerLvl;
    public int KingTowerLvl;
}

public class StageInfo
{
    public int StageID;
    public GameObject Prefab;
}

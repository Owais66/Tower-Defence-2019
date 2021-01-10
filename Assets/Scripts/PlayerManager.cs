using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
    public class PlayerManager : MonoBehaviour
    {
        //Camera camera;

        //Parent ForPlayer NPC
        Transform NPCParent;
        void Start()
        {
            //Parent ForPlayer NPC
            NPCParent = GameObject.Instantiate(new GameObject("PlayerNPCs"), transform).transform;
            
        }

        void Update()
        {
            if (ControlManager.Instance.IsMouse0Down())
            {
                RaycastHit mouse0hit = ControlManager.Instance.mouse0hit;
                if (mouse0hit.point != Vector3.zero)
                {
                    //GameObject SpawnedChar = GameObject.Instantiate(GameManager.Instance.GetCharacterInfoByID(0).Prefab, mouse0hit.point, Quaternion.identity);
                    //GameObject knightnpc = GameObject.Instantiate(GameManager.Instance.globalInfo.characterInfos[0].Prefab,NPCParent);
                    NPCBase.InstantiateNPC(GameManager.Instance.globalInfo.characterInfos[0], mouse0hit.point, NPCParent);

                }
            }
            
        }

        
    }
}
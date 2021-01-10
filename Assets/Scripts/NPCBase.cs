using System.Collections;
using UnityEngine;
using MyDefinations;
namespace Assets.Scripts
{
    public class NPCBase : MonoBehaviour
    {
        public enum NPCState {WalkToTower, WalkToTarget, AttackTower, AttackTarget}

        public CharInfo charInfo;
        public Vector3 SpawnVector;

        public AnimationController anim;
        public SkinnedMeshRenderer meshRenderer;
        protected void start(CharInfo _charInfo)
        {
            SpawnVector = transform.position;
            charInfo = _charInfo;

            anim = GetComponent<AnimationController>();
            meshRenderer = GetComponentInChildren<SkinnedMeshRenderer>();
        }

        //Static Methods
        public static void InstantiateNPC(CharInfo charInfo, Vector3 spawnPos, Transform npcParent) {
            if (charInfo != null)
            {   
                GameObject spawnedNPC = GameObject.Instantiate(charInfo.Prefab);
                spawnedNPC.GetComponentInChildren<SkinnedMeshRenderer>().enabled = false;
                spawnedNPC.transform.position = spawnPos;

                NPCController nPCController = spawnedNPC.AddComponent<NPCController>();
                nPCController.charInfo = charInfo;
            }
            else
                Debug.LogError("Charecter Info Not Found");
        }
    }
}
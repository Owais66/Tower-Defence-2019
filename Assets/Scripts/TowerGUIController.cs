using UnityEngine;
using Assets.Scripts;
public class TowerGUIController : MonoBehaviour {
    Animator animator;
    NPCBase towerController;
    Transform trans;
    [SerializeField] bool LookAtOnStartOnly;
    [SerializeField] Transform healthbar;
    [SerializeField] float Minhealthpos;
    [SerializeField] float Maxhealthpos;
    float HealthBarRatio;

    private void Start()
    {
        trans = GetComponent<Transform>();
        
        towerController = GetComponent<TowerController>();
        HealthBarRatio = (Maxhealthpos - Minhealthpos) / towerController.charInfo.HP;

        trans.LookAt(Camera.main.transform, Vector3.forward);
    }
    private void Update()
    {   
        if(!LookAtOnStartOnly)
        trans.LookAt(Camera.main.transform, Vector3.forward);
    }
    public virtual void HealthMinus(NPCBase nPCBase,float DamageHP)
    {
        healthbar.localPosition =  Vector3.right * (nPCBase.Health - DamageHP) * HealthBarRatio;
        Debug.Log(healthbar.localPosition +"   "+ Vector3.right * (nPCBase.Health - DamageHP) * HealthBarRatio);
    }
}
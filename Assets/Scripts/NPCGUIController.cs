using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts;
using System;
public class NPCGUIController : MonoBehaviour
{

    Animator animator;
    NPCBase nPCController;

    Transform trans;
    [SerializeField] bool LookAtOnStartOnly;
    [SerializeField] Transform healthbar;
    [SerializeField] float Minhealthpos;
    [SerializeField] float Maxhealthpos;
    float HealthBarRatio;

    private void Start()
    {
        trans = GetComponent<Transform>();
        nPCController = GetComponentInParent<NPCBase>();
        nPCController.OnHurtEvent += HealthMinus;

        HealthBarRatio = (Maxhealthpos - Minhealthpos) / nPCController.charInfo.HP;

        trans.LookAt(Camera.main.transform, Vector3.forward);
    }
    private void Update()
    {   
        if(!LookAtOnStartOnly)
        trans.LookAt(Camera.main.transform, Vector3.forward);
    }
    public virtual void HealthMinus(NPCBase AttackerNPC,NPCBase VictimNPC)
    {
        float DamageHP = nPCController.charInfo.Attack;
        Debug.Log("is NPCcont in gui empty " + nPCController.Health + DamageHP);
        
        healthbar.localPosition =  Vector3.right * (nPCController.Health) * HealthBarRatio;
    }
}

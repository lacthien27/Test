using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEditor.Experimental.GraphView;
using JetBrains.Annotations;

public class JunkFly : ParentFly
{

    [SerializeField]  public JunkSpawnCtrl junkSpawnCtrl; // self edit
    [SerializeField] Vector3 camPos =new Vector3(0f,0f,0f);

    [SerializeField] Vector3 objPos =new Vector3(0f,0f,0f);

    [SerializeField] protected float minCamPos = -16f;
    [SerializeField] protected float maxCamPos = 16f;

    protected override void ResetValue()
    {
        base.ResetValue();
        this.moveSpeed =0.5f;
    }

    protected  override void OnEnable() 
    {
        base.OnEnable(); 
        this.GetFlyDirection();   
    }

    protected override void LoadComponents() //self edit
    {
        base.LoadComponents();
        this.LoadJunkCtrl();
        
    }

    


    protected  virtual void LoadJunkCtrl() //self edit
    {
        if(this.junkSpawnCtrl !=null) return;
        this.junkSpawnCtrl = GetComponentInParent<JunkSpawnCtrl>();
        Debug.LogWarning(transform.name+"LoadJunkSpawnCtrl"+gameObject);
        
    }

    // protected virtual void GetFlyDirection()// saigame
    // {
    //     if(GameCtrl.Instance.MainCamera.transform.position !=null)
    //     {
    //         Debug.LogWarning("null");
    //     }
    //     Vector3 objPos= transform.parent.position;

    //     camPos.x +=UnityEngine.Random.Range(this.minCamPos,this.maxCamPos);
    //     camPos.z +=UnityEngine.Random.Range(this.minCamPos,this.maxCamPos);
        
    //     Vector3 diff = camPos - objPos;
    //     diff.Normalize();

    //     float rot_z =Mathf.Atan2(diff.y, diff.x) *Mathf.Rad2Deg;
    //     transform.parent.rotation =Quaternion.Euler(0f,0f,rot_z);  
    // }

    protected virtual void GetFlyDirection() // self edit
    {
        this.camPos = this.junkSpawnCtrl.gameCtrl.MainCamera.transform.position;       
        this.objPos= transform.parent.position;

        camPos.x +=UnityEngine.Random.Range(this.minCamPos,this.maxCamPos);
        camPos.z +=UnityEngine.Random.Range(this.minCamPos,this.maxCamPos);
    
        Vector3 diff = camPos - objPos;
        diff.Normalize();

        float rot_z =Mathf.Atan2(diff.y, diff.x) *Mathf.Rad2Deg;
        transform.parent.rotation =Quaternion.Euler(0f,0f,rot_z); 
        Debug.DrawLine(objPos,objPos+diff*7, Color.red,Mathf.Infinity);

    }




}

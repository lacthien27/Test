using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    public class GameCtrl : SaiMonoBehaviour
{
    private static GameCtrl instance;
    public static  GameCtrl Instance {get=> instance;}  // thứ đc lấy ra sài
    [SerializeField] protected Camera mainCamera;
    public Camera MainCamera {get => mainCamera;}

    [SerializeField] protected   JunkSpawnCtrl junkSpawnCtrl;
    
protected override void Awake()
{
    base.Awake();
    if(GameCtrl.instance !=null) 
    {
        Debug.LogError("just only 1 gameManager");
        GameCtrl.instance  =this;
    }
}
protected override void LoadComponents()
{
    base.LoadComponents();
    this.LoadCamera();
    this.LoadJunkCtrl();
}

 protected virtual void LoadCamera()
 {
    if(this.mainCamera !=null) return;
    this.mainCamera =GameCtrl.FindObjectOfType<Camera>();

    Debug.Log(transform.name+"LoadCamera",gameObject);
 }


    protected virtual void LoadJunkCtrl()    
    {
        if( this.junkSpawnCtrl !=null) return;
        this.junkSpawnCtrl = GameCtrl.FindObjectOfType<JunkSpawnCtrl>();
        Debug.LogWarning(transform.name+"LoadJunkCtrl",gameObject);
    }
 
}

using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public abstract class BulletAbstract : SaiMonoBehaviour
    
{
    [Header("Bullet Abstract")]
    [SerializeField] protected BulletCtrl bulletCtrl;
    public BulletCtrl BulletCtrl {get=>bulletCtrl;}
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadBulletCtrl();    
    }

    protected virtual void LoadBulletCtrl()
    {
        if(this.bulletCtrl != null) return;
        this.bulletCtrl = transform.parent.GetComponent<BulletCtrl>();
        Debug.LogWarning(transform.name+"LoadBulletCtrl");
    }

    
}

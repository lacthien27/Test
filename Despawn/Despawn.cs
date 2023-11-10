using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Despawn : SaiMonoBehaviour
{
    protected virtual  void FixedUpdate() 
    {
        this.Despawning();    
    }

    protected virtual void Despawning()// quyết định xem có xóa object hay không
    {
        if(!this.CanDespawn()) return;
        this.DespawnObject();
    }

    public virtual void DespawnObject()
    { 
        Destroy(transform.parent.gameObject);
    }

    protected abstract bool   CanDespawn();  // xem  tình trạng có cần xóa object hay không
    
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DespawnByDistance : Despawn
{
    [SerializeField ]protected float disLimit =70f  ;
    [SerializeField ]protected float distance =70f  ;
    [SerializeField ]protected Camera mainCam  ;


    protected override void LoadComponents()
    {
        this.LoadCamera();
    }
    
    protected virtual void  LoadCamera()
    {
        if(this.mainCam !=null) return;
        this.mainCam =Transform.FindObjectOfType<Camera>();
        if(this.CanDespawn()) return; // kiểm tra xem có cần xóa object hay chưa nếu chưa cần thì ngưng thằng Despawn ko để nó xóa
        this.DespawnObject();  
    }
    public override void DespawnObject()
    {
        Destroy(transform.parent.gameObject);
    }
    protected override bool   CanDespawn()
    {
        this.distance =Vector3.Distance(transform.position,this.mainCam.transform.position);  //khoảng cách giữa vị trí viên dạn và maincam
        if(this.distance>this.disLimit) return true;
        return false;
    }
}

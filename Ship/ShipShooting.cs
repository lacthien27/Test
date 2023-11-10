using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class ShipShooting : SaiMonoBehaviour
{
    [SerializeField] protected bool isShooting = false;
    [SerializeField] protected float shootTimer = 0f;
    [SerializeField] protected float shootDelay = 0.2f;
   
    void Update()
    {
        this.IsShooting();
    }

    void FixedUpdate()
    {
        this.Shooting();
    }
    
    protected virtual void Shooting()
    {
        if(!this.isShooting) return;    
       
        this.shootTimer += Time.fixedDeltaTime; 
        if (this.shootTimer<= this.shootDelay) return;

        this.shootTimer=0; // điểm cuối của vòng lặp

        Vector3 spawnPos = transform.position;
        Quaternion rotation = transform.parent.rotation;
        Transform newBullet = BulletSpawner.Instance.Spawn(BulletSpawner.bulletTwo, spawnPos,rotation);// nơi tạo đạn ( điền vào tên, vị trí ,và gốc xoay)
        if(newBullet == null) return;
        //Debug.Log("bắn");
        newBullet.gameObject.SetActive(true);   //đặt cho trạng thái object luôn true khi khởi tạo

        BulletCtrl bulletCtrl = newBullet.GetComponent<BulletCtrl>(); // there is connect in shooting children
        bulletCtrl.SetShooter(transform.parent);

        }

    protected virtual bool IsShooting()
    {
        // onfiring trả về 0 or 1   hàm này so sánh  onfiring và giá trị cho trước nếu nó bằng nhau thì là bắn hoặc ngược lại
        this.isShooting= InputManager.Instance.onFiring ==1;
        //hàm này ghi nhận giá trị bên trên lại và trả về cho hàm  là  true hay false 
        return this.isShooting;


    }
        //nhớ tối ưu phần bắn đạn nhấp 1 lần là bắn 1 lần giữ liên tục thì bắn liên thanh
}

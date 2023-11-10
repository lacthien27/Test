using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public abstract class Spawner : SaiMonoBehaviour
{
    [SerializeField] protected List<Transform> prefabs;    
    [SerializeField] protected List<Transform> poolObjs;    
    [SerializeField] protected Transform  holder;
    [SerializeField]  protected  int spawnedCount = 0;
    public int SpawnedCount => spawnedCount;
 
    protected override void LoadComponents()   // các hàm cần được  reset khi nhấn nút reset
    {
        this.LoadPrefabs();
        this.LoadHolder();
    }

    protected virtual void LoadHolder() //  hàm giữ đạn bắn ,
    {   

        if(this.holder !=null)
        {
            return;
        } 

        holder = transform.Find("Holder"); 
        Debug.Log(transform.name+"loadHolder , find and attach connect it",gameObject);
    }

    protected virtual void LoadPrefabs()
    {   

        if(this.prefabs.Count >0) return;
        Transform prefabsObj = transform.Find("Prefabs");
        foreach(Transform prefab  in  prefabsObj)    //  mõi lần lập sễ lấy 1 prefabsObj  
        {
            this.prefabs.Add(prefab);
        }
        this.HidePrefabs();  
        Debug.Log(transform.name +"reset lại LoadPreFabs",gameObject  );//   xem nó có bị lỗi gọi 2 lần không
    }

    protected virtual  void   HidePrefabs()  
    {
        foreach(Transform prefab in prefabs)
        {
            prefab.gameObject.SetActive(false);
        }
    }

    public virtual Transform Spawn(string prefabName ,Vector3 spawnPos, Quaternion  rotation)
    {   
        Transform prefab = this.GetPrefabByName(prefabName);   
        if(prefab ==null)   
        {
            Debug.Log("Prefab not found:"+prefabName);
            return null;
        }
        return this.Spawn(prefab,spawnPos,rotation);
    }

        
     public virtual Transform Spawn(Transform prefab ,Vector3 spawnPos, Quaternion  rotation)
    {          
        // gọi từ hàm  pool lên tái sử dụng lại
        Transform newPrefab =this.GetObjectFromPool(prefab);
        newPrefab.SetPositionAndRotation(spawnPos,rotation);

        newPrefab.parent =this.holder;  // holder dùng để chứa đạn bắn
        this.spawnedCount ++; 
        return newPrefab;
    }

    public virtual Transform GetPrefabByName(string prefabName)  //  name syns, if name sender same name of this prefabs
    {
        foreach ( Transform  prefab in this.prefabs)  
        {
            if(prefab.name ==prefabName)   return prefab;
        }
        return null;
    }
   

   protected virtual Transform GetObjectFromPool(Transform prefab)  // get obj from to list  pool to check
   {
    foreach(Transform  poolObj in this.poolObjs)    // kiểm tra list  obj cần bắn có nằm trong list pool hay không
    {
        if(poolObj.name == prefab.name)             // nếu obj cần bắn có  trong list pool thì trả nó ra
        {   
            this.poolObjs.Remove(poolObj);
            return poolObj;
            
        }
    }
    Transform newPrefab = Instantiate(prefab);
    newPrefab.name = prefab.name;           // hàm đồng bộ tên
    return newPrefab;     

   }

   public virtual void Despawn(Transform obj)   
    {
        this.poolObjs.Add(obj);  //  obj thêm nó vào hàng đợi 
        obj.gameObject.SetActive(false); 
        this.spawnedCount --;
    }

    public virtual Transform  RandomPrefab()
    {
        int rand= Random.Range(0,this.prefabs.Count);
        return this.prefabs[rand];
    }

    
}  

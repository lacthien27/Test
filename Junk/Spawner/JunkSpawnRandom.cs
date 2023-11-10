using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JunkSpawnRandom : SaiMonoBehaviour
{
   [Header("Junk Random")]

   [SerializeField] protected JunkSpawnCtrl junkSpawnCtrl;
   [SerializeField] protected float randomDelay =1f;
   [SerializeField]  protected float RandomTimer = 0f;
   [SerializeField]  protected float RandomLimit = 10f;
   
   protected override void LoadComponents()
   {
    base.LoadComponents();
    this.LoadJunkSpawnCtrl();
  
   }

   protected virtual void LoadJunkSpawnCtrl()
   {
    if(this.junkSpawnCtrl!= null) return;
    this.junkSpawnCtrl = GetComponent<JunkSpawnCtrl>();
    Debug.Log(transform.name+":LoadJunkCtrl",gameObject);
   }
   protected virtual  void FixedUpdate() 
   {
      this.JunkSpawning();
   
   }

   protected virtual void  JunkSpawning()
   {
      if(this.RandowmReachLimit()) return;

      this.RandomTimer += Time.fixedDeltaTime;
      if(this.RandomTimer < this.randomDelay ) return;
      this.RandomTimer =0;



      Transform ranPoint = this.junkSpawnCtrl.JunkSpawnPoints.GetRandom();  // random lấy vị trí
      Vector3 pos = ranPoint.position; //             chỗ random được spawn
      Quaternion  rot = transform.rotation;

      Transform prefab =this.junkSpawnCtrl.JunkSpawner.RandomPrefab();

      Transform obj = this.junkSpawnCtrl.JunkSpawner.Spawn(prefab,pos,rot);   
      obj.gameObject.SetActive(true);
   }

   protected virtual bool RandowmReachLimit() // if junk levet out  is not spawn
   {
      int currentJunk = this.junkSpawnCtrl.JunkSpawner.SpawnedCount;
      return currentJunk >= this.RandomLimit;
   }

 

}


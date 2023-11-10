using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class JunkSpawnCtrl : SaiMonoBehaviour
{
    [SerializeField] protected  JunkSpawner junkSpawner;
     public  JunkSpawner JunkSpawner {get => junkSpawner;}

    [SerializeField] protected JunkSpawnPoints junkSpawnPoints;
     public    JunkSpawnPoints JunkSpawnPoints {get => junkSpawnPoints;}


      [SerializeField] public JunkFly junkFly;  //self edit

       [SerializeField] public GameCtrl gameCtrl;  //self edit


   protected override void LoadComponents()
   {
    base.LoadComponents();
    this.LoadJunkSpawner();
    this.LoadJunkSpawnPoints();
    this.LoadGameCtrl();
    this.LoadJunkFly();
   }
   protected virtual void LoadJunkSpawner()
   {
     if(this.junkSpawner !=null) return;
     this.junkSpawner = GetComponent<JunkSpawner>();
     Debug.Log(transform.name +":LoadJunkSpawner" , gameObject);
   }

   protected virtual void LoadJunkSpawnPoints()
   {
    if(this.junkSpawnPoints != null) return;
    this.junkSpawnPoints = Transform.FindObjectOfType<JunkSpawnPoints>();
    Debug.Log(transform.name +" LoadJunkSpawnPoints", gameObject);
   }

   protected virtual void LoadJunkFly()
   {
      if(this.junkFly !=null) return;
      this.junkFly =GetComponentInChildren<JunkFly>();
        {
          Debug.LogWarning(transform.name +"JunkFly link needed",gameObject);
        }

      }
   protected virtual void LoadGameCtrl()
   {
     if(this.gameCtrl !=null) return;
        this.gameCtrl = JunkSpawnCtrl.FindObjectOfType<GameCtrl>();
        Debug.LogWarning(transform.name+"LoadGameCtrl"+gameObject);
    }
}

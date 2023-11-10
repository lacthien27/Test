using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SpawnPoints : SaiMonoBehaviour
{
    [SerializeField] protected  List<Transform> points; 
   protected override void LoadComponents()
   {
    base.LoadComponents();
    this.LoadPoint();
   }



   protected virtual void LoadPoint()
   {
    if(this.points.Count> 0) return;
    foreach(Transform point in transform)
    {
        this.points.Add(point.transform);

    }
    Debug.Log(transform.name+"LoadPoints", gameObject);
   }

    public virtual Transform GetRandom()
    {
        int rand =  Random.Range(0,this.points.Count);
        return this.points[rand];
    }
}

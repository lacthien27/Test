using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDropSpawner : Spawner
{
//    private static ItemDropSpawner  instance;

    //public ItemDropSpawner Instance =>instance;

    public static ItemDropSpawner instance;


    protected override void Awake()
    {
        base.Awake();
        if(ItemDropSpawner.instance!=null) Debug.LogWarning("Only 1 ItemDropSpawner");
        ItemDropSpawner.instance =this;
    }



    public virtual void  Drop(List<DropRate> dropList, Vector3 Pos, Quaternion Rot)
    {
        ItemCode itemCode =dropList[0].itemSO.itemCode;// yet known
        Transform itemDrop =this.Spawn(itemCode.ToString(),Pos,Rot);
        itemDrop.gameObject.SetActive(true);

    }
}

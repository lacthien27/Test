using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : Spawner 
{
    // hàm này có instance
    private static BulletSpawner instance;
    public static BulletSpawner Instance { get => instance;}

    public  static string bulletOne = "Bullet_1";
    public  static string bulletTwo = "Bullet_2";
    protected override void Awake()
    {
        base.Awake();
        if(InputManager.Instance !=null) Debug.LogError(("only 1 bullet"));
        BulletSpawner.instance =this;
    }   


}

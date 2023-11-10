using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JunkSpawner : Spawner
{
    private static JunkSpawner instance;

    public static JunkSpawner Instance  {get => instance;}
    

    protected override void Awake()
    {
        base.Awake();
        if(InputManager.Instance !=null) Debug.LogError(("only 1 meteorite"));
        JunkSpawner.instance =this;
    }   

}

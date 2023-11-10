using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParentFly : SaiMonoBehaviour
{
    [SerializeField] protected float moveSpeed =1f;
    [SerializeField] public Vector3 direction = Vector3.right;

    void Update()
    {
        transform.parent.Translate(this.direction*this.moveSpeed*Time.deltaTime);
    }

    
}

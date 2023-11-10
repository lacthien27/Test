using System.Collections;
using System.Collections.Generic;
using System.Net.Security;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class BulletFly : ParentFly
{


    protected override void ResetValue()
    {
        base.ResetValue();
        this.moveSpeed = 11;
        
    }
}

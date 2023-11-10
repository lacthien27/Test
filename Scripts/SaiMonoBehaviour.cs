using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaiMonoBehaviour : MonoBehaviour
{   
    protected virtual void OnEnable()
    {
        
    }
    protected virtual void Start(){;}

    protected  virtual void Awake() 
    {
        this.LoadComponents();
        
    }
     protected virtual void Reset()   // hàm chạy mỗi khi nhấn rest 
    {
        this.LoadComponents();
        this.ResetValue();
    }

    protected virtual void LoadComponents()
    {
        // dành cho các script thừa kế viết vào
    }

    protected  virtual void ResetValue()
    {
        // dành cho các sripts kế thừa muốn có đặc điểm riêng
    }
}

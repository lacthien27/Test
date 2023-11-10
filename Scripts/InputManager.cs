using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    private  static InputManager instance;
    public static InputManager  Instance { get => instance;}

    [SerializeField] protected Vector3 mouseWorldPos;   
    public Vector3  MouseWorldPos { get => mouseWorldPos;}  
    
    [SerializeField] public float onFiring;
    private void Awake()
    {
        InputManager.instance = this;

    }

    void Update()
    {
        this.GetMouseDown();
    }
  
    void FixedUpdate()
    {
        this.GetMousePos();
    }
    protected virtual void GetMouseDown()
    {
      this.onFiring =   Input.GetAxis("Fire1");
    }
    protected virtual void GetMousePos()
    {
        this.mouseWorldPos =Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

   

}



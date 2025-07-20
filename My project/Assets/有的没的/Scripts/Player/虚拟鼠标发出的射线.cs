using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 虚拟鼠标发出的射线 : MonoBehaviour
{
    public static Ray 射线;
    public static RaycastHit 命中点;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        射线=Camera.main.ScreenPointToRay(虚拟鼠标.虚拟鼠标的屏幕位置);
        Physics.Raycast(射线,out 命中点);
    }
}

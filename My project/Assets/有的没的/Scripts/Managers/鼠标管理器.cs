using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;


//[System.Serializable]




public class 鼠标管理器 : MonoBehaviour
{



    //public UnityEvent<Vector3> 设置移动目的地;
    public static event Action<Vector3> 场景被点击;
    public static event Action<GameObject> 洋葱被点击;
    RaycastHit 射线碰撞点;

   

    private void Update()
    {
        Ray 鼠标位置转换的射线=Camera.main.ScreenPointToRay(虚拟鼠标.虚拟鼠标的屏幕位置);
        if(Physics.Raycast(鼠标位置转换的射线,out 射线碰撞点))
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (射线碰撞点.collider.gameObject.tag=="洋葱")
                {
                    洋葱被点击?.Invoke(射线碰撞点.collider.gameObject);
                }
                else
                {
                    场景被点击?.Invoke(射线碰撞点.point);
                }
                
            }
        }
    }

   

   
    

}

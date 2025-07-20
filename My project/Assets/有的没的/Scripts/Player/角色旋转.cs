using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 角色旋转 : MonoBehaviour
{
   //轴心原位置:0,0,0   现位置:0,0.45,0
   //碰撞体原位置:0.1,0.45,0   现位置:0.1,0,0

    void Update()
    {
        Ray 指向鼠标位置的射线=Camera.main.ScreenPointToRay(虚拟鼠标.虚拟鼠标的屏幕位置);//Input.mousePosition
        if (Physics.Raycast(指向鼠标位置的射线, out RaycastHit 射线碰撞点的信息))
        {
              面向(射线碰撞点的信息.point);
        }
        else
        {
            面向(指向鼠标位置的射线.GetPoint(100));
        }

    }


    void 面向(Vector3 对象位置)
    {
        //Vector3 角色到对象的矢量 = 对象位置 - transform.position;
        //角色到碰撞点的矢量.y = transform.position.y;
        transform.GetComponent<Rigidbody>().MoveRotation(Quaternion.LookRotation(对象位置 - transform.position));
    }



}

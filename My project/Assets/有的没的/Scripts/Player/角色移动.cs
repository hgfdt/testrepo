using System;
using UnityEngine;

public class 角色移动 : MonoBehaviour       //PlayerMovement
{
    public float 移动速度=10;
    public GameObject 摄像头;

    
    void FixedUpdate()
    {
        //this.GetComponent<Rigidbody>().MovePosition(
        //    transform.position
        //    +new Vector3(Input.GetAxisRaw("Horizontal"),0, Input.GetAxisRaw("Vertical")).normalized
        //    *移动速度*Time.deltaTime);
        Quaternion 摄像头绕y轴的角度 = Quaternion.Euler(0, 摄像头.GetComponent<视角>().绕y轴的角度, 0);
        移动(摄像头绕y轴的角度*Vector3.forward * Input.GetAxisRaw("Vertical")+摄像头绕y轴的角度 * Vector3.right * Input.GetAxisRaw("Horizontal"));
        
    }


    void 移动(Vector3 移动方向)
    {
        this.GetComponent<Rigidbody>().MovePosition(
            transform.position
            + 移动方向
            * 移动速度 * Time.deltaTime);
    }
}

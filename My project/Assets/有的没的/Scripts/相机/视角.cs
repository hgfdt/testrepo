using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;

public class 视角 : MonoBehaviour
{
    // Start is called before the first frame update




    public  float 绕x轴的角度=-45;
    public  float 绕y轴的角度;
    public float 灵敏度=3;
    public float 在屏幕边缘时的灵敏度 = 6;
    public float 百分比 = 0.3f;
    //5


    void Start()
    {

        Cursor.lockState = CursorLockMode.Confined;
    }

    void Update()
    {
        鼠标控制视角();
        虚拟鼠标在屏幕边缘时转动视角();
        transform.rotation = Quaternion.Euler(-绕x轴的角度, 绕y轴的角度, 0);
        
        
        

    }
    void 鼠标控制视角()
    {
        绕y轴的角度+= Input.GetAxis("Mouse X") * 灵敏度;
        绕x轴的角度+= Input.GetAxis("Mouse Y") * 灵敏度;
    }
    void 虚拟鼠标在屏幕边缘时转动视角()
    {
        //if (虚拟鼠标.虚拟鼠标的屏幕位置.x>=Screen.width*(1-百分比))
        //{
        //    绕y轴的角度 +=Mathf.Max(0, Input.GetAxis("Mouse X") * 在屏幕边缘时的灵敏度);
        //}
        //else if(虚拟鼠标.虚拟鼠标的屏幕位置.x <= Screen.width * 百分比)
        //{
        //    绕y轴的角度 += Mathf.Min(0, Input.GetAxis("Mouse X") * 在屏幕边缘时的灵敏度);
        //}
        if (虚拟鼠标.虚拟鼠标的屏幕位置.x == Screen.width || 虚拟鼠标.虚拟鼠标的屏幕位置.x == 0)
        {
            绕y轴的角度 += Input.GetAxis("Mouse X") * 在屏幕边缘时的灵敏度;
        }
        if (虚拟鼠标.虚拟鼠标的屏幕位置.y == Screen.height || 虚拟鼠标.虚拟鼠标的屏幕位置.y == 0)
        {
            绕x轴的角度 += Input.GetAxis("Mouse Y") * 在屏幕边缘时的灵敏度;
        }
    }
   

   
}

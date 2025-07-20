using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class 角色射击1 : MonoBehaviour
{
    
    float 计时=0;
    float 射击发生的时间 = 0;
    public float 射击间隔;
   


    void Update()
    {
        每隔__秒执行__(射击间隔, 尝试射击);
        


    }

    void 每隔__秒执行__(float 间隔时间,Action 要执行的东西)
    {
        计时 = 计时 + Time.deltaTime;
        if (计时 >= 间隔时间)
        {
            计时 = 计时 - 间隔时间;

            要执行的东西();

        }
    }

    void 尝试射击() 
    {
        
            if (Input.GetButton("Fire1"))
            {
                GetComponent<AudioSource>().Play();
                打印实际射速();
            }

        

    }


    void 打印实际射速()
    {
        Debug.Log(Time.time - 射击发生的时间);
        射击发生的时间 = Time.time;
    }








    //async Task 射击() 
    //{

    //    //GetComponent<Light>().enabled = true;
    //    //await Task.Delay((int)(间隔多少毫秒*0.2f));
    //    //GetComponent<Light>().enabled = false;
    //    //打印实际射速();
    //}
    

}

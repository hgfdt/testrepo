using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class 角色射击 : MonoBehaviour
{
    public int 间隔多少毫秒;
    float 记录的时间;

    void Start()
    {
        尝试射击(); 
    }
    async Task 尝试射击() 
    {
        if (Input.GetButton("Fire1"))
        {
            射击();
        }
        
        

        
        

        await Task.Delay(间隔多少毫秒);
        尝试射击();

    }
    async Task 射击() 
    {
        GetComponent<AudioSource>().Play();
        GetComponent<Light>().enabled = true;
        await Task.Delay((int)(间隔多少毫秒*0.2f));
        GetComponent<Light>().enabled = false;
        打印实际射速();
    }
    void 打印实际射速()
    {
        Debug.Log(Time.time-记录的时间);
        记录的时间=Time.time;
    }

}

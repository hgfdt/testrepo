using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 相机跟随对象 : MonoBehaviour
{
    static GameObject 跟随的对象;
    //public Vector3 开始时对象到相机的矢量;
    public float 跟随速度 = 5;

    //GameObject byd;
    //GameObject 狗;
    private void Awake()
    {
        用于切换角色的脚本.切换角色事件 += 更新跟随的对象;
    }
    void Start()
    {
        
        //byd = GameObject.Find("byd");
        //狗 = GameObject.Find("狗");
        //byd.SetActive(false);

        //跟随的对象 = GameObject.FindWithTag("Player");
        //开始时对象到相机的矢量 = Vector3.zero/*transform.position-跟随的对象.transform.position*/;
    }

    void Update()
    {
        
        transform.position = Vector3.Lerp(transform.position, 跟随的对象.transform.position /*+ 开始时对象到相机的矢量*/,跟随速度*Time.deltaTime);
        
        //if (Input.GetKeyDown(KeyCode.T)) 
        //{
        //    切换角色();
        //}
    }
   

    public  void 更新跟随的对象(GameObject 新的跟随对象)
    {
        //byd.SetActive(!byd.activeSelf);
        //狗.SetActive(!狗.activeSelf);
        //跟随的对象 = GameObject.FindWithTag("Player");
        跟随的对象 = 新的跟随对象;
    }
}

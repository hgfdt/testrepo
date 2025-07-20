using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class 角色健康 : MonoBehaviour
{

    
    
    public int 血量 =100;
    public AudioClip 受伤声;
    public AudioClip 死亡声;
    

    
    
    AudioSource 声音组件;
    Animator 动画组件;
    Text 受伤显示;
    Text 血量显示;
    void Start()
    {
        声音组件 = GetComponent<AudioSource>();
        动画组件 = GetComponentInChildren<Animator>();
        受伤显示 = GameObject.Find("受伤显示").GetComponent<Text>();
        //血量显示 = GameObject.Find("血量显示").GetComponent<Text>();
    }

    
    
    

    private void Update()
    {
        受伤显示.color = Color.Lerp(受伤显示.color, Color.clear, 5f * Time.deltaTime);
        if (transform.position.y < -5)
        {
            死亡();
        }

    }

    public void 受伤(int 伤害)
    {
        

        声音组件.clip = 受伤声;
        声音组件.Play();

        动画组件.SetTrigger("受击");
        动画组件.SetTrigger("退出受击状态");

        受伤显示.color = Color.red;

        血量 -= 伤害;
        //血量显示.text=血量.ToString();

        if (血量 <= 0)
        {
            死亡();
        }
    }

    private void 死亡()
    {
        声音组件.clip = 死亡声;
        声音组件.Play();

        GetComponent<角色旋转>().enabled = false;
        GetComponent<角色移动>() .enabled = false;
        Invoke("停止动画",0.2f);
        //Invoke("重开", 2);
    }

    void 停止动画()
    {
        动画组件.enabled=false;
        Invoke("重开", 2);
    }
    void 重开()
    {
        血量 = 100;
        transform.position = Vector3.zero;
        GetComponent<角色旋转>().enabled = true;
        GetComponent<角色移动>().enabled = true;
        动画组件.enabled = true;
    }

}

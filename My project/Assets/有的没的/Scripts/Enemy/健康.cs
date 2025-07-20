using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class 健康 : MonoBehaviour
{
    CapsuleCollider 碰撞体组件;
    Animator 动画组件;
    AudioSource 声音组件;


    AudioClip 受伤声;
    public AudioClip 死亡声;
    public int 血量 = 100;
    public static int 分数;
    
    void Start()
    {
        声音组件 = GetComponent<AudioSource>();
        动画组件 = GetComponent<Animator>();
        碰撞体组件 = GetComponent<CapsuleCollider>();
    }

















    public void 受伤(int 伤害)
    {
        if (血量 <= 0)
        {
            return;
        }

        
        try 
        {
            声音组件.Play();
            动画组件.SetTrigger("受击");
            动画组件.SetTrigger("退出受击状态");
            血量 -= 伤害;
        } 
        catch 
        { 
        
        }
        
        if (血量<=0)
        {
            死亡();
        }
    }

    private void 死亡()
    {
        声音组件.clip = 死亡声;
        声音组件.Play();
       
        动画组件.SetTrigger("停止动画");
        Destroy(GetComponent<敌人攻击>());
        
        GetComponent<敌人移动>().enabled = false;
        GetComponent<NavMeshAgent>().enabled = false;

        分数 += 1;
        GameObject.Find("分数显示").GetComponent<Text>().text=分数.ToString();

        Invoke("移除组件", 10f);
    }


    void 移除组件()
    {
        //GetComponent<移除组件>().移除不需要的组件();
        Component[] 组件s = GetComponents<Component>();
        foreach (Component 组件 in 组件s)
        {
            if (组件 == this || 组件.GetType() == typeof(CapsuleCollider) || 组件.GetType() == typeof(Transform))
            {

            }
            else
            {
                Destroy(组件);
            }
        }
        Destroy(this);
    }
    public void StartSinking()
    {
        //if (血量 <= 0)
        //{
        //    碰撞体组件.isTrigger = true;
        //     Destroy(gameObject, 2f);
        //}

    }



}

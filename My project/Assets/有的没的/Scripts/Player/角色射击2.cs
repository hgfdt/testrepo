using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class 角色射击2 : MonoBehaviour
{
    public float 射击间隔;
    float 发生射击的时间;
    RaycastHit 射线碰撞点的信息;
    public int 伤害=10;
    void Start()
    {
        尝试射击(); 
    }
    void 尝试射击() 
    {
        if (true)//gameObject.activeInHierarchy
        {
            射击();
        }

        Invoke("尝试射击", 射击间隔);
    }
    void 射击() 
    {

        //打印实际射速();
      
         GetComponent<AudioSource>().Play();
        
        
        枪口发光();
        发出射线();
        Invoke("取消发光和射线", 射击间隔 * 0.5f);

    }
    void 打印实际射速()
    {
        Debug.Log(Time.time - 发生射击的时间);
        发生射击的时间 = Time.time;
    }
    void 枪口发光() 
    {
        GetComponent<ParticleSystem>().Play();
        GetComponent<Light>().enabled = true;
    }
    void 发出射线()
    {
        GetComponent<LineRenderer>().SetPosition(0, transform.position);
        if (Physics.Raycast(new Ray(transform.position, transform.forward), out  射线碰撞点的信息))
        {
            GetComponent<LineRenderer>().SetPosition(1, 射线碰撞点的信息.point);
            射线命中();
           
        }
        else
        {
            GetComponent<LineRenderer>().SetPosition(1, transform.position + transform.forward * 100);
        }
        GetComponent<LineRenderer>().enabled = true;
    }

    //public GameObject 角色;
    void 射线命中()
    {
        transform.Find("HitParticles").position=射线碰撞点的信息.point;
        transform.Find("HitParticles").GetComponent<ParticleSystem>().Play();
        
        
        

       

        if (射线碰撞点的信息.collider.TryGetComponent<健康>(out 健康 敌人健康))
        {
            敌人健康.受伤(伤害);
            
            //敌人健康.GetComponent<Rigidbody>().AddForceAtPosition(射线碰撞点的信息.point, ,);
            敌人健康.GetComponent<Rigidbody>().AddForce((射线碰撞点的信息.point - transform.position).normalized*10f, ForceMode.VelocityChange);
        }
    }
   
    void 取消发光和射线() 
    {
        GetComponent <Light>().enabled = false;
        GetComponent<LineRenderer>().enabled = false;
    }


    

}

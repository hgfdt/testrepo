using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class 狗控制器 : MonoBehaviour
{
    NavMeshAgent 寻路组件;
    狗攻击 狗攻击;
    void Awake()
    {
        寻路组件 = GetComponent<NavMeshAgent>();
        狗攻击 = GetComponent<狗攻击>();
    }
    //--------------------------------------------
    private void Start()
    {
        鼠标管理器.场景被点击 += 设置移动目的地;
        

    }
   
    void 设置移动目的地(Vector3 目的地)
    {
        狗攻击.停止追击目标();
        寻路组件.destination = 目的地;
    }


   



}

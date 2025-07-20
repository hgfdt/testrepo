using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;


public enum 敌人状态 { 守卫,巡逻,追击,死亡}
[RequireComponent(typeof(NavMeshAgent))]
public class 洋葱敌人控制器 : MonoBehaviour
{
    public 敌人状态 敌人状态;
    GameObject 攻击目标;
    float 追击速度;
    bool 走路;
    bool 战斗状态;
    bool 追玩家;
    [Header("基本设置")]
    public float 可视范围;
    public bool 是静止的;

    [Header("巡逻设置")]


    NavMeshAgent 寻路组件;
    Animator 动画组件;
    private void Awake()
    {
        寻路组件 = GetComponent<NavMeshAgent>();
        追击速度 = 寻路组件.speed;
        动画组件 = GetComponent<Animator>();
    }
    //------------------------------------------------------




    


    void Update()
    {
        切换状态();
        切换动画();
    }
    void 切换状态()
    {
        if (发现玩家())
        {
            敌人状态 = 敌人状态.追击;
        }

        switch (敌人状态)
        {
            case 敌人状态.守卫:
                break;
            case 敌人状态.巡逻:
                break;
            case 敌人状态.追击:

                走路 = false;
                战斗状态 = true;

                寻路组件.speed = 追击速度;
                if (发现玩家()==false)
                {
                    寻路组件.destination = transform.position;
                    追玩家 = false;
                }
                else
                {
                    追玩家 = true;
                    寻路组件.destination = 攻击目标.transform.position;
                }
                break;
            case 敌人状态.死亡:
                break;
        }
    }
    bool 发现玩家()
    {
        Collider[] 可视范围内的物体 = Physics.OverlapSphere(transform.position, 可视范围);
        foreach (Collider 物体 in 可视范围内的物体)
        {
            if (物体.CompareTag("Player"))
            {
                攻击目标 = 物体.gameObject;
                return true;
            }
        }
        攻击目标 = null;
        return false;
    }
    void 切换动画()
    {
        动画组件.SetBool("走路", 走路);
        动画组件.SetBool("战斗状态", 战斗状态);
        动画组件.SetBool("追玩家", 追玩家);

    }


}

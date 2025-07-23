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
    //[Header("基本设置")]
    public float 可视范围;
    public bool 是静止的;
    public float 停顿时间;
    float 停顿计时器;
    //[Header("巡逻设置")]
    public float 巡逻范围;
    Vector3 目的地;
    NavMeshAgent 寻路组件;
    Animator 动画组件;
    数据组件 数据组件;
    float 当前cd;
    bool 暴击了;
    private void Awake()
    {
        寻路组件 = GetComponent<NavMeshAgent>();
        追击速度 = 寻路组件.speed;
        动画组件 = GetComponent<Animator>();
        数据组件 = GetComponent<数据组件>();
    }
    //------------------------------------------------------
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    void Update()
    {
        切换状态();
        切换动画();
        当前cd-=Time.deltaTime;
    }
    
    
    







    
    
    
    private void Start()
    {
        if (是静止的)
        {
            敌人状态 = 敌人状态.守卫;
        }
        else
        {
            敌人状态 = 敌人状态.巡逻;
            目的地=transform.position;
        }
    }
    void 切换状态()
    {
        switch (敌人状态)
        {
            case 敌人状态.守卫:
                if (发现玩家())
                {
                    敌人状态 = 敌人状态.追击;
                }

                break;
            case 敌人状态.巡逻:
               
                if (Vector3.Distance(transform.position,目的地)<=1)
                {
                    走路 = false;
                    if (停顿计时器 > 0)
                    {
                        停顿计时器 -= Time.deltaTime;
                    }
                    else
                    {
                        停顿计时器 = 停顿时间;
                        目的地 = 获取范围内的随机点(目的地, 巡逻范围);
                        
                    }
                }
                else
                {
                    战斗状态 = false;
                    寻路组件.speed = 追击速度 * 0.5f;
                    走路 = true;
                    寻路组件.destination = 目的地;

                }
                if (发现玩家())
                {
                    敌人状态 = 敌人状态.追击;
                }
                break;
            case 敌人状态.追击:

                
                if (发现玩家()==false)
                {
                    
                    追玩家 = false;
                    if (停顿计时器 > 0)
                    {
                        寻路组件.destination = transform.position;
                        停顿计时器 -= Time.deltaTime;
                    }
                    else if(是静止的)
                    {
                        敌人状态 = 敌人状态.守卫;
                        停顿计时器 = 停顿时间;
                    }
                    else
                    {
                        敌人状态 = 敌人状态.巡逻;
                        停顿计时器 = 停顿时间;
                    }
                }
                else
                {
                    走路 = false;
                    战斗状态 = true;
                    寻路组件.speed = 追击速度;
                    追玩家 = true;
                    //寻路组件.isStopped = false;
                    寻路组件.destination = 攻击目标.transform.position;
                }
                if (玩家在近战攻击范围内()||玩家在远程攻击范围内())
                {
                    //追玩家 = false;
                    //寻路组件.isStopped = true;
                    if (当前cd<0)
                    {
                        当前cd = 数据组件.攻击数据.cd冷却时间;

                        
                        攻击();
                    }
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
    bool 玩家在近战攻击范围内()
    {
        return 攻击目标 != null && Vector3.Distance(transform.position, 攻击目标.transform.position) <= 数据组件.攻击数据.近战攻击距离;
    }
    bool 玩家在远程攻击范围内()
    {
        return 攻击目标 != null && Vector3.Distance(transform.position, 攻击目标.transform.position) <= 数据组件.攻击数据.远程攻击距离;
    }
    void 攻击()
    {   
        transform.LookAt(攻击目标.transform.position);
        
        暴击了 = Random.value < 数据组件.攻击数据.暴击几率;
        动画组件.SetBool("暴击了", 暴击了);
        if (玩家在近战攻击范围内())
        {
            动画组件.SetTrigger("攻击");
        }
        if (玩家在远程攻击范围内())
        {
            动画组件.SetTrigger("攻击");
        }
    }
    Vector3 获取范围内的随机点(Vector3 中心, float 范围)
    {
        float 随机点x = Random.Range(中心.x - 范围, 中心.x + 范围);
        float 随机点z = Random.Range(中心.z - 范围, 中心.z + 范围);
        Vector3 随机点 = new Vector3(随机点x, 中心.y, 随机点z);
        //NavMeshHit 可以到达的随机点;
        //Vector3 最终输出 = NavMesh.SamplePosition(随机点, out 可以到达的随机点, 范围, 1) ? 可以到达的随机点.position : transform.position;
        //return 最终输出;
        if (NavMesh.SamplePosition(随机点,out NavMeshHit hit,0,1))
        {
            return 随机点;
        }
        else
        {
            停顿计时器 = 0;
            return transform.position;
        }
    }


















    void 切换动画()
    {
        动画组件.SetBool("走路", 走路);
        动画组件.SetBool("战斗状态", 战斗状态);
        动画组件.SetBool("追玩家", 追玩家);

    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position,可视范围);
        
    }





   
   
}

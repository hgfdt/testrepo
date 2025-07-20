using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class 狗攻击 : MonoBehaviour
{
    NavMeshAgent 寻路组件;
    Animator 动画组件;
    private void Awake()
    {
        寻路组件 = GetComponent<NavMeshAgent>();
        动画组件 = GetComponent<Animator>();
    }
    //--------------------------------------------------







    GameObject 攻击目标;
    float 攻击CD;
    void Start()
    {
        鼠标管理器.洋葱被点击 += 攻击洋葱;
    }
    void 攻击洋葱(GameObject 目标)
    {
        停止追击目标();
        攻击目标 = 目标;
        StartCoroutine(追击目标());
    }
    IEnumerator 追击目标()
    {
        //寻路组件.isStopped = false;
        //transform.LookAt(攻击目标.transform.position);

        while (Vector3.Distance(transform.position, 攻击目标.transform.position) > 1)
        {
            寻路组件.destination = 攻击目标.transform.position;
            yield return null;
        }

        //寻路组件.isStopped = true;
        //if (攻击CD < 0)
        //{
            动画组件.SetTrigger("攻击");
        //    攻击CD = 0.5f;
        //}
    }
    public void 停止追击目标()
    {
        StopAllCoroutines();
    }



}

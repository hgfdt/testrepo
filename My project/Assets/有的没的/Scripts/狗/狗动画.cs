using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class 狗动画 : MonoBehaviour
{
    Animator 动画组件;
    NavMeshAgent 寻路组件;



    private void Awake()
    {
        动画组件 = GetComponent<Animator>();
        寻路组件 = GetComponent<NavMeshAgent>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        切换动画();
    }
    void 切换动画()
    {
        动画组件.SetFloat("速度", 寻路组件.velocity.sqrMagnitude);

    }
}

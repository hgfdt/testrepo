using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 敌人攻击 : MonoBehaviour
{








    public GameObject 攻击对象;
    public int 伤害;

    void Start()
        {
        攻击对象 = GameObject.FindGameObjectWithTag("Player");
        }


    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject == 攻击对象)
        {
            攻击对象.GetComponent<角色健康>().受伤(伤害);
            攻击对象.GetComponent<Rigidbody>().AddForce((攻击对象.transform.position - (transform.position+new Vector3(0,0.1f,0))).normalized * 10f, ForceMode.VelocityChange);
        }
    }
   
    

    // Update is called once per frame
    void Update()
    {
        
    }
}

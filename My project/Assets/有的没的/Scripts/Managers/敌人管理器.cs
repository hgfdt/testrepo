using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 敌人管理器 : MonoBehaviour
{

    public GameObject 敌人;
    float time=3;


    // Start is called before the first frame update
    void Start()
    {
        生成敌人();
    }

    // Update is called once per frame
    void Update()
    {
       
            
    }
    void 生成敌人()
    {
        
        Instantiate(敌人,transform);

        Invoke("生成敌人", time);
    }


}

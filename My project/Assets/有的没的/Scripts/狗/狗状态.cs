using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 狗状态 : MonoBehaviour
{
    数据组件 状态组件;
    private void Awake()
    {
        状态组件 = GetComponent<数据组件>();
    }



    // Start is called before the first frame update
    void Start()
    {
        状态组件.当前血量 = 2;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

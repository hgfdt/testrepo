using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class 用于切换角色的脚本 : MonoBehaviour
{
    public GameObject[] 角色s;
    public int 当前角色编号=0;
    public static Action<GameObject> 切换角色事件;
    private void Start()
    {
        foreach (GameObject 角色 in 角色s)
        {
            角色.SetActive(false);
        }
        角色s[当前角色编号].SetActive(true);

        切换角色事件?.Invoke(角色s[当前角色编号]);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            切换角色();
        }
    }
    private void 切换角色()
    {
        角色s[当前角色编号].SetActive(false);
        if (当前角色编号==角色s.Length-1)
        {
            当前角色编号 = 0;
        }
        else
        {
            当前角色编号 += 1;
        }
        角色s[当前角色编号].SetActive(true );

        切换角色事件?.Invoke(角色s[当前角色编号]);
    }
}

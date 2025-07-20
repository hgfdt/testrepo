using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 虚拟鼠标 : MonoBehaviour
{
    RectTransform 虚拟鼠标transform;

    public static Vector3 虚拟鼠标的屏幕位置;
    public  float 虚拟鼠标灵敏度=10;
    
    private void Awake()
    {
        虚拟鼠标transform = GetComponent<RectTransform>();
        Cursor.visible=false;
    }

    void Update()
    {
        虚拟鼠标的移动();
       到达边缘时从另一边缘进入();
        虚拟鼠标transform.position = 虚拟鼠标的屏幕位置;
    }
    void 虚拟鼠标的移动()
    {
        虚拟鼠标的屏幕位置.x += Input.GetAxis("Mouse X")*虚拟鼠标灵敏度;
        虚拟鼠标的屏幕位置.y += Input.GetAxis("Mouse Y")*虚拟鼠标灵敏度;

        虚拟鼠标的屏幕位置.x = Mathf.Clamp(虚拟鼠标的屏幕位置.x, 0, Screen.width);
        虚拟鼠标的屏幕位置.y = Mathf.Clamp(虚拟鼠标的屏幕位置.y, 0, Screen.height);
    }
    void 到达边缘时从另一边缘进入() 
    {
        if (虚拟鼠标的屏幕位置.x == Screen.width)
        {
            虚拟鼠标的屏幕位置.x = 0;
        }
        else if (虚拟鼠标的屏幕位置.x == 0) 
        { 
            虚拟鼠标的屏幕位置.x=Screen.width;
        }
    }
    
    
  
}

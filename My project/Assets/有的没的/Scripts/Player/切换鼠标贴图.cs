using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class 切换鼠标贴图的组件 : MonoBehaviour
{
    RawImage 图片UI组件;
    public Texture2D point, doorway, 攻击, target, arrow,默认;

    private void Awake()
    {
       图片UI组件=GetComponent<RawImage>();
    }

    private void 切换鼠标贴图()
    {
        if (Physics.Raycast(Camera.main.ScreenPointToRay(虚拟鼠标.虚拟鼠标的屏幕位置),out RaycastHit 命中点))
        {
            
            switch (命中点.collider.gameObject.tag)
            {
                case "洋葱":
                    //图片UI组件.enabled = true;
                    图片UI组件.texture = 攻击;
                    break;
                default:
                    //图片UI组件.enabled = false;
                    图片UI组件.texture = 默认;
                    break;

            }
        }
    }
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        切换鼠标贴图();
    }
}

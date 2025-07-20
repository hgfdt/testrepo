using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class 聚焦 : MonoBehaviour
{
    public Volume 后处理组件;
    DepthOfField 景深;


    // Start is called before the first frame update
    void Start()
    {
        后处理组件.profile.TryGet(out 景深);
    }

    // Update is called once per frame
    void Update()
    {
        Ray 准心发出的射线 = Camera.main.ScreenPointToRay(虚拟鼠标.虚拟鼠标的屏幕位置);
        if (Physics.Raycast(准心发出的射线,out RaycastHit 射线击中点))
        {
            float 距离 =Vector3.Distance(Camera.main.transform.position,射线击中点.point);
            //Debug.Log(距离.ToString());
            景深.focusDistance.value =Mathf.Lerp(景深.focusDistance.value,距离,5*Time.deltaTime) ;
        }
    }
}

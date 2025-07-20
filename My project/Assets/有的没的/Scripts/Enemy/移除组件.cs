using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 移除组件 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void 移除不需要的组件()
    {
        Component[] 组件s = GetComponents<Component>();
        foreach (Component 组件 in 组件s)
        {
            if (组件 == this || 组件.GetType() == typeof(CapsuleCollider) || 组件.GetType() == typeof(Transform)|| 组件.GetType() == typeof(AudioSource))
            {

            }
            else
            {
                Destroy(组件);
            }
        }
        Destroy(GetComponent<AudioSource>());
        Destroy(this);
    }
}

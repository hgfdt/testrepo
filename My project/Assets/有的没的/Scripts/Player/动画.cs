using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 动画 : MonoBehaviour
{
   

    
    void Update()
    {
        //,0, 
        
        GetComponent<Animator>().SetBool("走路", Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0);
        

    }
}

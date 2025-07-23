using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 数据组件 : MonoBehaviour
{
    #region get/set 基本数据
    public 基本数据_SO 基本数据;
    public int 最大血量 
    {
        get
        {
            if (基本数据 != null)
                return 基本数据.最大血量;
            else return 0;
        }
        set
        {
            基本数据.最大血量 = value;
        }
    }
    public int 当前血量
    {
        get
        {
            if (基本数据 != null)
                return 基本数据.当前血量;
            else return 0;
        }
        set
        {
            基本数据.当前血量 = value;
        }
    }
    public int 基础防御
    {
        get
        {
            if (基本数据 != null)
                return 基本数据.基础防御;
            else return 0;
        }
        set
        {
            基本数据.基础防御 = value;
        }
    }
    public int 当前防御
    {
        get
        {
            if (基本数据 != null)
                return 基本数据.当前防御;
            else return 0;
        }
        set
        {
            基本数据.当前防御 = value;
        }
    }
    #endregion
    #region get/set 攻击数据
    public 攻击数据_SO 攻击数据;
    [HideInInspector]
    public bool 暴击了;
    #endregion
}

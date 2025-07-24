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

    void 造成伤害(数据组件 攻击者,数据组件 受伤者)
    {
        int 最终伤害 = 攻击者.核心伤害() - 受伤者.当前防御;
        受伤者.当前血量 -= 最终伤害;

        //TODO:ui
        //todo:加经验值
        
    }
    int 核心伤害()
    {
        float 核心伤害= Mathf.Max(Random.Range(攻击数据.最小伤害, 攻击数据.最大伤害),0);
        if (暴击了)
        {
            核心伤害 *= 攻击数据.暴击乘数;
            Debug.Log("暴击" + 核心伤害);
        }
        return (int)核心伤害;
    }
    #endregion
}

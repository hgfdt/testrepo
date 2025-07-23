using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName ="new data",menuName ="状态数据")]
public class 基本数据_SO : ScriptableObject
{
    [Header("哈信息")]
    public int 最大血量;
    public int 当前血量;
    public int 基础防御;
    public int 当前防御;
}

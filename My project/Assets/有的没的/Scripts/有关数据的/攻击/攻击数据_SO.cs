using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="攻击数据")]
public class 攻击数据_SO : ScriptableObject
{
    public float 近战攻击距离;
    public float 远程攻击距离;
    public float cd冷却时间;
    public int 最小伤害;
    public int 最大伤害;
    public float 暴击乘数;
    public float 暴击几率;
}

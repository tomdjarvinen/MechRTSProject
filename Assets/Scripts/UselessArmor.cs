using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UselessArmor : IArmor
{
    public float BlockDamage(float damage, int damageType)
    {
        return damage;
    }

}

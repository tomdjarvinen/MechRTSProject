using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ArmoredMortal : Mortal, IArmoredMortal
{
    public override float ApplyDamage(float damage, int damageType){
        float discountedDamage = GetArmor().BlockDamage(damage,damageType);
        return base.ApplyDamage(discountedDamage, damageType);
    }

    public abstract IArmor GetArmor();
}



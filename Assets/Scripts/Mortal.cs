using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Mortal : MonoBehaviour, IMortal
{
    private float health;
    void Awake(){
        Debug.Log("Health1: " + health);
        health = GetMaxHealth();
        Debug.Log("Health2: " + health);
    }

    public float GetHealth()
    {
        return health;
    }

    public abstract float GetMaxHealth();

    public float IncrementHealth(float ammount)
    {
        return SetHealth(GetHealth()+ammount);
    }

    public virtual float SetHealth(float healthVal)
    {
        return (health = Mathf.Clamp(healthVal,0,GetMaxHealth()));
    }

    public virtual float ApplyDamage(float damage, int damageType)
    {
        return IncrementHealth(-damage);
    }
}

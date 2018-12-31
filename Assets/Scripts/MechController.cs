using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MechController : ArmoredMortal
{
    public string healthBarName = "HealthBar";
    public string verticalAxis = "Vertical";
    public string horizontalAxis = "Horizontal";
    Animator animator;
    private IArmor  uselessArmor = new UselessArmor();
    private float maxHealth = 100;
    private GameObject healthBar;
    public override float SetHealth(float health)
    {

        float healthNew = base.SetHealth(health);
        if (healthBar!= null)
        {
            float percent = healthNew/GetMaxHealth();
            healthBar.SendMessage("SetHealth",percent);
            Debug.Log("Health: "+ health + ";healthNew: " + healthNew + ";Percent: " + percent);

        }
        return healthNew;
    }
    public override IArmor GetArmor()
    {
        return uselessArmor;
    }

    public override float GetMaxHealth()
    {
        return maxHealth;
    }

    // Start is called before the first frame update
    void Awake()
    {
        animator = GetComponent<Animator>();
        Transform healthMama = GetComponent<Transform>().Find(healthBarName);
        if (healthMama != null)
        {
            healthBar = healthMama.gameObject;
        }
    }

    // Update is called once per frame
    void Update()
    {
        float v = Input.GetAxis(verticalAxis);
        float h = Input.GetAxis(horizontalAxis);
        animator.SetBool("Move Pressed",(v!=0 || h!=0));
    }
}

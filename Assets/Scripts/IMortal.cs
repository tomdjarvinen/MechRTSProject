public interface IMortal
{
   float GetHealth();
   float SetHealth(float healthVal);
   float GetMaxHealth();
   float IncrementHealth(float ammount);
   float ApplyDamage(float damage, int damageType);

}
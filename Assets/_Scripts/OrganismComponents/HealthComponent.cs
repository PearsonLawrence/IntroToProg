using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthComponent : MonoBehaviour {
    
    public float MaxHealth = 100;
    public float CurrentHealth;

    public bool CanRegenHealth = false;
    public float HealthRegenSpeed = 2.0f;
    public float SetHealthRegenDelay = 5;
    private float CurrentHealthRegenDelay;

    float DT;
	// Use this for initialization
	void Start () {
        CurrentHealth = MaxHealth;
	}
	
    public void TakeDamage(float DamageAmount)
    {
        CurrentHealth -= DamageAmount;
        CurrentHealthRegenDelay = SetHealthRegenDelay;

        if (CurrentHealth <= 0)
            Destroy(gameObject);
    }

    public void Heal(float Amount)
    {
        CurrentHealth += Amount;
    }
    
    public void ManageHealthRegen()
    {
        
        if (CurrentHealth < MaxHealth && CanRegenHealth == true 
            && CurrentHealthRegenDelay <= 0)
        {
            Heal(DT * HealthRegenSpeed);
        }
    }
	// Update is called once per frame
	void Update () {

        DT = Time.deltaTime;
        CurrentHealthRegenDelay -= DT;
        
        ManageHealthRegen();
	}
}

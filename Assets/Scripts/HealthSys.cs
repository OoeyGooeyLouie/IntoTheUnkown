using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class HealthSys : MonoBehaviour
{
    public float maxHealth;
    public float CurrentHealth;
    public float damage;
     bool playerDead;

    //refernces
    public Hud hud;
    void Start()
    {
        CurrentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        //TODO: change to when enemy collides or something
        //what happens when player gets damaged
        if (Keyboard.current.hKey.wasPressedThisFrame)
        {
            DamagePlayer(damage);
        }

        if (playerDead)
        {
            hud.PlayerDeath();
        }
        
    }

    public void DamagePlayer(float power)
    {
        CurrentHealth -= power;
            CurrentHealth = Mathf.Clamp(CurrentHealth, 0, maxHealth);
            hud.updateHealth(CurrentHealth/maxHealth);
            if(CurrentHealth <= 0)
            {
                playerDead = true;
                hud.PlayerDeath();
            }
    }

    public void HealPlayer(float Health)
    {
        CurrentHealth += Health;
        CurrentHealth = Mathf.Clamp(CurrentHealth, 0, maxHealth);
        hud.updateHealth(CurrentHealth/maxHealth);
    }

    public bool isDead()
    {
        return playerDead;
    }

    public void setDeath()
    {
        playerDead = true;
        
    }

}

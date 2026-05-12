using StarterAssets;
using Unity.Mathematics;
using UnityEngine;

public class RewardMode : MonoBehaviour
{
   public GameObject meteor;
   public float HealthBoost;
   public float increaseSpeed;
   public int GiveAmmoAmount;
   public int JumpHeight;
   public int damageBoost;
   private bool hasKey;
   private GameObject Player;
   private HealthSys PlayerHealth;
   private GunSys PlayerGun;
   private FirstPersonController PlayerMovement;

    void Awake()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        PlayerHealth = Player.transform.Find("HealthSystem").GetComponent<HealthSys>();
        HealthBoost = 25f;
        GiveAmmoAmount = 60;
        hasKey = false;
        PlayerGun = Player.transform.Find("PlayerCameraRoot").transform.Find("Main Camera").GetComponent<GunSys>();

    }
    private void OnTriggerEnter(Collider other) //detects what item player has collided with
    {
        if (other.CompareTag("Player"))
        {
            if (CompareTag("Health"))
            {
                

                if(PlayerHealth.CurrentHealth == PlayerHealth.maxHealth)
                {
                    Debug.Log("At full Health");
                    Destroy(transform.gameObject);
                }
                else{

                PlayerHealth.HealPlayer(HealthBoost);
                //Debug.Log("Picked up Health");
                Destroy(transform.gameObject);
                }
            }
        }
        if (CompareTag("Ammo"))
        {
            //PlayerGun = Player.transform.Find("PlayerCameraRoot").transform.Find("Main Camera").GetComponent<GunSys>();
                PlayerGun.getAmmo(GiveAmmoAmount);
                Destroy(transform.gameObject);
                Debug.Log("Picked up ammo");
        }

        if (CompareTag("Speed"))
        {
            PlayerMovement = Player.GetComponent<FirstPersonController>();
            PlayerMovement.MoveSpeed += increaseSpeed;
            PlayerMovement.SprintSpeed += increaseSpeed;
            Destroy(transform.gameObject);
            Debug.Log("Speed power up obtained");
        }    

        if (CompareTag("Jump"))
        {
            PlayerGun.damage += 15;
            Destroy(transform.gameObject);
            Debug.Log("Speed power up obtained");
        }
        if (CompareTag("Key"))
        {
            hasKey = true;
            GameObject UI = GameObject.Find("GameCanvas");
            Hud hud = UI.GetComponent<Hud>();
            hud.getKey("Yellow");
            Destroy(transform.gameObject);

        }
       
        if (CompareTag("Death"))
        {
            PlayerHealth.setDeath();
        }
         Debug.Log("hit: " + this.tag);
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void spawnMeteor(GameObject meteor)
    {
        Instantiate(meteor, transform.position, quaternion.identity);
        Destroy(meteor, 5f);
    }
}

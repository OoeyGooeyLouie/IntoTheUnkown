using UnityEngine;

public class DamageTrigger : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    GameObject player;
    HealthSys playerHealth;
    public float damage = 15;

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.transform.Find("HealthSystem").GetComponent<HealthSys>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerHealth.DamagePlayer(damage);
        }
    }
}

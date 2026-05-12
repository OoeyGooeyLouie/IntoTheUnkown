using UnityEngine;

public class Combat : MonoBehaviour
{
    public BossMovement movement;
    public BossAttacks attacks;
    public Animator anim;
    private Transform playerPos;
    //Timers
    private float CoolDowntimer = 0f;
    public float AttackCoolDown = 3f;
    public float stompAttackTimer = 0f;
    [Range(0,50)] [SerializeField] float attackRange = 5, stompRange = 3;
    void Start()
    {
        playerPos = FindFirstObjectByType<HealthSys>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        playerPos = FindFirstObjectByType<HealthSys>().transform;
        float distanceFromPlayer = Vector3.Distance(playerPos.position, this.transform.position); // distance between player and enemy 

        if (distanceFromPlayer > attackRange)
        {
            movement.chasePlayer(true);
        }
        else //player within attack range
        {
            movement.chasePlayer(false);
            if (!attacks.isAttacking)//only face player if not attacking
            {
                movement.facePlayer(true);
            }
            if(CoolDowntimer > 0f)//attack cool down timer
            {
                CoolDowntimer -= Time.deltaTime;
            }
            if(CoolDowntimer <= 0){//cool down complete
                movement.facePlayer(false);
                anim.SetBool("isAttacking", true);
                
                if(stompAttackTimer < 1)//timer to delay actualk attack until right attack animation complete
                {
                    stompAttackTimer += Time.deltaTime;
                }
                else{//attack animation complete, proceed with attack
                    StartCoroutine(attacks.stompAttack());
                    CoolDowntimer = AttackCoolDown;
                    stompAttackTimer = 0f;
                    anim.SetBool("isAttacking", false);
            }
            }

        }
    }

        private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(this.transform.position, stompRange);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(this.transform.position, attackRange);
    }
}

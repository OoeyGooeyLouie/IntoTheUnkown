using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;

public class BossMovement : MonoBehaviour
{

    public Animator anim;
    public NavMeshAgent thisEnemy;
    private Transform playerPos;
    public BossAttacks EnemyAttacks;
    private float timer = 0f;
    public float AttackCoolDown = 3f;

    [Range(0,50)] [SerializeField] float attackRange = 5;
    void Start()
    {
        thisEnemy = GetComponent<NavMeshAgent>();
        playerPos = FindFirstObjectByType<HealthSys>().transform;
        
    }

    // Update is called once per frame
    void Update()
    {

    }


    public void chasePlayer(bool chase)
    {
        //thisEnemy.SetDestination(playerPos.position);
        if(chase){
            facePlayer(true);
            anim.SetBool("isWalking", chase);
        

        }
        else
        {
            anim.SetBool("isWalking", chase);
        }
    }
    public void facePlayer(bool facing)
    {
        if(facing){
        Vector3 direction = playerPos.position - transform.position;
            direction.y = 0f;

        if (direction != Vector3.zero){
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 5f);
        }
    }
    }

}

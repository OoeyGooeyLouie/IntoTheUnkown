using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;

public class BossHealthSystem : MonoBehaviour
{
    public float maxHealth;
    private float currHealth;
    bool isDead;
    public NavAgentAnim anim;
    private NavMeshAgent thisEnemy;
    private GameObject GameCanvas;
    private Hud GameCanvasHud;
    private float timer = 0f;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        thisEnemy = GetComponent<NavMeshAgent>();//boss ai pathing brain
        isDead = false;
        currHealth = maxHealth;
        GameCanvas = GameObject.FindGameObjectWithTag("GameCanvas");
        GameCanvasHud = GameCanvas.GetComponent<Hud>();
    }

    // Update is called once per frame
    void Update()
    {
        //TESTING
        // if (Keyboard.current.lKey.wasPressedThisFrame)
        // {
        //     //anim.SetBool("isWalking", true);
        // }
        // if (Keyboard.current.kKey.wasPressedThisFrame)
        // {
        //     damage(1000);
        // }
        if(isDead)
        {
            //death animation here
            
            thisEnemy.isStopped = true;
            thisEnemy.updatePosition = false;
            thisEnemy.updateRotation = false;
            anim.SetBool("isDead", true);
            if(timer < 3f)
            {
                timer += Time.deltaTime;
            }
            else{
            GameCanvasHud.PlayerWin();}
        }
    }

    public void damage(float hitPoints)
    {
        currHealth -= hitPoints; 
        currHealth = Mathf.Clamp(currHealth, 0, maxHealth);
        GameCanvasHud.updateBrogmarHealth(currHealth/maxHealth);
        if(currHealth <= 0)
        {
            isDead = true;
        }
        Debug.Log(currHealth);
    }
    public void killBoss()
    {
        currHealth = 0;
        Debug.Log("Boss is dead");
    }

}

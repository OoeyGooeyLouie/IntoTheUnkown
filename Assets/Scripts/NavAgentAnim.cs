using UnityEngine;
using UnityEngine.AI;

public class NavAgentAnim : MonoBehaviour
{
    public NavMeshAgent agent;
    Animator anim;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetFloat("Speed", agent.velocity.magnitude);
    }

    public void SetBool(string myBool, bool state)
    {
        anim.SetBool(myBool, state);
    }

    // public bool getAttacking()
    // {
    //     return anim.GetParameter(1);
    // }
}

using System.Collections;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;

public class BossAttacks : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    
    [Header("Spawn Settings")]
    public GameObject RockSpike;
    public int count = 10;
    public float spacing = 2f;
    public float startDistance = 5f;
    public float spawnDepth = 5f;
    public float SpawnLateral = 5f;
    public float delayBetweenSpawns = 0.1f;

    [Header("Movement Settings")]
    public float riseSpeed = 25f;
    public float stopHeight = 2f;
    public float destroyAfter = 5f;
    private float attackTimier;
    public bool isAttacking;

    public NavAgentAnim anim;
    private Vector3 startPoint;



    void Start()
    {
        Vector3 startpoint = new Vector3(startDistance,0f,SpawnLateral);
    }

    // Update is called once per frame
    void Update()
    {
        // if (Keyboard.current.tKey.wasPressedThisFrame)
        // {
        //     StartCoroutine(stompAttack());

        // }
    }

    public IEnumerator stompAttack()
    {
        //anim.SetBool("isAttacking", true);


        //Vector3 localOffset = new Vector3(0f, 0f, 0f);
        isAttacking = true;

    for (int i = 0; i < count; i++)
    {
        Vector3 localOffset = new Vector3(SpawnLateral, spawnDepth, startDistance + i * spacing);
        Vector3 pos = transform.TransformPoint(localOffset);

        pos.y -= spawnDepth; 

        GameObject spike = Instantiate(RockSpike, pos, Quaternion.identity);

        StartCoroutine(RiseAndStop(spike));

        yield return new WaitForSeconds(delayBetweenSpawns);
    }

    //anim.SetBool("isAttacking", false);
    isAttacking = false;
        yield break;
    }

    IEnumerator RiseAndStop(GameObject obj)
    {
        float timer = 0f;
        while(obj != null)
        {
            if(obj.transform.position.y < stopHeight)
            {
                obj.transform.position += Vector3.up * riseSpeed * Time.deltaTime;
            }
            timer += Time.deltaTime;

            if(timer >= destroyAfter)
            {
                Destroy(obj);
                yield break;
            }
            yield return null;
        }
    }

}

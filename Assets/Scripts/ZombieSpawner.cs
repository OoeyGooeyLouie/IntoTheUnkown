using UnityEngine;

public class Spawns : MonoBehaviour
{

    public GameObject Zombie1, Zombie2, Zombie3, Zombie4, Zombie5;
    private BoxCollider SpawnZone;
    [Range(0,50)] [SerializeField] float SpawnRange = 5;
    public int PatrolSize = 5;
    private GameObject Player;
    private float distance;
    private int spawnCount = 0;
   void Awake() {
    if (SpawnZone == null)
        SpawnZone = GetComponent<BoxCollider>();

    if (SpawnZone == null)
        Debug.LogError("No BoxCollider on this GameObject!");
}
    void Start()
    {
        //SpawnPatrol();
        Player = GameObject.FindGameObjectWithTag("Player");
        if(Player != null)
        {
            distance = Vector3.Distance(SpawnZone.transform.position, Player.transform.position);
            //Debug.Log(distance);
        }
        else
        {
            Debug.LogError("No object of Player Exists in scene");
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        //TODO: add spawn at certain distance from player
        distance = Vector3.Distance(SpawnZone.transform.position, Player.transform.position);//checks how far player is from zone
        if (distance <= SpawnRange && spawnCount < 1) //will spawn patrol if player goes into spawn boundary
        {
            SpawnPatrol();
            spawnCount++;
        }
    }

    private void SpawnPatrol()
    {
        
        for (int i = 0; i < PatrolSize; ++i)
        {
            
            SpawnZombies();
        }
    }

    private Vector3 randomSpawn(BoxCollider box)
    {
        Vector3 localPoint = new Vector3(
            Random.Range(-0.5f, 0.5f),
            0f,
            Random.Range(-0.5f, 0.5f)
        );
 
        // Convert local to world position, considering rotation & center
        return box.transform.TransformPoint(Vector3.Scale(localPoint, box.size) + box.center);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(this.transform.position, SpawnRange);
    }
    public void SpawnZombies()
    {
        if(Zombie1 != null){
            Instantiate(Zombie1, randomSpawn(SpawnZone), Quaternion.identity);}
        if(Zombie2 != null){
            Instantiate(Zombie2, randomSpawn(SpawnZone), Quaternion.identity);}
        if(Zombie3 != null){
            Instantiate(Zombie3, randomSpawn(SpawnZone), Quaternion.identity);}
        if(Zombie4 != null){
            Instantiate(Zombie4, randomSpawn(SpawnZone), Quaternion.identity);}
        if(Zombie5 != null){
            Instantiate(Zombie5, randomSpawn(SpawnZone), Quaternion.identity);}
    }
}

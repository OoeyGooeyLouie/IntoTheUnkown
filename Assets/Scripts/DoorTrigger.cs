using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    public bool isLocked;
    public DoorManager door;
    private Hud GameUI;
    private GameObject GameCanvas;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameCanvas = GameObject.FindGameObjectWithTag("GameCanvas");
        GameUI = GameCanvas.GetComponent<Hud>();
    }
    void Update()
    {
        if(GameUI.collectKeys == GameUI.numKeys && GameUI.numKeys > 0)
        {
            isLocked = false;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (isLocked)
        {
            Debug.Log("this door is locked, go find the keys");
        }
        else{


        if (other.CompareTag("Player"))
        {
            door.OpenDoor();
        }
        }
        
    }
}

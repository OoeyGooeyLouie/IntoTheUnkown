using UnityEngine;

public class DoorManager : MonoBehaviour
{
    public float openAngle = 90f;
    public float openSpeed = 2f;
    public float closeDelay = 3f;

    private bool isOpening = false;
    private bool isClosing = false;

    private float timer = 0f;
    public GameObject particles;
    public Hud GameHud;

    private Quaternion closedRotation;
    private Quaternion openRotation;

    void Start()
    {
        closedRotation = transform.rotation;
        openRotation = Quaternion.Euler(0, openAngle, 0) * closedRotation;
        if(particles != null)
        {
            particles.SetActive(false);
        }
    }

    void Update()
    {
        // Opening
        if (isOpening)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, openRotation, Time.deltaTime * openSpeed);

            // Check if close enough to open position
            if (Quaternion.Angle(transform.rotation, openRotation) < 1f)
            {
                isOpening = false;
                timer = closeDelay; // start countdown
            }
        }

        // Countdown to close
        if (timer > 0)
        {
            timer -= Time.deltaTime;

            if (timer <= 0)
            {
                isClosing = true;
            }
        }

        // Closing
        if (isClosing)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, closedRotation, Time.deltaTime * openSpeed);

            if (Quaternion.Angle(transform.rotation, closedRotation) < 1f)
            {
                isClosing = false;
            }
        }
        if(particles != null && GameHud != null)
        {
            if(GameHud.allKeysCollected){
            particles.SetActive(true);}
        }
    }

    public void OpenDoor()
    {
        isOpening = true;
        isClosing = false; // stop closing if triggered again
    }
}
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DoorLogic : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Hud hud;
    public GameObject DoorUI;
    public GameObject particles;
    [SerializeField] TextMeshProUGUI keyText;
    [SerializeField] Image KeyImg;

    
    void Start()
    {
        DoorUI.SetActive(false);
        keyText.enabled = false;
        KeyImg.enabled = false;
        particles.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(DoorUI.activeSelf && Keyboard.current.eKey.wasPressedThisFrame)
        {
            if (hud.hasYKey)
                {
                    SceneManager.LoadScene("Level 2");
                }
            else
            {
                keyText.enabled = true;
                KeyImg.enabled = true;
            }
        }
        if (hud.allKeysCollected)
        {
            particles.SetActive(true);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            DoorUI.SetActive(true);            
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            keyText.enabled = false;
            KeyImg.enabled = false;
            DoorUI.SetActive(false);
        }
    }

}

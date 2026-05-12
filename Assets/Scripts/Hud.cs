using JetBrains.Annotations;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Hud : MonoBehaviour
{
    
    public string clipSize = "0/0";
    //bool empty = true;
    //public int ammo = 0;

    public TextMeshProUGUI Ammo;
    public TextMeshProUGUI Healthnum;
    public TextMeshProUGUI ObjTxt;
    public TextMeshProUGUI esc;
    public Image HealthBar;
    public Image BrogmarHealthBar;
    public Image YellowKey;
    public Image GreenKey;
    public Image PurpleKey;
    public bool hasYKey, hasGKey, hasPKey, isPaused;
    public int numKeys;
    public int collectKeys;
    public bool allKeysCollected;

    public GameObject Pausepanel;
    public GameObject GameOverPanel;
    public GameObject WinPanel;

    void Start()
    {
        GameOverPanel.SetActive(false);
        WinPanel.SetActive(false);
        Pausepanel.SetActive(false);
        bool allKeysCollected = false;

        hasYKey = false;
        hasGKey = false;
        hasPKey = false;
        showKeys(numKeys);
        collectKeys = 0;
    }
    void Update()
    {
        if(numKeys == collectKeys && numKeys > 0)
        {
            ObjTxt.text = "Objective:\n\nGet to the Exit";
            allKeysCollected = true;
        }
        if (Keyboard.current.escapeKey.wasPressedThisFrame && !(GameOverPanel.activeSelf || WinPanel.activeSelf))
        {
            pause();
        }
    }

    public void DecreaseAmmo()
    {
        
    }

    public void setAmmo(int clipSize, int numClips)
    {
        Ammo.text = clipSize + "/" + numClips;
    }
    public void updateAmmo(int bullets, int numClips)
    {
        Ammo.text = bullets + "/" + numClips;
    }

    public void updateHealth(float Health)
    {
        HealthBar.fillAmount = Health;
    }
    public void updateBrogmarHealth(float Health)
    {
        BrogmarHealthBar.fillAmount = Health;
    }

    public void PlayerDeath()
    {
        GameOverPanel.SetActive(true);
        esc.enabled = false;
        Time.timeScale = 0f;
    }
    public void Reset()
    {
        Time.timeScale = 1f;
    }
    public void PlayerWin()
    {
        esc.enabled = false;
        WinPanel.SetActive(true);
        Time.timeScale = 0f;
    }
    public void pause()
    {
        Pausepanel.SetActive(true);
        esc.enabled = false;
        isPaused = true;
        Time.timeScale = 0f;
    }
    public void resume()
    {
        Pausepanel.SetActive(false);
        Time.timeScale = 1f;
        esc.enabled = true;
        isPaused = false;
    }

    public void getKey(string color)
    {
        
        switch (color)
        {
            case "Yellow":
            YellowKey.color = Color.gold;
            hasYKey = true;
                break;
            case "Green":
            GreenKey.color = Color.green;
            hasGKey = true;
                break;
            case "Purple":
            PurpleKey.color = Color.purple;
            hasPKey = true;
                break;
            default:
                Debug.Log("Key not recognized");
                break;
        }
        collectKeys ++;
    }

public void showKeys(int numKeys)
    {
        switch(numKeys){
            case 1:
                YellowKey.enabled = true;
                GreenKey.enabled = false;
                PurpleKey.enabled = false;
                break;
            case 2:
                YellowKey.enabled = true;
                GreenKey.enabled = true;
                PurpleKey.enabled = false;
                break;
            case 3:
                YellowKey.enabled = true;
                GreenKey.enabled = true;
                PurpleKey.enabled = true;
                break;
            default:
                YellowKey.enabled = false;
                GreenKey.enabled = false;
                PurpleKey.enabled = false;
                break;
        }
    }

}

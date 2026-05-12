using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.InputSystem;

public class KeyManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject KeyUI;
    GameObject GameCanvas;
    Hud GameUI;
    public string KeyColor;
    [SerializeField] TextMeshProUGUI keyText;
    //[SerializeField] Image KeyImg;
    void Start()
    {
        KeyUI.SetActive(false);
        //keyText.enabled = false;
        GameCanvas = GameObject.FindGameObjectWithTag("GameCanvas");
        GameUI = GameCanvas.GetComponent<Hud>();
    }

    // Update is called once per frame
    void Update()
    {
        if(KeyUI.activeSelf && Keyboard.current.eKey.wasPressedThisFrame)
        {
            GameUI.getKey(KeyColor);
            Destroy(transform.gameObject);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if(KeyUI != null){
            KeyUI.SetActive(true);
            }
            //keyText.enabled = true;  
            Debug.Log(this.tag);          
        }
        
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //keyText.enabled = false;
            if(KeyUI != null){
            KeyUI.SetActive(false);
            }
        }
    }
    
}

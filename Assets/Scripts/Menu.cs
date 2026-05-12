using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public string ScenetoLoad = "Level 1";
    public GameObject ControlPanel;
    public Button ControlsButton;

    void Awake()
    {
        if(ControlPanel!= null){
        ControlPanel.SetActive(false);}
    }
    public void playGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        
    }
    public void startGame()
    {
        SceneManager.LoadScene("Level 1");
    }

    public void exitGame()
    {
        Application.Quit();
    }
    public void goToScene(string scene)
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(scene);
        
    }
    public void restartGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Level 1");
        
    }
    public void ShowControls()
    {
        if(ControlPanel != null){
        ControlPanel.SetActive(true);
        ControlsButton.enabled = true;}

    }
    public void CloseControls()
    {
        if(ControlPanel != null){
        ControlPanel.SetActive(false);
        ControlsButton.enabled = true;}
    }
}

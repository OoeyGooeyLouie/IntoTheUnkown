using UnityEngine;

public class MouseManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Hud GameCanvas;
    private bool lastPauseState;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        lastPauseState = GameCanvas.isPaused;
    }

    // Update is called once per frame
    void Update()
    {
        // Only run when pause state CHANGES
        if (GameCanvas.isPaused != lastPauseState)
        {
            ApplyState(GameCanvas.isPaused);
            lastPauseState = GameCanvas.isPaused;
        }
        if (GameCanvas.GameOverPanel.activeSelf)
        {
            ApplyState(true);
        }
        if (GameCanvas.WinPanel.activeSelf)
        {
            ApplyState(true);
        }
    }

    void ApplyState(bool paused)
    {
        // Cursor
        Cursor.lockState = paused ? CursorLockMode.None : CursorLockMode.Locked;
        Cursor.visible = paused;

        // Freeze / unfreeze camera
        // if (cameraLookScript != null)
        // {
        //     cameraLookScript.enabled = !paused;
        // }
    }
}

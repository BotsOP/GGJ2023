using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstScenePause : MonoBehaviour
{
    public bool pausing = false;
    public GameObject canvas;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseGame();
        }
    }

    public void PauseGame()
    {
        pausing = !pausing;
        if (pausing)
        {
            Time.timeScale = 0;
            canvas.SetActive(true);
        }
        else
        {
            Time.timeScale = 1;
            canvas.SetActive(false);
        }

    }

    public void QuitGame()
    {
        Application.Quit();
    }
}

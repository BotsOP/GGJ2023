using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class PauseMenuController : MonoBehaviour
{
    public VideoClip[] clips;
    public GameObject pauseMenuUI;
    public GameObject contentNotFoundObject;
    private VideoPlayer vp;
    private int clipIndex;
    private void Start()
    {
        vp = GetComponent<VideoPlayer>();
        vp.Prepare();
        vp.Pause();
    }
    

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Pause();
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void Pause()
    {
        pauseMenuUI.SetActive(!pauseMenuUI.activeSelf);
        Time.timeScale = 0f;
        if (pauseMenuUI.activeSelf)
        {
            vp.Play();
        }
        else
        {
            clipIndex++;
            if (clipIndex > clips.Length - 1)
            {
                contentNotFoundObject.SetActive(true);
                vp.Pause();
                return;
            }
            vp.clip = clips[clipIndex];
            vp.Prepare();
            vp.Pause();
        }
        
        
    }
}

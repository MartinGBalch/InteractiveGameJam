using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class pauseMenu : MonoBehaviour
{
    public Image pausemenu;

    public Button pauseButton;
    public Button resume;
    public Button restart;
    public Button mainMenu;

    public Image noRestart;

    public float timer;

    bool paused;

    public string scene;

	// Use this for initialization
	void Start ()
    {
        pausemenu.gameObject.SetActive(false);
        noRestart.gameObject.SetActive(false);
        paused = false;
        
        
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && pausemenu.gameObject.activeInHierarchy == false)
        {
            paused = true;
            pausemenu.gameObject.SetActive(true);
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && pausemenu.gameObject.activeInHierarchy == true)
        {
            paused = false;
            pausemenu.gameObject.SetActive(false);
        }
        if (paused)
        {
            Time.timeScale = 0;
            
        }
        else if (!paused)
        {
            Time.timeScale = 1;
        }
        
	}

    public void PauseButton()
    {
        paused = true;
        pausemenu.gameObject.SetActive(true);
    }

    public void Resume()
    {
        paused = false;
        pausemenu.gameObject.SetActive(false);
    }

    public void Restart()
    {
        noRestart.gameObject.SetActive(true);
    }

    public void NoRestart()
    {
        noRestart.gameObject.SetActive(false);
        pausemenu.gameObject.SetActive(true);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(scene);
    }
}

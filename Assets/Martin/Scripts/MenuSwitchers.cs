using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuSwitchers : MonoBehaviour
{
    public Button play;
   
    public Button exit;
    public Button credit;
    public Button enter;
    public Button okay;
    public Button back;

    public RawImage titleScreen;
    public Image mainMenu;
    public Image characterSelect;
    
    public Image credits;

    public string scene;

	// Use this for initialization
	void Start ()
    {
        titleScreen.gameObject.SetActive(true);
        mainMenu.gameObject.SetActive(false);
        characterSelect.gameObject.SetActive(false);
       
        credits.gameObject.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {}

    public void enterPress()
    {
        titleScreen.gameObject.SetActive(false);
        mainMenu.gameObject.SetActive(true);
        //fade stuff here if i get time
    }

    public void playPress()
    {
        characterSelect.gameObject.SetActive(true);
        mainMenu.gameObject.SetActive(false);
    }

   

    public void creditPress()
    {
        credits.gameObject.SetActive(true);
        mainMenu.gameObject.SetActive(false);
    }

    public void exitPress()
    {
        Application.Quit();
    }

    public void okayPress()
    {
        SceneManager.LoadScene(scene);
    }

    public void backPress()
    {
        mainMenu.gameObject.SetActive(true);
        characterSelect.gameObject.SetActive(false);
       
        credits.gameObject.SetActive(false);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoseManager : MonoBehaviour
{
    public static LoseManager Instance { get; set; }
    public Image LoseScreen;
    public Button home;
    public Button exit;

    public Text loseText;
    public Text Exit;
    public Text Home;

    public Color ButtonColor;
    public Color LoseText;

    StatusManager lose;

    public Canvas UI;

    private bool isInTransition;
    private bool isShowing;

    private float transition;
    private float duration;

    public float fadeTimer;

    public string scene;



    private void Awake() { Instance = this; }

    public void Fade(bool showing, float duration)
    {
        isShowing = showing;
        isInTransition = true;
        this.duration = duration;
        transition = (isShowing) ? 0 : 1;
    }

    // Use this for initialization
    void Start()
    {
        lose = FindObjectOfType<StatusManager>();
        LoseScreen.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightControl) || lose.didYouLose())
        {
            Time.timeScale = 0;
            Fade(true, fadeTimer);
            LoseScreen.gameObject.SetActive(true);
            UI.gameObject.SetActive(false);
        }

        if (!isInTransition)
            return;

        transition += (isShowing) ? .6f * (1 / duration) : -.6f * (1 / duration);

        //enter.color = Color.Lerp(Color.black, new Color(1,0,0,.5f), transition);
        loseText.color = Color.Lerp(new Color(0, 0, 0, 1), LoseText, transition);
        Exit.color = Color.Lerp(new Color(0, 0, 0, 1), ButtonColor, transition);
        Home.color = Color.Lerp(new Color(0, 0, 0, 1), ButtonColor, transition);


        if (transition > 1 || transition < 0)
        {
            isInTransition = false;
        }

    }

    public void GoHome()
    {
        SceneManager.LoadScene(scene);
    }

    public void LeaveUs()
    {
        Application.Quit();
    }

}

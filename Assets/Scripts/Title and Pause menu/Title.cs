using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class Title : MonoBehaviour
{
    public GameObject quitButton;
    public GameObject playButton;
    public GameObject CreditsButton;
    public GameObject TutorialButton;
    public GameObject BacktoMenuButton;
    public GameObject panel;
    public TMP_Text title;
    public TMP_Text howToPlay;
    public TMP_Text Credit;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        /*
        panel.SetActive(true);
        quitButton.SetActive(true);
        playButton.SetActive(true);
        CreditsButton.SetActive(true);
        TutorialButton.SetActive(true);
        BacktoMenuButton.SetActive(false);
        title.enabled = true;
        howToPlay.enabled = false;
        Credit.enabled = false;
        */
    }

    // Update is called once per frame
    public void QuitGame()
    {
        Application.Quit();
    }
    public void Credits()
    {
        SceneManager.LoadScene("Credits");
        /*
        BacktoMenuButton.SetActive(true);
        Credit.enabled = true;

        panel.SetActive(true);
        quitButton.SetActive(false);
        playButton.SetActive(false);
        CreditsButton.SetActive(false);
        title.enabled = false;
        howToPlay.enabled = false;
        TutorialButton.SetActive(false);
        */
    }
    public void Tutorial()
    {
        SceneManager.LoadScene("HowToPlay");

        //can be either a tutorial new scene or text to show how to play
        /*
        howToPlay.enabled = true;
        BacktoMenuButton.SetActive(true);

        Credit.enabled = false;
        panel.SetActive(true);
        quitButton.SetActive(false);
        playButton.SetActive(false);
        CreditsButton.SetActive(false);
        title.enabled = false;
        TutorialButton.SetActive(false);
        */
    }
    public void Play()
    {
        SceneManager.LoadScene("Level1");
    }
    public void BackButton()
    {
        SceneManager.LoadScene("Title");
        /*
        panel.SetActive(true);
        quitButton.SetActive(true);
        playButton.SetActive(true);
        CreditsButton.SetActive(true);
        BacktoMenuButton.SetActive(true);
        title.enabled = true;
        howToPlay.enabled = false;
        Credit.enabled = false;
        TutorialButton.SetActive(true);
        */
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    public Image blackScreen;
    public GameObject dialogueFrame;

    public float blackScreenFadeSpeed = 0.5f, dialogueFrameMoveSpeed;
    public bool fadeToBlack, fadeFromBlack, fadeToDialogue, fadeFromDialogue;

    public Image healthImage;

    public GameObject pauseScreen;

    public GameObject pauseFirstButton;

    public string mainMenu;

    private void Awake()
    {
        instance = this;
    }

    void Update()
    {
        if (fadeToBlack)
        {
            blackScreen.color = new Color(blackScreen.color.r, blackScreen.color.g, blackScreen.color.b, Mathf.MoveTowards(blackScreen.color.a, 1f, blackScreenFadeSpeed * Time.deltaTime));

            if (blackScreen.color.a == 1f)
            {
                fadeToBlack = false;
            }
        }

        if (fadeFromBlack)
        {
            blackScreen.color = new Color(blackScreen.color.r, blackScreen.color.g, blackScreen.color.b, Mathf.MoveTowards(blackScreen.color.a, 0f, blackScreenFadeSpeed * Time.deltaTime));

            if (blackScreen.color.a == 0f)
            {
                fadeFromBlack = false;
            }
        }

        if (fadeToDialogue)
        {
            dialogueFrame.transform.position = new Vector3(dialogueFrame.transform.position.x, Mathf.Lerp(dialogueFrame.transform.position.y, 135f, dialogueFrameMoveSpeed * Time.deltaTime), dialogueFrame.transform.position.z);

            if (dialogueFrame.transform.position.y == -405f)
            {
                fadeToDialogue = false;
            }
        }

        if (fadeFromDialogue)
        {
            dialogueFrame.transform.position = new Vector3(dialogueFrame.transform.position.x, Mathf.Lerp(dialogueFrame.transform.position.y, -135f, dialogueFrameMoveSpeed * Time.deltaTime), dialogueFrame.transform.position.z);

            if (dialogueFrame.transform.position.y == -675f)
            {
                fadeToDialogue = false;
            }
        }
    }

    public void Resume()
    {
        GameManager.instance.PauseUnpause();
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(mainMenu);
        Time.timeScale = 1f;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DifficultyChoice : MonoBehaviour
{
    public Button easy, normal;

    public static bool easyMode;
    public static bool buttonsActive;
    public static bool buttonsAreActive;

    //For Testing Purposes
    private void Start()
    {
        easyMode = true;
    }

    private void Update()
    {
        if (buttonsActive)
        {
            easy.gameObject.SetActive(true);
            normal.gameObject.SetActive(true);

            DialogueTrigger.instance.isInteracting = true;
        }
        else
        {
            easy.gameObject.SetActive(false);
            normal.gameObject.SetActive(false);
        }

        if (buttonsAreActive)
        {
            buttonsAreActive = false;
            EventSystem.current.SetSelectedGameObject(null);
            EventSystem.current.SetSelectedGameObject(UIManager.instance.difficultyFirstButton);
        }
    }

    public void SelectEasyMode()
    {
        easyMode = true;
        buttonsActive = false;
        DialogueTrigger.instance.isInteracting = false;

    }

    public void SelectNormalMode()
    {
        easyMode = false;
        buttonsActive = false;
        DialogueTrigger.instance.isInteracting = false;
    }
}

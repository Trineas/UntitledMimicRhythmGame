using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DifficultyChoice : MonoBehaviour
{
    public Button easy, normal;

    public static bool easyMode;
    public static bool buttonsActive;

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

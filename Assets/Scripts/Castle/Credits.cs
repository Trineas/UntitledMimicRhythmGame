using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Credits : MonoBehaviour
{
    public static Credits instance;

    public Image mimicScreen, theEndScreen, creditsScreen, secondCreditsScreen;
    public TextMeshProUGUI text;
    public float blackScreenFadeSpeed = 0.5f;
    public bool fadeToMimic, fadeToEnd, fadeToCredits, fadeFromCredits, fadeToSecondCredits, fadeFromText;

    public bool isWebGl;

    void Start()
    {
        instance = this;
    }

    void Update()
    {
        if (fadeToMimic)
        {
            mimicScreen.color = new Color(mimicScreen.color.r, mimicScreen.color.g, mimicScreen.color.b, Mathf.MoveTowards(mimicScreen.color.a, 1f, blackScreenFadeSpeed * Time.deltaTime));

            if (mimicScreen.color.a == 1f)
            {
                fadeToMimic = false;
            }
        }

        if (fadeToEnd)
        {
            theEndScreen.color = new Color(theEndScreen.color.r, theEndScreen.color.g, theEndScreen.color.b, Mathf.MoveTowards(theEndScreen.color.a, 1f, blackScreenFadeSpeed * Time.deltaTime));

            if (theEndScreen.color.a == 1f)
            {
                fadeToEnd = false;
            }
        }

        if (fadeToCredits)
        {
            creditsScreen.color = new Color(creditsScreen.color.r, creditsScreen.color.g, creditsScreen.color.b, Mathf.MoveTowards(creditsScreen.color.a, 1f, blackScreenFadeSpeed * Time.deltaTime));

            if (creditsScreen.color.a == 1f)
            {
                fadeToCredits = false;
            }
        }

        if (fadeToSecondCredits)
        {
            secondCreditsScreen.color = new Color(secondCreditsScreen.color.r, secondCreditsScreen.color.g, secondCreditsScreen.color.b, Mathf.MoveTowards(secondCreditsScreen.color.a, 1f, blackScreenFadeSpeed * Time.deltaTime));

            if (secondCreditsScreen.color.a == 1f)
            {
                fadeToCredits = false;
            }
        }

        if (fadeFromText)
        {
            text.color = new Color(text.color.r, text.color.g, text.color.b, Mathf.MoveTowards(text.color.a, 0f, blackScreenFadeSpeed * Time.deltaTime));

            if (text.color.a == 0f)
            {
                fadeFromText = false;
            }
        }

        if (fadeFromCredits)
        {
            creditsScreen.color = new Color(creditsScreen.color.r, creditsScreen.color.g, creditsScreen.color.b, Mathf.MoveTowards(creditsScreen.color.a, 0f, blackScreenFadeSpeed * Time.deltaTime));

            if (creditsScreen.color.a == 0f)
            {
                fadeFromCredits = false;
            }
        }
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void PlayCredits()
    {
        StartCoroutine(CreditsCo());
    }

    public IEnumerator CreditsCo()
    {
        yield return new WaitForSeconds(7f);
        fadeToMimic = true;
        yield return new WaitForSeconds(5f);
        fadeFromText = true;
        yield return new WaitForSeconds(3f);
        fadeToCredits = true;
        yield return new WaitForSeconds(10f);
        fadeFromCredits = true;
        yield return new WaitForSeconds(3f);
        fadeToSecondCredits = true;
        yield return new WaitForSeconds(10f);
        fadeToEnd = true;
        yield return new WaitForSeconds(8f);
        UIManager.instance.fadeToBlack = true;
        yield return new WaitForSeconds(3f);

        if (isWebGl)
        {
            SceneManager.LoadScene("Level01_Overworld");
        }
        else
        {
            Quit();
        }
    }
}

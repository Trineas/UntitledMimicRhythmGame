using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class LevelEnd : MonoBehaviour
{
    public string levelToLoad;
    public GameObject toBeContinued;

    public GameObject toBeContinuedButton;

    IEnumerator LevelTransition()
    {
        DialogueTriggerAfter.instance.isInteracting = true;
        //UIManager.instance.fadeToBlack = true;
        toBeContinued.SetActive(true);

        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(toBeContinuedButton);

        Time.timeScale = 0f;

        yield return new WaitForSeconds(4f);

        //SceneManager.LoadScene(levelToLoad);

    }

    private void OnTriggerEnter(Collider other)
    {
        StartCoroutine(LevelTransition());
    }
}

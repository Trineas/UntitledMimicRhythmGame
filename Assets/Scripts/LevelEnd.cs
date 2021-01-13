using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class LevelEnd : MonoBehaviour
{
    public string levelToLoad;

    IEnumerator LevelTransition()
    {
        DialogueTriggerAfter.instance.isInteracting = true;
        UIManager.instance.fadeToBlack = true;

        yield return new WaitForSeconds(4f);

        SceneManager.LoadScene(levelToLoad);
    }

    private void OnTriggerEnter(Collider other)
    {
        StartCoroutine(LevelTransition());
    }
}

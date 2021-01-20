using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChestTrigger : MonoBehaviour
{
    public bool isInteractingWithChest;

    public BoxCollider col;

    public string levelToLoad;

    private void Update()
    {
        if (PlayerController.instance.canInteractWithChest && !isInteractingWithChest)
        {
            if (Input.GetButtonDown("Interact"))
            {
                isInteractingWithChest = true;
                StartCoroutine(LevelTransition());
            }
        }

        if (isInteractingWithChest)
        {
            PlayerController.instance.stopMove = true;
            //col.size = new Vector3(0.01f, 0.01f, 0.01f);
        }
        else
        {
            PlayerController.instance.stopMove = false;
            //col.size = new Vector3(2.5f, 1f, 2.5f);
        }
    }

    IEnumerator LevelTransition()
    {
        UIManager.instance.fadeToBlack = true;

        yield return new WaitForSeconds(4f);

        SceneManager.LoadScene(levelToLoad);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            PlayerController.instance.canInteractWithChest = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            PlayerController.instance.canInteractWithChest = false;
        }
    }
}

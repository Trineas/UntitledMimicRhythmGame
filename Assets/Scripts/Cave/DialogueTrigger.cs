using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public static DialogueTrigger instance;

    public bool isInteracting;

    public BoxCollider col;

    private void Start()
    {
        instance = this;
    }

    private void Update()
    {
        if (PlayerController.instance.canInteract && !isInteracting)
        {
            if (Input.GetButtonDown("Interact"))
            {
                isInteracting = true;
                DialogueOverworld.instance.StartDialogue();
            }
        }

        if (isInteracting)
        {
            PlayerController.instance.stopMove = true;
            col.size = new Vector3(0.01f, 0.01f, 0.01f);
        }
        else
        {
            PlayerController.instance.stopMove = false;
            col.size = new Vector3(2.5f, 1f, 2.5f);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            PlayerController.instance.canInteract = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            PlayerController.instance.canInteract = false;
        }
    }
}

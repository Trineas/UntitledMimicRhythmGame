using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTriggerAfter : MonoBehaviour
{
    public static DialogueTriggerAfter instance;

    public bool isInteracting;

    public Animator anim;

    private void Start()
    {
        instance = this;

        anim.SetBool("Defeated", true);
    }

    private void Update()
    {
        if (PlayerController.instance.canInteract && !isInteracting)
        {
            if (Input.GetButtonDown("Interact"))
            {
                isInteracting = true;
                DialogueAfter.instance.StartDialogue();
            }
        }

        if (isInteracting)
        {
            PlayerController.instance.stopMove = true;
        }
        else
        {
            PlayerController.instance.stopMove = false;
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

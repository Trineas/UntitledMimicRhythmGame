using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteObject : MonoBehaviour
{
    public bool canBePressed;
    public KeyCode keyToPress;
    public int buttonSoundToPlay, missSound;

    public GameObject hitEffect, missEffect;

    void Update()
    {
        if (Input.GetKeyDown(keyToPress))
        {
            if (canBePressed)
            {
                AudioManager.instance.PlaySFX(buttonSoundToPlay);
                gameObject.SetActive(false);

                //Set Animation for Button pressed
                if (keyToPress == KeyCode.LeftArrow)
                {
                    GameManager.instance.playerAnim.SetTrigger("Left");
                }
                else if (keyToPress == KeyCode.RightArrow)
                {
                    GameManager.instance.playerAnim.SetTrigger("Right");
                }
                else if (keyToPress == KeyCode.DownArrow)
                {
                    GameManager.instance.playerAnim.SetTrigger("Down");
                }
                else if (keyToPress == KeyCode.UpArrow)
                {
                    GameManager.instance.playerAnim.SetTrigger("Up");
                }
                else if (keyToPress == KeyCode.Space)
                {
                    GameManager.instance.playerAnim.SetTrigger("Space");
                }

                // Set hit accuracy
                if (Mathf.Abs(transform.position.y) >= 0.25)
                {
                    Instantiate(hitEffect, transform.position, hitEffect.transform.rotation);
                }
            }
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Activator")
        {
            canBePressed = true;
        }
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Activator" && gameObject.activeSelf)
        {
            canBePressed = false;
            GameManager.instance.NoteMissed();
            GameManager.instance.playerAnim.SetTrigger("Missed");

            Instantiate(missEffect, transform.position, hitEffect.transform.rotation);
            AudioManager.instance.PlaySFX(missSound);
        }
    }
}

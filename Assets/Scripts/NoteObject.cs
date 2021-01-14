using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteObject : MonoBehaviour
{
    public bool canBePressed;
    public KeyCode keyToPress;
    public KeyCode[] keyNotToPress;
    public int buttonSoundToPlay, missSound;

    public bool doesDamage;
    //public GameObject hitEffect, missEffect;

    void Update()
    {
        if (Input.GetKeyDown(keyToPress))
        {
            if (canBePressed)
            {
                AudioManager.instance.PlaySFX(buttonSoundToPlay);
                //EnemyHealthManager.instance.Hurt();
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
                /*if (Mathf.Abs(transform.position.y) >= 0.25)
                {
                    Instantiate(hitEffect, transform.position, hitEffect.transform.rotation);
                }*/
            }
        }
        else if (Input.GetKeyDown(keyNotToPress[0]))
        {
            if (canBePressed)
            {
                if (doesDamage)
                {
                    gameObject.SetActive(false);
                    AudioManager.instance.PlaySFX(missSound);

                    //GameManager.instance.NoteMissed();
                    EnemyHealthManager.instance.notesMissed++;
                    GameManager.instance.playerAnim.SetTrigger("Missed");
                }
                else
                {
                    gameObject.SetActive(false);
                    AudioManager.instance.PlaySFX(missSound);
                    GameManager.instance.playerAnim.SetTrigger("Missed");
                }
            }

        }
        else if (Input.GetKeyDown(keyNotToPress[1]))
        {
            if (canBePressed)
            {
                if (doesDamage)
                {
                    gameObject.SetActive(false);
                    AudioManager.instance.PlaySFX(missSound);

                    //GameManager.instance.NoteMissed();
                    EnemyHealthManager.instance.notesMissed++;
                    GameManager.instance.playerAnim.SetTrigger("Missed");
                }
                else
                {
                    gameObject.SetActive(false);
                    AudioManager.instance.PlaySFX(missSound);
                    GameManager.instance.playerAnim.SetTrigger("Missed");
                }
            }
        }
        else if (Input.GetKeyDown(keyNotToPress[2]))
        {
            if (canBePressed)
            {
                if (doesDamage)
                {
                    gameObject.SetActive(false);
                    AudioManager.instance.PlaySFX(missSound);

                    //GameManager.instance.NoteMissed();
                    EnemyHealthManager.instance.notesMissed++;
                    GameManager.instance.playerAnim.SetTrigger("Missed");
                }
                else
                {
                    gameObject.SetActive(false);
                    AudioManager.instance.PlaySFX(missSound);
                    GameManager.instance.playerAnim.SetTrigger("Missed");
                }
            }
        }
        else if (Input.GetKeyDown(keyNotToPress[3]))
        {
            if (canBePressed)
            {
                if (doesDamage)
                {
                    gameObject.SetActive(false);
                    AudioManager.instance.PlaySFX(missSound);

                    //GameManager.instance.NoteMissed();
                    EnemyHealthManager.instance.notesMissed++;
                    GameManager.instance.playerAnim.SetTrigger("Missed");
                }
                else
                {
                    gameObject.SetActive(false);
                    AudioManager.instance.PlaySFX(missSound);
                    GameManager.instance.playerAnim.SetTrigger("Missed");
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
            if (doesDamage)
            {
                canBePressed = false;
                //GameManager.instance.NoteMissed();
                EnemyHealthManager.instance.notesMissed++;
                GameManager.instance.playerAnim.SetTrigger("Missed");

                //Instantiate(missEffect, transform.position, hitEffect.transform.rotation);
                AudioManager.instance.PlaySFX(missSound);
            }
            else
            {
                canBePressed = false;
                GameManager.instance.playerAnim.SetTrigger("Missed");

                //Instantiate(missEffect, transform.position, hitEffect.transform.rotation);
                AudioManager.instance.PlaySFX(missSound);
            }
        }
    }
}

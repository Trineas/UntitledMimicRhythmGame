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
    public GameObject hitEffect, goodEffect, perfectEffect, missEffect;
    public GameObject effectSlot;

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
                    effectSlot.transform.localPosition = new Vector3(-0.5f, 0f, -0.45f);
                }
                else if (keyToPress == KeyCode.RightArrow)
                {
                    GameManager.instance.playerAnim.SetTrigger("Right");
                    effectSlot.transform.localPosition = new Vector3(1f, 0f, -0.15f);
                }
                else if (keyToPress == KeyCode.DownArrow)
                {
                    GameManager.instance.playerAnim.SetTrigger("Down");
                    effectSlot.transform.localPosition = new Vector3(0.1f, -0.75f, -0.15f);
                }
                else if (keyToPress == KeyCode.UpArrow)
                {
                    GameManager.instance.playerAnim.SetTrigger("Up");
                    effectSlot.transform.localPosition = new Vector3(0.25f, 0.75f, -0.45f);
                }
                else if (keyToPress == KeyCode.Space)
                {
                    GameManager.instance.playerAnim.SetTrigger("Space");
                    effectSlot.transform.localPosition = new Vector3(0.1f, 0f, -0.15f);
                }

                if (Mathf.Abs(transform.position.y) > 0.25f)
                {
                    Instantiate(hitEffect, effectSlot.transform.position, hitEffect.transform.rotation);
                }
                else if (Mathf.Abs(transform.position.y) > 0.05f)
                {
                    Instantiate(goodEffect, effectSlot.transform.position, goodEffect.transform.rotation);
                }
                else
                {
                    Instantiate(perfectEffect, effectSlot.transform.position, perfectEffect.transform.rotation);
                }
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

                    EnemyHealthManager.instance.notesMissed++;
                    GameManager.instance.playerAnim.SetTrigger("Missed");
                    Instantiate(missEffect, effectSlot.transform.position, missEffect.transform.rotation);
                }
                else
                {
                    gameObject.SetActive(false);
                    AudioManager.instance.PlaySFX(missSound);
                    GameManager.instance.playerAnim.SetTrigger("Missed");
                    Instantiate(missEffect, effectSlot.transform.position, missEffect.transform.rotation);
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

                    EnemyHealthManager.instance.notesMissed++;
                    GameManager.instance.playerAnim.SetTrigger("Missed");
                    Instantiate(missEffect, effectSlot.transform.position, missEffect.transform.rotation);
                }
                else
                {
                    gameObject.SetActive(false);
                    AudioManager.instance.PlaySFX(missSound);
                    GameManager.instance.playerAnim.SetTrigger("Missed");
                    Instantiate(missEffect, effectSlot.transform.position, missEffect.transform.rotation);
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

                    EnemyHealthManager.instance.notesMissed++;
                    GameManager.instance.playerAnim.SetTrigger("Missed");
                    Instantiate(missEffect, effectSlot.transform.position, missEffect.transform.rotation);
                }
                else
                {
                    gameObject.SetActive(false);
                    AudioManager.instance.PlaySFX(missSound);
                    GameManager.instance.playerAnim.SetTrigger("Missed");
                    Instantiate(missEffect, effectSlot.transform.position, missEffect.transform.rotation);
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

                    EnemyHealthManager.instance.notesMissed++;
                    GameManager.instance.playerAnim.SetTrigger("Missed");
                    Instantiate(missEffect, effectSlot.transform.position, missEffect.transform.rotation);
                }
                else
                {
                    gameObject.SetActive(false);
                    AudioManager.instance.PlaySFX(missSound);
                    GameManager.instance.playerAnim.SetTrigger("Missed");
                    Instantiate(missEffect, effectSlot.transform.position, missEffect.transform.rotation);
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
                EnemyHealthManager.instance.notesMissed++;
                GameManager.instance.playerAnim.SetTrigger("Missed");

                Instantiate(missEffect, effectSlot.transform.position, missEffect.transform.rotation);
                AudioManager.instance.PlaySFX(missSound);
            }
            else
            {
                canBePressed = false;
                GameManager.instance.playerAnim.SetTrigger("Missed");

                Instantiate(missEffect, effectSlot.transform.position, missEffect.transform.rotation);
                AudioManager.instance.PlaySFX(missSound);
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteObject : MonoBehaviour
{
    public bool canBePressed;
    public KeyCode keyToPress;
    public int buttonSoundToPlay;

    public GameObject hitEffect, goodEffect, perfectEffect, missEffect;

    void Update()
    {
        if (Input.GetKeyDown(keyToPress))
        {
            if (canBePressed)
            {
                AudioManager.instance.PlaySFX(buttonSoundToPlay);
                gameObject.SetActive(false);

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

                if (Mathf.Abs(transform.position.y) > 0.25)
                {
                    Instantiate(hitEffect, transform.position, hitEffect.transform.rotation);
                    GameManager.instance.NormalHit();
                }
                else if (Mathf.Abs(transform.position.y) > 0.05f)
                {
                    Instantiate(goodEffect, transform.position, hitEffect.transform.rotation);
                    GameManager.instance.GoodHit();
                }
                else
                {
                    Instantiate(perfectEffect, transform.position, hitEffect.transform.rotation);
                    GameManager.instance.PerfectHit();
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
            Instantiate(missEffect, transform.position, hitEffect.transform.rotation);
        }
    }
}

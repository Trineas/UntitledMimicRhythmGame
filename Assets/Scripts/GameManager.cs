using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public AudioSource song;
    public bool startPlaying;

    public string levelToLoad;

    public float currentPositionInSong;

    public Animator playerAnim, enemyAnim;

    public int currentHealth;
    private int maxHealth = 5;
    public Sprite[] healthBarImages;

    void Start()
    {
        instance = this;
        currentHealth = maxHealth;
    }

    void Update()
    {
        if (song.isPlaying)
        {
            currentPositionInSong += Time.deltaTime;
        }
        else
        {
            currentPositionInSong = 0f;
        }

        if (startPlaying)
        {
            BeatScroller.instance.hasStarted = true;

            song.Play();
            enemyAnim.SetTrigger("Set 01");
            startPlaying = false;
        }


        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.Joystick1Button7))
        {
            PauseUnpause();
        }

        if (currentHealth <= 0)
        {
            StartCoroutine(GameOverCo());
        }
    }

    IEnumerator GameOverCo()
    {
        UIManager.instance.fadeToBlack = true;

        yield return new WaitForSeconds(2f);

        SceneManager.LoadScene(levelToLoad);
    }

    public void PauseUnpause()
    {
        if (UIManager.instance.pauseScreen.activeInHierarchy)
        {
            UIManager.instance.pauseScreen.SetActive(false);
            song.UnPause();
            Time.timeScale = 1f;
        }

        else
        {
            UIManager.instance.pauseScreen.SetActive(true);
            song.Pause();
            Time.timeScale = 0f;

            EventSystem.current.SetSelectedGameObject(null);
            EventSystem.current.SetSelectedGameObject(UIManager.instance.pauseFirstButton);
        }
    }

    public void UpdateUI()
    {
        switch (currentHealth)
        {
            case 5:
                UIManager.instance.healthImage.sprite = healthBarImages[5];
                break;

            case 4:
                UIManager.instance.healthImage.sprite = healthBarImages[4];
                break;

            case 3:
                UIManager.instance.healthImage.sprite = healthBarImages[3];
                break;

            case 2:
                UIManager.instance.healthImage.sprite = healthBarImages[2];
                break;

            case 1:
                UIManager.instance.healthImage.sprite = healthBarImages[1];
                break;

            case 0:
                UIManager.instance.healthImage.sprite = healthBarImages[0];
                break;
        }
    }
}

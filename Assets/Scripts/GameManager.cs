using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public AudioSource song;
    public bool startPlaying;
    public BeatScroller beatScroller;

    public float currentPositionInSong;

    public int currentScore;
    public int scorePerNote = 100;
    public int scorePerGoodNote = 125;
    public int scorePerPerfectNote = 150;

    public int currentMultiplier;
    private int multiplierTracker;
    public int[] multiplierTresholds;

    public Text scoreText;
    public Text multiplierText;

    private float totalNotes;
    private float normalHits, goodHits, perfectHits, missedHits;

    public GameObject resultsScreen;
    public Text percentHitText, normalsText, goodsText, perfectsText, missesText, rankText, finalScoreText;

    public Animator playerAnim, enemyAnim;

    void Start()
    {
        instance = this;
        scoreText.text = "Score: 0";
        currentMultiplier = 1;
        totalNotes = FindObjectsOfType<NoteObject>().Length;
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

        if (!startPlaying)
        {
            if (Input.anyKeyDown)
            {
                startPlaying = true;
                beatScroller.hasStarted = true;

                song.Play();
                enemyAnim.SetTrigger("Set 01");
            }
        }
        else
        {
            if (!song.isPlaying && !resultsScreen.activeInHierarchy)
            {
                resultsScreen.SetActive(true);

                normalsText.text = normalHits.ToString();
                goodsText.text = goodHits.ToString();
                perfectsText.text = perfectHits.ToString();
                missesText.text = missedHits.ToString();

                float totalHit = normalHits + goodHits + perfectHits;
                float percentHit = (totalHit / totalNotes) * 100f;

                percentHitText.text = percentHit.ToString("F1") + "%";

                string rankValue = "F";

                if (percentHit > 40f)
                {
                    rankValue = "D";

                    if (percentHit > 55f)
                    {
                        rankValue = "C";

                        if (percentHit > 70f)
                        {
                            rankValue = "B";

                            if (percentHit > 85f)
                            {
                                rankValue = "A";

                                if (percentHit == 100f)
                                {
                                    rankValue = "S";

                                    if (percentHit == 100f && perfectHits == totalNotes)
                                    {
                                        rankValue = "S+";
                                    }
                                }
                            }
                        }
                    }
                }

                rankText.text = rankValue;
                finalScoreText.text = currentScore.ToString();
            }
        }
    }

    public void NoteHit()
    {
        if (currentMultiplier - 1 < multiplierTresholds.Length)
        {
            multiplierTracker++;

            if (multiplierTresholds[currentMultiplier - 1] <= multiplierTracker)
            {
                multiplierTracker = 0;
                currentMultiplier++;
            }
        }

        multiplierText.text = "Multiplier: x" + currentMultiplier;
        scoreText.text = "Score: " + currentScore;
    }

    public void NormalHit()
    {
        currentScore += scorePerNote *currentMultiplier;
        NoteHit();

        normalHits++;
    }
    
    public void GoodHit()
    {
        currentScore += scorePerGoodNote * currentMultiplier;
        NoteHit();

        goodHits++;
    }

    public void PerfectHit()
    {
        currentScore += scorePerPerfectNote * currentMultiplier;
        NoteHit();

        perfectHits++;
    }

    public void NoteMissed()
    {
        Debug.Log("Missed!");

        currentMultiplier = 1;
        multiplierTracker = 0;

        multiplierText.text = "Multiplier: x" + currentMultiplier;

        missedHits++;
    }
}

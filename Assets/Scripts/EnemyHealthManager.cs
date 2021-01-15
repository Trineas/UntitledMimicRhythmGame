using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthManager : MonoBehaviour
{
    public static EnemyHealthManager instance;

    public int maximum, current, minimum, damagePerHit;
    public Image mask, fill;
    public Color color;

    public Light playerLight;

    public int notesMissed;

    void Start()
    {
        instance = this;
    }

    void Update()
    {
        GetCurrentFill();

        //int percentage = current / maximum * 100;

        if (current <= 300 && current > 150)
        {
            color = Color.yellow;
        }
        else if (current <= 150)
        {
            color = Color.red;
        }
        else
        {
            color = Color.green;
        }
    }

    private void GetCurrentFill()
    {
        float currentOffset = current - minimum;
        float maximumOffset = maximum - minimum;
        float fillAmount = currentOffset / maximumOffset;
        mask.fillAmount = fillAmount;

        fill.color = color;
    }

    public void NoteMissed()
    {
        if (notesMissed >= 1)
        {
            GameManager.instance.currentHealth--;
            GameManager.instance.UpdateUI();
            notesMissed = 0;
        }
        else
        {
            notesMissed = 0;
        }
    }

    public void Hurt()
    {
        current -= damagePerHit;
        playerLight.intensity = 0f;
    }
}

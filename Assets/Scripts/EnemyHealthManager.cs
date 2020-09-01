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

    void Start()
    {
        instance = this;
    }

    void Update()
    {
        GetCurrentFill();

        if (current <= 50 && current > 25)
        {
            color = Color.red;
        }
        else if (current <= 25)
        {
            color = Color.yellow;
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

    public void Hurt()
    {
        current -= damagePerHit;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreKeeper : MonoBehaviour
{
    private uint score = 0;
    private bool scoreChangeAllowed = true;
    private Text scoreDisplay;

    // Start is called before the first frame update
    void Start()
    {
        scoreDisplay = GetComponent<Text>();

        InvokeRepeating("timeBonus", 0f, .1f);
    }

    // Update is called once per frame
    void Update()
    {
        scoreDisplay.text = "SCORE: " + score.ToString("000000000");
    }

    void timeBonus()
    {
        addScore(1);
    }

    public void addScore(uint points)
    {
        if (scoreChangeAllowed)
        {
            uint x = score + points;
            
            if (x <= 999999999) score = x;
            else
            {
                score = 999999999;
                disableScoreChange();
            }
        }
    }

    public void disableScoreChange()
    {
        scoreChangeAllowed = false;
        CancelInvoke();
    }
}

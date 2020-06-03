using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreKeeper : MonoBehaviour
{
    public bool heartHighScore = false;
    private int score = 0;
    private bool scoreChangeAllowed = true;
    private Text scoreDisplay;
    private int highScore;

    // Start is called before the first frame update
    void Start()
    {
        scoreDisplay = GetComponent<Text>();
        highScore = PlayerPrefs.GetInt("HighScore" + heartHighScore.ToString(), 0);

        InvokeRepeating("timeBonus", 0f, .1f);
    }

    // Update is called once per frame
    void Update()
    {
        scoreDisplay.text = "HIGH SCORE: " + highScore.ToString("000000000") + "\nSCORE: " +  score.ToString("000000000");
    }

    void timeBonus()
    {
        addScore(1);
    }

    public void addScore(int points)
    {
        if (scoreChangeAllowed)
        {
            int x = score + points;

            if (x <= 999999999)
            {
                if (x >= 0) score = x;
                else score = 0;
            }
            else
            {
                score = 999999999;
                disableScoreChange();
            }
        }

        if (score > highScore) highScore = score;
    }

    public void disableScoreChange()
    {
        scoreChangeAllowed = false;
        CancelInvoke();
    }

    void OnDestroy()
    {
        PlayerPrefs.SetInt("HighScore", highScore);
    }
}

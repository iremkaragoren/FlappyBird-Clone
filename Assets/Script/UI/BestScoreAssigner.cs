using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BestScoreAssigner : MonoBehaviour
{
    [SerializeField] private ScoreTextAssigner m_scoreTextAssigner;
    [SerializeField] private TextMeshProUGUI m_bestScoreText;

    private int m_bestScore;

    

    private void OnEnable()
    {
        OnBestScoreAssigned();
    }

    private void OnBestScoreAssigned()
    {
        m_bestScore= PlayerPrefs.GetInt("HighScore", 0);
        var score = m_scoreTextAssigner.Score;
        
        if (score >= m_bestScore)
        {
            m_bestScore = score;
             PlayerPrefs.SetInt("HighScore", score);
            m_bestScoreText.text = m_bestScore.ToString();
        }
        else
        {
            m_bestScoreText.text = m_bestScore.ToString();
        }
        
    }


   

    
}

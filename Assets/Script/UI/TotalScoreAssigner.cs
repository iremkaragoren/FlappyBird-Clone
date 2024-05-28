using System;
using TMPro;
using UnityEngine;

public class TotalScoreAssigner : MonoBehaviour
{
    [SerializeField] private ScoreTextAssigner m_scoreTextAssigner;
    [SerializeField] private TextMeshProUGUI m_totalScoreText;
    

    private void OnEnable()
    {
        var score = m_scoreTextAssigner.Score;
        Debug.Log("Score" + score);
        m_totalScoreText.text = score.ToString();
    }

   
}
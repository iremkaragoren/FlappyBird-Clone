using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class ScoreTextAssigner : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI m_scoreText;
    private int m_score;
    public int Score => m_score;
    
    private void Start()
    {
        m_score = 0;
    }
    private void OnEnable()
    {
        BirdDetector.OnSuccuessColliderIsTriggered += OnScoreIncrease;
    }

    private void OnDisable()
    {
        BirdDetector.OnSuccuessColliderIsTriggered -= OnScoreIncrease;
    }

    public void OnScoreIncrease()
    {
        m_score++;
        m_scoreText.text = m_score.ToString();
       
    }
}

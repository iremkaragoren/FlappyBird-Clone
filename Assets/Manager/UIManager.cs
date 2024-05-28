using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class UIManager : MonoBehaviour
{
    public static event Action OnLevelStart;
  
    [SerializeField] private GameObject m_startLevel;
    [SerializeField] private GameObject m_failLevel;
    [SerializeField] private GameObject m_inGame;
    
    private void OnEnable()
    {
        BirdDetector.OnDeathColliderIsTriggered += OnLevelFailed;
    }
    
    private void OnDisable()
    {
        BirdDetector.OnDeathColliderIsTriggered -= OnLevelFailed;
    }

    private void OnLevelFailed()
    {
        m_inGame.SetActive(false);
        m_failLevel.SetActive(true);
    }

    public void LevelStart()
    {
        m_startLevel.SetActive(false);
        m_inGame.SetActive(true);
       OnLevelStart?. Invoke();
    }

    public void RetryLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);// Bu sadece restart etmek için
        //Bir de sıralı scene kullanıyorsan olabilir
    }
}

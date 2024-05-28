using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FailScreenView : MonoBehaviour
{
    [SerializeField] private GameObject m_endGameText;
    [SerializeField] private GameObject m_retryButton;
    

    private void OnEnable()
    {
        StartCoroutine(ActiveEndGameElementDelayed());
    }
    

    IEnumerator ActiveEndGameElementDelayed()
    {
        m_endGameText.SetActive(false);
        m_retryButton.SetActive(false);
        yield return new WaitForSeconds(0.5f);
        m_endGameText.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        m_retryButton.SetActive(true);

    }

    private void OnDisable()
    {
        StopCoroutine(ActiveEndGameElementDelayed());
    }
}

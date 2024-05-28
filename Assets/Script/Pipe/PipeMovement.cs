using System;
using UnityEngine;

public class PipeMovement : MonoBehaviour
{
    [SerializeField] private float m_pipeSpeed;
    private bool m_isLevelStarted = true;
    private void OnEnable()
    {
       
        BirdDetector.OnDeathColliderIsTriggered += OnLevelFailed;
    }

    private void OnLevelFailed()
    {
        m_isLevelStarted = false;
    }

    private void Update()
    {
       if(m_isLevelStarted)
         transform.position += Vector3.left * m_pipeSpeed * Time.deltaTime;
    }

    private void OnDisable()
    {
        BirdDetector.OnDeathColliderIsTriggered -= OnLevelFailed;
    }
}
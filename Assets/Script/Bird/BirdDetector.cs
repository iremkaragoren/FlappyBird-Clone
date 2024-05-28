using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BirdDetector : MonoBehaviour
{
    public static event Action OnSuccuessColliderIsTriggered;

    public static event Action OnGroundColliderIsTriggered;

    public static event Action OnDeathColliderIsTriggered;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("WinCollider"))
        {
            OnSuccuessColliderIsTriggered?.Invoke();
        }
        /*
        else if (other.CompareTag("DeathCollider"))
        {
            OnDeathColliderIsTriggered?.Invoke();
        }*/
        else if (other.CompareTag("GroundCollider"))
        {
            OnGroundColliderIsTriggered?.Invoke();
            OnDeathColliderIsTriggered?.Invoke();
        }
        
        if (other.TryGetComponent(out PipeDetector pipeDetector))
        {
            Debug.Log("Inside");
            OnDeathColliderIsTriggered?.Invoke();
        }
    }
}
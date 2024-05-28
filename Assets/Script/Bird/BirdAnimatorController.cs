using UnityEngine;

public class BirdAnimatorController : MonoBehaviour
{
    [SerializeField] private Animator m_anim;

    private void Awake()
    {
        Initialize();
    }

    private void Initialize()
    {
        if (m_anim == null)
            m_anim = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        BirdDetector.OnDeathColliderIsTriggered += OnDisableAnim;
    }

    private void OnDisableAnim()
    {
        m_anim.enabled = false;
    }

    private void OnDisable()
    {
        BirdDetector.OnDeathColliderIsTriggered -= OnDisableAnim;
    }
}
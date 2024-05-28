using System;
using UnityEngine;

public class BirdMovement : MonoBehaviour
{
    public static event Action OnButtonPresed;//Okunması zor, arada boşluk yok birbirine girmiş.
    [SerializeField] private float m_jumpRange;
    [SerializeField] private Transform m_Transform;

    private Rigidbody2D m_rigidbody2D;
    private Quaternion m_initialRotation;
    private Quaternion m_targetRotation;// Anlaşılmayan isimlendirme...
    private Quaternion m_target2Rotation;// Anlaşılmayan isimlendirme...

    public float m_rotationSpeed = 60.0f;
    private bool isRotating = false;
    private float m_elapsedTime = 2f;

    private bool m_isBirdMovement;

    private void Awake()
    {
        Initialize();
        //Bunlar ne yapıyor? Belirli bir Fonksiyon ile belirtilebilirdi.
        //İkinisi arada boşluk yok okunması zor.
        m_initialRotation = Quaternion.Euler(0, 0, 0);
        m_targetRotation = Quaternion.Euler(0, 0, 17);
        m_target2Rotation = Quaternion.Euler(0, 0, -17);
    }


    public void Initialize()
    {
        if (m_Transform == null)
            m_Transform = transform;

        m_rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        UIManager.OnLevelStart += OnLevelStart;
        BirdDetector.OnDeathColliderIsTriggered += OnLevelFailed;
        BirdDetector.OnGroundColliderIsTriggered += OnGroundFailed;
    }

    private void OnGroundFailed()
    {
       m_rigidbody2D.velocity=Vector2.zero;
        m_rigidbody2D.isKinematic = true;
    }

    private void OnLevelStart()
    {
        m_isBirdMovement = true;
        m_rigidbody2D.isKinematic = false;
    }

    private void OnLevelFailed()
    {
        m_isBirdMovement = false;
        
    }

    private void Update()
    {
        if (m_isBirdMovement)
        {
            var t = Time.deltaTime * m_rotationSpeed;//Boşluk
            if (Input.GetMouseButtonDown(0))
            {
                OnButtonPresed?.Invoke();//Boşluk
                m_rigidbody2D.velocity = Vector2.up * m_jumpRange;
                m_elapsedTime = Time.time + 0.3f;
                transform.rotation = Quaternion.Lerp(transform.rotation, m_targetRotation, t);
            }

            if (Time.time >= m_elapsedTime)
                transform.rotation = Quaternion.Lerp(transform.rotation, m_target2Rotation, t);
        }
        
    }

    private void OnDisable()
    {
        UIManager.OnLevelStart -= OnLevelStart;
        BirdDetector.OnDeathColliderIsTriggered -= OnLevelFailed;
        BirdDetector.OnGroundColliderIsTriggered -= OnGroundFailed;

    }
}



   
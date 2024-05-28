using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    [SerializeField] private float m_pipeHight;

    [SerializeField] private GameObject m_pipe;
    private readonly float m_maxTime = 1;
    private float m_timer;
    private bool m_isSpawnerActive;


    private void OnEnable()
    {
        UIManager.OnLevelStart += OnSpawnerActive;
        BirdDetector.OnDeathColliderIsTriggered += OnLevelFailed;
    }

    private void OnLevelFailed()
    {
        m_isSpawnerActive = false;
    }

    private void OnSpawnerActive()
    {
        m_isSpawnerActive = true;
        //Kod Fazlalığı
        /*
        var m_newPipe = Instantiate(m_pipe);
        
        m_newPipe.transform.position =
            transform.position + new Vector3(0, Random.Range(-m_pipeHight, m_pipeHight), 0);
        */
    }

    private void Update()
    {
        if (m_isSpawnerActive==true)
        {
            if (m_timer > m_maxTime)
            {
                var m_newPipe = Instantiate(m_pipe);
                
                m_newPipe.transform.position =
                    transform.position + new Vector3(0, Random.Range(-m_pipeHight, m_pipeHight), 0);
                
                Destroy(m_newPipe, 15);
                m_timer = 0;
            }

            m_timer += Time.deltaTime;
        }
    }

    private void OnDisable()
    {
        UIManager.OnLevelStart -= OnSpawnerActive;
        BirdDetector.OnDeathColliderIsTriggered -= OnLevelFailed;
    }
}
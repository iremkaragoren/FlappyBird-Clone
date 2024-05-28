using UnityEngine;

public class StartSceenManager : MonoBehaviour
{
    
    [SerializeField] private GameObject m_bird;
    [SerializeField] private PipeSpawner m_spawner;
    [SerializeField] private PipeMovement m_pipeMovement;

    private Rigidbody2D m_birdRb;
    
    private bool m_isStartActive = true;


    // private void Awake()
    // {
    //     Initialize();
    //     m_spawner.SetActiveSpawner(false);
    //     m_pipeMovement.SetActivePipeMovement(false);
    // }
    //
    // public void Initialize()
    // {
    //     m_birdRb = m_bird.GetComponent<Rigidbody2D>();
    // }

    
}
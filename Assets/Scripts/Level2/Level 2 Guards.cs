using TMPro;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class Level2Guards : MonoBehaviour
{
    enum EnemyAIActions { searching, chasing, catching }

    private EnemyAIActions currentState;
    private NavMeshAgent agent;

    [SerializeField] private Transform[] checkpoints;
    private int currentCheckPointIndex;

    private GameObject player;
    private float distanacePlayer;

    private const float distanaceAttack = 0.5f;
    private const float distanaceFollowing = 1.0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentState = EnemyAIActions.searching;
        agent = GetComponent<NavMeshAgent>();
        currentCheckPointIndex = 0;
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (player == null)
        {
            return;
        }
        DetermineCurrentState();
        FollowingCurrentState();
    }
    private void DetermineCurrentState()
    {
        distanacePlayer = Vector3.Distance(player.transform.position, transform.position);
        if (distanacePlayer < distanaceAttack)
        {
            currentState = EnemyAIActions.catching;
        }
        else if (distanacePlayer < distanaceFollowing)
        {
            currentState = EnemyAIActions.chasing;
        }
        else
        {
            currentState = EnemyAIActions.searching;
        }
    }
    private void FollowingCurrentState()
    {
        switch (currentState)
        {
            case EnemyAIActions.searching:

                if (!agent.pathPending && agent.remainingDistance < 0.5f)
                {
                    //close to player
                    agent.SetDestination(checkpoints[currentCheckPointIndex].position);
                    currentCheckPointIndex++;
                    if (currentCheckPointIndex >= checkpoints.Length)
                    {
                        currentCheckPointIndex = 0;
                    }
                }
                break;
            case EnemyAIActions.chasing:
                agent.SetDestination(player.transform.position);
                break;
            case EnemyAIActions.catching:
                agent.SetDestination(player.transform.position);
                break;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        // player gets caught and teleported back
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.transform.position = new Vector3(646.2f, -21.428f, 408.99f);
        }
    }
}

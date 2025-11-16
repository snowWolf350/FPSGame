using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    StateMachine StateMachine;
    NavMeshAgent agent;

    public NavMeshAgent Agent { get => agent; }
    [SerializeField]string currentState;

    public Path path;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StateMachine = GetComponent<StateMachine>();
        agent = GetComponent<NavMeshAgent>();
        StateMachine.Initialise();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

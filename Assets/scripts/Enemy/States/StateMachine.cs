using UnityEngine;

public class StateMachine : MonoBehaviour
{
    public BaseState activeState;
    public PatrolState patrolState;
    //property for patrol state

    public void Initialise()
    {
        patrolState = new PatrolState();
        changeState( patrolState );
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (activeState != null)
        {
            activeState.Perform();
        }
    }
    public void changeState(BaseState newState)
    {
        //check if active state != null
        if (activeState != null)
        {
            activeState.Exit();
        }
        activeState = newState;

        if (activeState != null)
        {
            //setup a new state
            activeState.StateMachine = this;
            //assign an enemy class
            activeState.enemy = GetComponent<Enemy>();
            activeState.Enter();
        }
    }
}

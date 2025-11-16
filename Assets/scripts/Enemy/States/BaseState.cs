public abstract class BaseState
{
    //instance of enemy
    public Enemy enemy;
    //instance of stateMachine
    public StateMachine StateMachine;

    public abstract void Enter();

    public abstract void Perform();
    public abstract void Exit();
}
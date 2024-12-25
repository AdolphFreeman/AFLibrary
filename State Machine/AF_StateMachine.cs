using UnityEngine;

public class AF_StateMachine : MonoBehaviour
{
    protected AF_State CurrentState;
    public string currentStateName;

    private void Update()
    {
        CurrentState?.StateUpdate();
    }

    public void ChangeState(AF_State state)
    {
        CurrentState?.StateExit();
        CurrentState = state;
        CurrentState?.StateEnter();
        currentStateName = state.ToString();
    }
}

public interface AF_State
{
    public void StateEnter(){}
    public void StateUpdate(){}
    public void StateExit(){}
}
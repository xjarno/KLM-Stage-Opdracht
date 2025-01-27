using UnityEngine;

public class StateMachine : MonoBehaviour
{
    private AbstractState currentState;
    public AbstractState CurrentState { get => currentState; }

    private void Awake()
    {
        AbstractState[] states = GetComponents<AbstractState>();
        if (states.Length == 0) 
        {
            throw new System.Exception("There must be at least one abstractState component added to this gameObject ");
        }
        currentState = states[0];
        currentState.Enter();
    }
    private void Update()
    {
        currentState.UpdateState();
    }

    private void FixedUpdate()
    {
        currentState.FixedUpdateState();
    }

    private void LateUpdate()
    {
        currentState.LateUpdateState();
    }

    public void ChangeState(AbstractState state)
    {
        currentState = state;
        currentState.Enter();
    }
}

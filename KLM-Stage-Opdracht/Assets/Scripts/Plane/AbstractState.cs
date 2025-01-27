using UnityEngine;

public abstract class AbstractState : MonoBehaviour
{
    protected StateMachine correspondingStateMachine;

    [Tooltip("The states this state can transition to")]
    [SerializeField] protected AbstractState[] exitStates;

    private void Awake()
    {
        correspondingStateMachine = GetComponent<StateMachine>();
    }

    // A method to let the statemachine know which state to enter
    public abstract void Enter(); 
    public virtual void UpdateState() { }
    public virtual void FixedUpdateState() { }
    public virtual void LateUpdateState() { }

    // method to give the next state to switch to
    public virtual void Exit(AbstractState goToState) 
    {
        correspondingStateMachine.ChangeState(goToState);
    }

}

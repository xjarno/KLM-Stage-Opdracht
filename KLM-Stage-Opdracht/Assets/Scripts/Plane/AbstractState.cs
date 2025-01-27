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

    // A method to let the statemachine know which state to enter.
    public abstract void Enter(); 

    // Update method
    public virtual void UpdateState() { }

    // FixedUpdate method
    public virtual void FixedUpdateState() { }

    // Lateupdate method
    public virtual void LateUpdateState() { }

    // Method to give the next state to switch to.
    public virtual void Exit(AbstractState goToState) 
    {
        correspondingStateMachine.ChangeState(goToState);
    }

}

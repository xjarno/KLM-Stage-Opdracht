using UnityEngine;

public abstract class AbstractState : MonoBehaviour
{
    protected StateMachine correspondingStateMachine;
   
    public Rigidbody rb;
    public float radius;
    public float speed = 1f;
    public float maxSpeed = 5f;
    public float maxForce = 1f;
    public float distance;
    public Vector3 desiredVelocity;
    public Vector3 steering;

    [Tooltip("The states this state can transition to")]
    [SerializeField] protected AbstractState[] exitStates;

    private void Awake()
    {
        correspondingStateMachine = GetComponent<StateMachine>();
    }

    // A method to let the statemachine know which state to enter.
    public abstract void Enter(); 

    public virtual void GetVariables()
    {
        rb = GetComponent<Rigidbody>();
    }

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

    public virtual void Seek(Vector3 target, Vector3 plane)
    {
        transform.LookAt(plane + rb.velocity);
        desiredVelocity = Vector3.Normalize(target - plane) * maxSpeed;
        steering = desiredVelocity - rb.velocity;
        if (steering.magnitude > maxForce)
        {
            steering = Truncate(steering, maxForce);
        }
        steering /= rb.mass;
        rb.velocity = Truncate(rb.velocity + steering, maxSpeed);
        distance = Vector3.Distance(target, plane);
    }

    public Vector3 Truncate(Vector3 value, float max)
    {
        var result = Vector3.Normalize(value) * max;
        return result;
    }

}

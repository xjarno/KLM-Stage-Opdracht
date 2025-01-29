using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractState : MonoBehaviour
{
    protected StateMachine correspondingStateMachine;
   
    protected Rigidbody rb;
    protected float radius;
    protected float speed = 1f;
    protected float maxSpeed = 5f;
    protected float maxForce = 0.7f;
    protected float distance;
    protected float searchRadius = 10f;
    protected Vector3 desiredVelocity;
    protected Vector3 steering;
    protected Vector3 difference;
    protected List<Vector3> nearbyObjects = new List<Vector3>();

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

    public virtual void Avoidance(Vector3 plane)
    {
        foreach (GameObject obj in Object.FindObjectsOfType(typeof(GameObject)))
        {
            if(obj != this && Vector3.Distance(obj.transform.position, plane) < searchRadius)
            {
                float dotProduct = Vector3.Dot(plane, obj.transform.position);
                if(dotProduct > 0.4f)
                {
                    nearbyObjects.Add(obj.transform.position);
                }
            }
        }
        if (nearbyObjects.Count > 0) 
        {
            foreach(Vector3 location in nearbyObjects)
            {
                difference = location - plane;
                difference *= 1-distance;
                steering += difference;

                steering /= nearbyObjects.Count;
                steering -= rb.velocity;
                if (steering.magnitude > maxForce)
                {
                    steering = Truncate(steering, maxForce);
                }
                steering /= rb.mass;
            }
            nearbyObjects.Clear();
        }
    }

    public Vector3 Truncate(Vector3 value, float max)
    {
        var result = Vector3.Normalize(value) * max;
        return result;
    }

}

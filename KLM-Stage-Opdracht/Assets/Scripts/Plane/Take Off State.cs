using UnityEngine;
using UnityEngine.UIElements;

public class TakeOffState : AbstractState
{
    public GameObject Ui;
    public GameObject target;
    private UIController UIController;
    private Rigidbody rb;
    private bool airborne;
    private float distance;
    [SerializeField] private float radius = 2f;
    [SerializeField] private float speed = 1f;
    [SerializeField] private float maxSpeed = 5f;
    [SerializeField] private float maxForce = 1f;
    private Vector3 desiredVelocity;
    private Vector3 steering;
    private Vector3 targetDirection;
    




    public override void Enter()
    {
        rb = GetComponent<Rigidbody>();
        UIController = Ui.GetComponent<UIController>();
    }

    public override void UpdateState()
    {
        base.UpdateState();
        if ( airborne == true)
        {
            Exit(exitStates[0]);
        }
    }

    public override void FixedUpdateState()
    {
        base.FixedUpdateState();
        transform.LookAt(transform.position + rb.velocity);

        // creates velocity to the target
        desiredVelocity = Vector3.Normalize(target.transform.position - transform.position)* maxSpeed;
        steering = desiredVelocity - rb.velocity;
        if (steering.magnitude > maxForce) 
        {
            steering = Truncate(steering, maxForce);
        }
        steering /= rb.mass;
        rb.velocity = Truncate(rb.velocity+steering, maxSpeed);
        distance = Vector3.Distance(target.transform.position, transform.position);
        if(distance <= radius)
        {
            airborne = true;
        }
    }
}

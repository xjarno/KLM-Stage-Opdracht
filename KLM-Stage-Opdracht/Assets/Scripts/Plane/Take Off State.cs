using UnityEngine;

public class TakeOffState : AbstractState
{
    public GameObject Ui;
    public GameObject target;
    private UIController UIController;
    private Rigidbody rb;
    private bool airborne;
    private float distance;
    [SerializeField] private float speed = 1f;
    [SerializeField] private float maxSpeed = 5f;
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

        desiredVelocity = Vector3.Normalize(target.transform.position - transform.position)* maxSpeed;
        steering = desiredVelocity -rb.velocity;
        steering /= rb.mass;
        rb.velocity = Truncate(rb.velocity+steering, maxSpeed);
        distance = Vector3.Distance(target.transform.position, transform.position);
        if(distance <= 2f)
        {
            airborne = true;
        }
    }
}

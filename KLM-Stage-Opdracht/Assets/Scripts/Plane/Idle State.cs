using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : AbstractState
{
    public GameObject UI;
    private Rigidbody rb;
    private UIController UIController;
    private float maxCoordinate = 50;
    private float minCoordinate = -50;
    private float minYLevel = 5;
    private float maxYLevel = 10;
    private float distance;
    [SerializeField] private float radius = 5;
    [SerializeField] private float speed = 1f;
    [SerializeField] private float maxSpeed = 5f;
    [SerializeField] private float maxForce = 1f;
    private Vector3 desiredVelocity;
    private Vector3 steering;
    private Vector3 desiredTarget;


    public override void Enter()
    {
        UIController = UI.GetComponent<UIController>();
        rb = GetComponent<Rigidbody>();    
    }

    public override void UpdateState()
    {
        base.UpdateState();
        if(UIController.command == "Park")
        {
            Exit(exitStates[0]);
        }
    }

    public override void FixedUpdateState()
    {
        base.FixedUpdateState();

        transform.LookAt(transform.position + rb.velocity);

        if(desiredTarget == null || distance <= radius)
        {
            desiredTarget = new Vector3(Random.Range(minCoordinate, maxCoordinate),Random.Range(minYLevel ,maxYLevel), Random.Range(minCoordinate, maxCoordinate));
        }
        desiredVelocity = Vector3.Normalize(desiredTarget - transform.position) * maxSpeed;
        steering = desiredVelocity - rb.velocity;
        if (steering.magnitude > maxForce)
        {
            steering = Truncate(steering, maxForce);
        }
        steering /= rb.mass;
        rb.velocity = Truncate(rb.velocity + steering, maxSpeed);
        distance = Vector3.Distance(desiredTarget, transform.position);

    }
}

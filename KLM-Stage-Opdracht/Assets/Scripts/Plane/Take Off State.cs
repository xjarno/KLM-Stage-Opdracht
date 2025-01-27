using UnityEngine;

public class TakeOffState : AbstractState
{
    public GameObject Ui;
    private UIController UIController;
    private Rigidbody rb;
    private bool airborne;
    private float speed = 1f;
    private float pitchChange = 0.01f;

    public override void Enter()
    {
        rb = GetComponent<Rigidbody>();
        UIController = Ui.GetComponent<UIController>();
    }

    public override void UpdateState()
    {
        base.UpdateState();
        if (UIController.command == "Park" && airborne == true)
        {
            Exit(exitStates[0]);
        }
    }

    public override void FixedUpdateState()
    {
        base.FixedUpdateState();
        rb.AddForce(transform.up * speed);
        rb.AddTorque(transform.right * pitchChange/ 50);
        if(transform.position.y >= 5f && transform.rotation.x >= -90)
        {
            pitchChange = -0.01f;
        } 

        if (transform.position.y > 0)
        { 
            airborne = true;
        }
    }

}

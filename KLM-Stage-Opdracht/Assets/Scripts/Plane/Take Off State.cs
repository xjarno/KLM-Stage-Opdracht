using UnityEngine;

public class TakeOffState : AbstractState
{
    public GameObject Ui;
    private UIController UIController;
    private Rigidbody rb;
    private bool airborne;
    private float speed;

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
        rb.AddForce(new Vector3(0, 0, 1));

        if (transform.position.y > 0)
        { 
            airborne = true;
        }
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParkState : AbstractState
{
    public GameObject Ui;
    private UIController UIController;
    private Rigidbody rb;
    public override void Enter()
    {
        rb = GetComponent<Rigidbody>();
        UIController = Ui.GetComponent<UIController>();
    }
    public override void UpdateState()
    {
        base.UpdateState();
        if(UIController.command == "Take Off")
        {
            Exit(exitStates[0]);
        }
    }

    public override void FixedUpdateState()
    {
        base.FixedUpdateState();
        rb.velocity = Vector3.zero;
    }
}

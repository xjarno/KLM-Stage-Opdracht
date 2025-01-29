using UnityEngine;

public class ParkState : AbstractState
{
    public GameObject Ui;
    public GameObject lookAtTarget;
    private UIController UIController;
    public override void Enter()
    {
        UIController = Ui.GetComponent<UIController>();
        GetVariables();
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
        transform.LookAt(lookAtTarget.transform.position);
    }
}

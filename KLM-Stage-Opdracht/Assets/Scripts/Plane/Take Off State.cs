using UnityEngine;

public class TakeOffState : AbstractState
{
    public GameObject target;
    private bool airborne;
    private Vector3 targetDirection;
    public override void Enter()
    {
        GetVariables();
        radius = 5;
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

        Seek(target.transform.position, transform.position);

        if(distance <= radius)
        {
            airborne = true;
        }
    }
}

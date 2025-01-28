using UnityEngine;

public class Landingstate : AbstractState
{
    public GameObject landingTarget;
    public override void Enter()
    {
        radius = 0.3f;
        maxSpeed = 3f;
        GetVariables();
    }

    public override void FixedUpdateState()
    {
        base.FixedUpdateState();

        Seek(landingTarget.transform.position, transform.position);
        if (distance <= radius) 
        {
            Exit(exitStates[0]);
        }
        
    }
}

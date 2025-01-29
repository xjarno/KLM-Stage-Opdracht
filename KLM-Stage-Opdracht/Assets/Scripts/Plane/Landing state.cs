using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Landingstate : AbstractState
{
    public GameObject[] landingTargets;
    private Vector3 targetToSeek;
    private int i;
    public override void Enter()
    {
        i = 0;
        radius = 0.3f;
        maxSpeed = 3f;
        GetVariables();
        targetToSeek = landingTargets[0].transform.position;
    }

    public override void FixedUpdateState()
    {
        base.FixedUpdateState();
        Seek(targetToSeek, transform.position);
        if (i == landingTargets.Length - 1)
        {
            maxSpeed = 2f;
            if (distance <= radius) 
            { 
                Exit(exitStates[0]);
            }
        }

        if (distance <= radius) 
        {
            i++;
            i = Mathf.Clamp(i, 0, landingTargets.Length - 1);
            targetToSeek = landingTargets[i].transform.position;
        }
    }
}

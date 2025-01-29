using System.Linq;
using UnityEngine;

public class AlignState : AbstractState
{
    public GameObject[] targets;
    private Vector3 seekTarget;
    private int i;
    public override void Enter()
    {
        i = 0;
        GetVariables();
        radius = 3;
        seekTarget = targets[0].transform.position;
    }

    public override void FixedUpdateState()
    {
        base.FixedUpdateState();
        Seek(seekTarget, transform.position);
        Avoidance(transform.position);
        if(i == targets.Length-1 && distance <= radius)
        {
            Exit(exitStates[0]);
        }
        if (distance <= radius) 
        {
            i++;
            i = Mathf.Clamp(i, 0, targets.Length - 1);
            seekTarget = targets[i].transform.position;
        }
    }
}

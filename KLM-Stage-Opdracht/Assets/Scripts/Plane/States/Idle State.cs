using UnityEngine;

public class IdleState : AbstractState
{
    public GameObject UI;
    private UIController UIController;
    private float maxCoordinatex = 50;
    private float minCoordinatex = -50;
    private float maxCoordinatez = 100;
    private float minCoordinatez = 0;
    private float minYLevel = 6;
    private float maxYLevel = 15;
    private Vector3 desiredTarget;


    public override void Enter()
    {
        UIController = UI.GetComponent<UIController>();
        GetVariables();
        radius = 5;
        desiredTarget = Vector3.zero;
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

        if(desiredTarget == null || distance <= radius || desiredTarget == Vector3.zero)
        {
            desiredTarget = new Vector3(Random.Range(minCoordinatex, maxCoordinatex),Random.Range(minYLevel ,maxYLevel), Random.Range(minCoordinatez, maxCoordinatez));
        }

        Seek(desiredTarget,transform.position);
        Avoidance(transform.position);

    }
}

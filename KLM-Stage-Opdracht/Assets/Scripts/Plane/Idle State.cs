using UnityEngine;

public class IdleState : AbstractState
{
    public GameObject UI;
    private UIController UIController;
    private float maxCoordinate = 50;
    private float minCoordinate = -50;
    private float minYLevel = 5;
    private float maxYLevel = 10;
    private Vector3 desiredTarget;


    public override void Enter()
    {
        UIController = UI.GetComponent<UIController>();
        GetVariables();
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

        if(desiredTarget == null || distance <= radius)
        {
            desiredTarget = new Vector3(Random.Range(minCoordinate, maxCoordinate),Random.Range(minYLevel ,maxYLevel), Random.Range(minCoordinate, maxCoordinate));
        }

        Seek(desiredTarget,transform.position);

    }
}

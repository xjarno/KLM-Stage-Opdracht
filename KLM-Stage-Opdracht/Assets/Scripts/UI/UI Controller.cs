using UnityEngine;
using TMPro;
using System.Collections.Generic;

public class UIController : MonoBehaviour
{
    public CameraManager cameraManager;

    // variables
    public string command;
    public GameObject[] planes;
    private List<GameObject> parked = new List<GameObject>();
    private List<GameObject> airborne = new List<GameObject>();
   

    //Functions
    public void TakeOffButton()
    {
        for (int i = 0; i < planes.Length; i++)
        {
            if(planes[i].gameObject.GetComponent<StateMachine>().CurrentState is ParkState)
            {
                if (!parked.Contains(planes[i].gameObject)) 
                { 
                    parked.Add(planes[i].gameObject);
                }
            }
        }
        if(parked.Count >= planes.Length)
        {
            command = "Take Off";
            parked.Clear();
        }
    }
    public void ParkButton() 
    {
       
        for (int i = 0; i < planes.Length; i++)
        {
            if (planes[i].gameObject.GetComponent<StateMachine>().CurrentState is IdleState)
            {
                if (!airborne.Contains(planes[i].gameObject))
                {
                    airborne.Add(planes[i].gameObject);
                }
                
            }
        }
        if (airborne.Count >= planes.Length)
        {
            command = "Park";
            airborne.Clear();
        }
    }
    public void LightsOnButton()
    {
        for(int i = 0;i < planes.Length; i++)
        {
            if(planes[i].gameObject.GetComponent<LightScript>().LightsOn == false)
            {
                command = "Lights On";
            }
        }
    }
    public void LightsOffButton()
    {
        for (int i = 0; i < planes.Length; i++)
        {
            if (planes[i].gameObject.GetComponent<LightScript>().LightsOn == true)
            {
                command = "Lights Off";
            }
        }
    }

    public void NextCamera()
    {
        cameraManager.SwitchNextCamera();
    }
}

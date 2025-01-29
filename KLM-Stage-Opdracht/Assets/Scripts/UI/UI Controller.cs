using UnityEngine;
using TMPro;

public class UIController : MonoBehaviour
{
    // variables
    public string command;
    public GameObject[] planes;
    private int k;
    private int l;

    //Functions
    public void TakeOffButton()
    {
        for (int i = 0; i < planes.Length; i++)
        {
            if(planes[i].gameObject.GetComponent<StateMachine>().CurrentState is ParkState)
            {
                k++;
            }
        }
        if(k == planes.Length)
        {
            command = "Take Off";
            k = 0;
        }
    }
    public void ParkButton() 
    {
       
        for (int i = 0; i < planes.Length; i++)
        {
            if (planes[i].gameObject.GetComponent<StateMachine>().CurrentState is IdleState)
            {
                l++;
            }
        }
        if (l == planes.Length)
        {
            command = "Park";
            l = 0;
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
}

using UnityEngine;
using TMPro;

public class UIController : MonoBehaviour
{
    // variables
    public string command;

    //Functions
    public void TakeOffButton()
    {
        command = "Take Off";
    }
    public void ParkButton() 
    {
        command = "Park";
    }
    public void LightsOnButton()
    {
        command = "Lights On";
    }
    public void LightsOffButton()
    {
        command = "Lights Off";
    }
    public void DisplayText() 
    {
        Debug.Log(command);
    }
}

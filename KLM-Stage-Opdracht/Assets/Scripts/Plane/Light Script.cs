using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightScript : MonoBehaviour
{
    public GameObject UI;
    public GameObject[] planeLights;
    public bool LightsOn = false;
    private UIController UIController;
    private void Awake()
    {
        UIController = UI.GetComponent<UIController>();
    }

    private void Update()
    {
        if (UIController.command == "Lights On")
        {
            for (int i = 0; i < planeLights.Length; i++)
            {
                planeLights[i].SetActive(true);
                LightsOn = true;
            }
        }
        if (UIController.command == "Lights Off")
        {
            for (int i = 0; i < planeLights.Length; i++)
            {
                planeLights[i].SetActive(false);
                LightsOn = false;
            }
        }
    }
}

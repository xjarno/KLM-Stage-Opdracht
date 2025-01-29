using UnityEngine;
using Cinemachine;

public class CameraManager : MonoBehaviour
{
    public CinemachineVirtualCamera[] cameras;

    public CinemachineVirtualCamera startCamera;
    private CinemachineVirtualCamera currentCamera;

    private int k = -1;

    private void Start()
    {
        currentCamera = startCamera;
        for (int i = 0; i < cameras.Length; i++)
        {
            if (cameras[i] == currentCamera)
            {
                cameras[i].Priority = 20;
            }
            else
            {
                cameras[i].Priority = 10;
            }
        }
    }
    
    public void SwitchNextCamera()
    {
        k++;
        k = Mathf.Clamp(k, 0, cameras.Length+1);
        currentCamera = cameras[k];
       
        currentCamera.Priority = 20;

        for (int i = 0; i < cameras.Length; i++)
        {
            if (cameras[i] != currentCamera)
            {
                cameras[i].Priority = 10;
            }
        }
        if (k == cameras.Length -1)
        {
            k = -1;
        }
    }
}

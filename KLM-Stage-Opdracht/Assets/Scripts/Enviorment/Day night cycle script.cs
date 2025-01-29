using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Daynightcyclescript : MonoBehaviour
{
    private void FixedUpdate()
    {
        transform.Rotate(new Vector3(0.05f,0,0));
    }
}

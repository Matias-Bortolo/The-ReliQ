using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    [HideInInspector]
    public bool boxOnTop;

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Box"))
        {
            boxOnTop = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Box"))
        {
            boxOnTop = false;
        }
    }
}

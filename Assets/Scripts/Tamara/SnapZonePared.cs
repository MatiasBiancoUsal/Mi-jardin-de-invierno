using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnapZonePared : MonoBehaviour
{
    public bool isOccupied = false;

    public Transform GetSnapPosition()
    {
        return transform;
    }

    public void Occupy()
    {
        isOccupied = true;
    }

    public void Release()
    {
        isOccupied = false;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnapZone : MonoBehaviour
{
    public bool isOccupied = false;

    public Transform GetSnapPosition()
    {
        return transform;
    }
}


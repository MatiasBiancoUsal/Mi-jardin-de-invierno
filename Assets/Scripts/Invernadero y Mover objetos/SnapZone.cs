using UnityEngine;

public class SnapZone : MonoBehaviour
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

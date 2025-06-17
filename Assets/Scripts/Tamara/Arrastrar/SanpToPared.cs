using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnapToPared : MonoBehaviour
{
    public float snapSpeed = 10f;
    public float snapDistance = 0.5f;

    private MuebleArrastrable mueble;
    private bool snapped = false;

    private void Start()
    {
        mueble = GetComponent<MuebleArrastrable>();
    }

    private void Update()
    {
        // Si no está siendo arrastrado y tiene un SnapZone cerca
        if (!mueble.isDragging && mueble.currentSnapZonePared != null && !snapped)
        {
            Vector3 targetPos = mueble.currentSnapZonePared.transform.position;
            float distance = Vector3.Distance(transform.position, targetPos);

            if (distance < snapDistance)
            {
                // Movimiento suave hacia la zona
                transform.position = Vector3.Lerp(transform.position, targetPos, Time.deltaTime * snapSpeed);

                // Si está muy cerca, fijarlo
                if (distance < 0.05f)
                {
                    transform.position = targetPos;
                    mueble.currentSnapZonePared.Occupy();
                    snapped = true;
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("SnapZonePared"))
        {
            SnapZonePared snapZone = other.GetComponent<SnapZonePared>();

            if (snapZone != null && !snapZone.isOccupied)
            {
                mueble.currentSnapZonePared = snapZone;
                snapped = false;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("SnapZonePared"))
        {
            SnapZonePared snapZone = other.GetComponent<SnapZonePared>();

            if (snapZone != null && mueble.currentSnapZonePared == snapZone)
            {
                mueble.currentSnapZonePared = null;
                snapped = false;
            }
        }
    }
}

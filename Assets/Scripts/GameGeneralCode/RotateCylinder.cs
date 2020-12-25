using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCylinder : MonoBehaviour
{
    public Vector3 initPosition;
    public Vector3 dragPosition;
    public float rotationSpeed;
    [SerializeField]private float angle;
    private void Update()
    {
        RotateCylinderUsingMousePos();
    }

    private void RotateCylinderUsingMousePos()
    {
        if (Input.GetMouseButtonDown(0))
        {
            initPosition = Input.mousePosition;
        }

        if (Input.GetMouseButton(0))
        {
            dragPosition = Input.mousePosition;
            Vector3 dispMouseVector = dragPosition - initPosition;
            angle =( dispMouseVector.x + dispMouseVector.y) ;
            transform.Rotate(0, angle * rotationSpeed * -1, 0);
            initPosition = dragPosition;
        }
    }
}

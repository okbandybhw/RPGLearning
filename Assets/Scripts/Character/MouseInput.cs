using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseInput : MonoBehaviour
{
    [HideInInspector]
    public Vector3 mouseInputPos;
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit rayHit;
        if (Physics.Raycast(ray, out rayHit, float.MaxValue))
        {
            mouseInputPos = rayHit.point;
        }
    }
}

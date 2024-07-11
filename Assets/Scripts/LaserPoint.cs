using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserPoint : MonoBehaviour
{
    public LineRenderer lineRenderer;
    public Transform gunBarrelPosition;
    public float maxDistance;
    public LayerMask layerToHit;
    //public float maxDistance;
    void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.right, maxDistance, layerToHit);
        lineRenderer.SetPosition(0, gunBarrelPosition.position);
        lineRenderer.SetPosition(1, hit.point);
            
    }
}

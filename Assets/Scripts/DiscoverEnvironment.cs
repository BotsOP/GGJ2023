using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class DiscoverEnvironment : MonoBehaviour
{
    public VineManager vineManager;
    public float stepSize;
    public float stepDelay;
    public Transform root;
    public Transform target;
    private OrientedPoint orientedPoint;
    private float previousTime;
    
    private readonly Vector3[] dirs = 
    {
        Vector3.up, 
        Vector3.forward,
        Vector3.down,
        Vector3.down,
        Vector3.back,
        Vector3.up
    };

    private void OnEnable()
    {
        orientedPoint = new OrientedPoint(root.position, root.rotation);
    }

    private void OnDrawGizmos()
    {
        // OrientedPoint op = new OrientedPoint(transform1.position, Quaternion.Euler(angles));
        //
        // op.rotation = Quaternion.LookRotation(transform2.position - transform1.position);
        // op.rotation = Quaternion.FromToRotation(op.rotation * Vector3.up, transform1.up) * op.rotation;

        Gizmos.DrawSphere(orientedPoint.position, 0.1f);
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(orientedPoint.position, orientedPoint.rotation * Vector3.forward + orientedPoint.position);
        Gizmos.color = Color.red;
        Gizmos.DrawLine(orientedPoint.position, orientedPoint.rotation * Vector3.right + orientedPoint.position);
        Gizmos.color = Color.green;
        Gizmos.DrawLine(orientedPoint.position, orientedPoint.rotation * Vector3.up + orientedPoint.position);
    }

    private void FixedUpdate()
    {
        if (Time.time > previousTime + stepDelay)
        {
            previousTime = Time.time;
            orientedPoint = CalculateNextPoint(orientedPoint);
            Transform tempTransform = new GameObject().transform;
            tempTransform.position = orientedPoint.position;
            tempTransform.rotation = orientedPoint.rotation;
            tempTransform.parent = transform;
            vineManager.transforms.Add(tempTransform);
        }
    }

    private OrientedPoint CalculateNextPoint(OrientedPoint origin)
    {
        Vector3 originalPos = origin.position;

        Quaternion originalRotation = origin.rotation;
        origin.rotation = Quaternion.LookRotation(target.position - originalPos);
        origin.rotation = Quaternion.FromToRotation(origin.rotation * Vector3.up, originalRotation * Vector3.up) * origin.rotation;

        for (int i = 0; i < dirs.Length; i++)
        {
            Vector3 dir = (origin.rotation * dirs[i] * stepSize);
            RaycastHit hit;
            if (Physics.Raycast(origin.position + origin.rotation * Vector3.up * 0.1f, dir, out hit, stepSize))
            {
                origin.position = hit.point - dir * 0.01f;
                
                origin.rotation = Quaternion.LookRotation(hit.point - originalPos, hit.normal);
                break;
            }
            Debug.DrawRay(origin.position, dir, Color.yellow);
            origin.position += dir;
        }
        return origin;
    }

    struct OrientedPoint
    {
        public Vector3 position;
        public Quaternion rotation;

        public OrientedPoint(Vector3 position, Quaternion rotation)
        {
            this.position = position;
            this.rotation = rotation;
        }
    }
}

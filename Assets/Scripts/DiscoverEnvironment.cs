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
    public float minDelay;
    public float maxDelay;
    public float minDistance;
    public float maxDistance;
    public Transform root;
    public Transform target;
    
    private OrientedPoint orientedPoint;
    private float previousTime;
    private Vector3 lastPos;
    private Vector3 secondLastPos;
    private Vector3 thirdLastPos;

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
        // Gizmos.DrawSphere(orientedPoint.position, 0.1f);
        // Gizmos.color = Color.blue;
        // Gizmos.DrawLine(orientedPoint.position, orientedPoint.rotation * Vector3.forward + orientedPoint.position);
        // Gizmos.color = Color.red;
        // Gizmos.DrawLine(orientedPoint.position, orientedPoint.rotation * Vector3.right + orientedPoint.position);
        // Gizmos.color = Color.green;
        // Gizmos.DrawLine(orientedPoint.position, orientedPoint.rotation * Vector3.up + orientedPoint.position);
    }

    private void FixedUpdate()
    {
        if (vineManager.transforms.Count > 2)
        {
            secondLastPos = vineManager.transforms[^2].position;
            lastPos = vineManager.transforms[^1].position;
        }
        
        Vector3 headVinePos = vineManager.transforms[^1].position;
        float currentStepDelay = Vector3.Distance(headVinePos, target.position);
        currentStepDelay = VineManager.Remap(currentStepDelay, minDistance, maxDistance, maxDelay, minDelay);
        currentStepDelay = Mathf.Clamp(currentStepDelay, minDelay, maxDelay);
        
        if (Time.time > previousTime + currentStepDelay)
        {
            previousTime = Time.time;
            orientedPoint = CalculateNextPoint(orientedPoint);
            //Debug.Log($"{orientedPoint.position} {lastPos} {secondLastPos} {thirdLastPos}");
            if (!(orientedPoint.position == lastPos || orientedPoint.position == secondLastPos))
            {
                Transform tempTransform = new GameObject().transform;
                tempTransform.position = orientedPoint.position;
                tempTransform.rotation = orientedPoint.rotation;
                tempTransform.parent = transform;
            
                vineManager.transforms.Add(tempTransform);
            }
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
            //Debug.DrawRay(origin.position, dir, Color.yellow);
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

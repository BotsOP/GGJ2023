using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtVinePosition : MonoBehaviour
{
    public VineManager vineManager;
    public float smoothSpeed;
    public Vector2 min, max;

    private void OnEnable()
    {
        min = new Vector2(Mathf.Min(min.x, max.x), Mathf.Min(min.y, max.y));
        max = new Vector2(Mathf.Max(min.x, max.x), Mathf.Max(min.y, max.y));
    }

    private void Update()
    {
        Vector3 vineHeadPos = vineManager.transforms[^1].position;
        Quaternion lookRotation = Quaternion.LookRotation(vineHeadPos - transform.position);
        transform.rotation = Quaternion.Lerp(transform.rotation, lookRotation, smoothSpeed);
        Debug.Log($"{DistanceFromSquare(transform.position)}");
    }

    public float DistanceFromSquare(Vector2 point)
    {
        if (point.x < min.x)
        {
            if (point.y < min.y)
                return Vector2.Distance(point, min);
            if (point.y > max.y)
                return Vector2.Distance(point, new Vector2(min.x, max.y));
            return min.x - point.x;
        }
        
        if (point.x > max.x)
        {
            if (point.y < min.y)
                return Vector2.Distance(point, new Vector2(max.x, min.y));
            if (point.y > max.y)
                return Vector2.Distance(point, max);
            return point.x - max.x;
        }
        
        if (point.y < min.y)
            return min.y - point.y;
        if (point.y > max.y)
            return point.y - max.y;
        
        return 0f;
    }
}

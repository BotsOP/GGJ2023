using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtVine : MonoBehaviour
{
    public VineManager vineManager;
    public float smoothSpeed;

    private void Update()
    {
        Vector3 vineHeadPos = vineManager.transforms[^1].position;
        Quaternion lookRotation = Quaternion.LookRotation(vineHeadPos - transform.position);
        transform.rotation = Quaternion.Lerp(transform.rotation, lookRotation, smoothSpeed);
    }
}

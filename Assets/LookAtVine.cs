using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtVine : MonoBehaviour
{
    public VineManager vineManager;
    public float smoothSpeed;
    [SerializeField] private Vector2 point1;
    [SerializeField] private Vector2 point2;


    private void Update()
    {
        Vector3 vineHeadPos = vineManager.transforms[^1].position;
        transform.position = Vector3.Lerp(transform.position, new Vector3(vineHeadPos.x, vineHeadPos.y, transform.position.z), smoothSpeed);   
    }
}

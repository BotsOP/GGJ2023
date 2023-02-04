using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BecomeChild : MonoBehaviour
{

    [SerializeField] private Transform parent;
    [SerializeField] private UnityEvent SeanEenSoordVan;
    [SerializeField] private Animator KusjeKriebel;
    public void ActivateChildMode() 
    {
        Debug.Log("2");
        KusjeKriebel.enabled = false;
        transform.parent = parent;
        SeanEenSoordVan.Invoke();
    }


}

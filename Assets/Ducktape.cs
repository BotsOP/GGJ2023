using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Ducktape : MonoBehaviour
{    // Update is called once per frame
    [SerializeField] private UnityEvent DucktapeCode;
    void Update()
    {
        if (Camera2DTilt.soep) 
        { 
            DucktapeCode.Invoke();
            this.enabled= false;
        }
    }
}

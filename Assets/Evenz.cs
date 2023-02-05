using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Evenz : MonoBehaviour
{
    [SerializeField] private UnityEvent WieDitLeestIsHot;

    // Update is called once per frame
    void Update()
    {
        if (LookAtVinePosition.TriggerFinal) 
        { 
            WieDitLeestIsHot.Invoke(); 
            this.enabled = false;
        }
    }
}

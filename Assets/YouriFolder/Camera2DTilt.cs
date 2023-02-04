using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera2DTilt : MonoBehaviour
{
    [SerializeField][Range(-1.0f, 1.0f)] private static float rootXPos;
    [SerializeField] private Animator KusjeKriebel;
    [SerializeField] Vector3 turingPointPos;
    [SerializeField] Vector3 turingPointRot;

    public void Update()
    {
        transform.position = new Vector3 (turingPointPos.x * rootXPos,1 - turingPointPos.y * -Mathf.Abs(rootXPos) ,-10 - turingPointPos.z * -Mathf.Abs(rootXPos));   
        transform.rotation = Quaternion.Euler(turingPointRot * rootXPos);   
        if(rootXPos == 1) 
        {

            KusjeKriebel.SetBool("IsLinks", false);
            ActivateAnimatorAndFallAsleep();

        }
        else if(-rootXPos == 1) 
        {
            KusjeKriebel.SetBool("IsLinks", true);
            ActivateAnimatorAndFallAsleep();
        }
    }

    public void ActivateAnimatorAndFallAsleep() 
    {
        KusjeKriebel.enabled = true;
        this.enabled = false;
    }
}

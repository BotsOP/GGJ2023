using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transition : MonoBehaviour
{
    public Vector2 leftScreen;
    public Vector2 rightScreen;

    public GameObject player;

    private void Update()
    {
        if(player.transform.position.x < leftScreen.x)
        {
            Camera2DTilt.rootXPos = remap(player.transform.position.x, leftScreen.x, leftScreen.y,0f,-1f);
            if(player.transform.position.x < leftScreen.y)
            {
                Camera2DTilt.rootXPos = -1;
            }
        }else if(player.transform.position.x > rightScreen.x)
        {
            Camera2DTilt.rootXPos = remap(player.transform.position.x, rightScreen.x, rightScreen.y, 0f, 1f);
            if (player.transform.position.x > rightScreen.y)
            {
                Camera2DTilt.rootXPos = 1;
            }
        }
        else
        {
            Camera2DTilt.rootXPos = 0;
        }
    }

    public static float remap(float val, float in1, float in2, float out1, float out2)
    {
        return out1 + (val - in1) * (out2 - out1) / (in2 - in1);
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transition : MonoBehaviour
{
    public Vector2 leftScreen;
    public Vector2 rightScreen;

    public GameObject player;
    public CinemachineCameraOffset cameraOffset;
    public bool moveCam;
    public float speed;
    private void Update()
    {
        if (!moveCam)
        {
            if (player.transform.position.x < leftScreen.x)
            {
                Camera2DTilt.rootXPos = remap(player.transform.position.x, leftScreen.x, leftScreen.y, 0f, -1f);
                cameraOffset.m_Offset.x = remap(player.transform.position.x, leftScreen.x, leftScreen.y, 0f, 6f);
                if (player.transform.position.x < leftScreen.y)
                {
                    Camera2DTilt.rootXPos = -1;
                    cameraOffset.m_Offset.x = 6;
                    moveCam = true;
                }
            }
            else if (player.transform.position.x > rightScreen.x)
            {
                Camera2DTilt.rootXPos = remap(player.transform.position.x, rightScreen.x, rightScreen.y, 0f, 1f);
                cameraOffset.m_Offset.x = remap(player.transform.position.x, rightScreen.x, rightScreen.y, 0f, -6f);
                if (player.transform.position.x > rightScreen.y)
                {
                    Camera2DTilt.rootXPos = 1;
                    cameraOffset.m_Offset.x = -6;
                    moveCam = true;

                }
            }
            else
            {
                Camera2DTilt.rootXPos = 0;
                cameraOffset.m_Offset.x = 0;
            }
        }
        
        if (moveCam)
        {
            if (player.transform.position.x < 0f)
            {
                cameraOffset.m_Offset.x += Time.deltaTime * speed;
            }
            else
            {
                cameraOffset.m_Offset.x -= Time.deltaTime * speed;
            }
        }
        if(cameraOffset.m_Offset.x >= 50 || cameraOffset.m_Offset.x <= -50)
        {
            player.SetActive(false);
            this.enabled = false;
        }
    }

    public static float remap(float val, float in1, float in2, float out1, float out2)
    {
        return out1 + (val - in1) * (out2 - out1) / (in2 - in1);
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement3D : MonoBehaviour
{
    public Vector2 previousPosition;
    public Vector2 currentPosition;

    public float previousTime;
    public float currentTime;
    public float timeBetweenPresses;

    public Rigidbody playerRigidbody;

    public float maxTime;
    public float maxDistance;
    public float speedMultiplier = 60;
    public float upSpeedMultiplier;
    public float distance;
    public Vector3 direction;

    public float previousComboTime;
    public float currentComboTime;
    public float timeBetweenCombo;
    public int currentCombo;
    public float[] comboReachTimes;
    public float[] comboDecreaseTimes;
    public float comboDecreaseTime;
    public float comboSpeedMultiplier;
    public float[] comboSpeedMultipliers;

    private void Start()
    {
        playerRigidbody = transform.GetComponent<Rigidbody>();
    }
    void Update()
    {
        //=====================================================Row 0
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            previousPosition = currentPosition;
            currentPosition = new Vector2(0, 0);
            CalcTime();
            CalcVelocity();
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            previousPosition = currentPosition;
            currentPosition = new Vector2(0, 1);
            CalcTime();
            CalcVelocity();
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            previousPosition = currentPosition;
            currentPosition = new Vector2(0, 2);
            CalcTime();
            CalcVelocity();
        }

        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            previousPosition = currentPosition;
            currentPosition = new Vector2(0, 3);
            CalcTime();
            CalcVelocity();
        }

        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            previousPosition = currentPosition;
            currentPosition = new Vector2(0, 4);
            CalcTime();
            CalcVelocity();
        }

        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            previousPosition = currentPosition;
            currentPosition = new Vector2(0, 5);
            CalcTime();
            CalcVelocity();
        }

        if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            previousPosition = currentPosition;
            currentPosition = new Vector2(0, 6);
            CalcTime();
            CalcVelocity();
        }

        if (Input.GetKeyDown(KeyCode.Alpha8))
        {
            previousPosition = currentPosition;
            currentPosition = new Vector2(0, 7);
            CalcTime();
            CalcVelocity();
        }

        if (Input.GetKeyDown(KeyCode.Alpha9))
        {
            previousPosition = currentPosition;
            currentPosition = new Vector2(0, 8);
            CalcTime();
            CalcVelocity();
        }

        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            previousPosition = currentPosition;
            currentPosition = new Vector2(0, 9);
            CalcTime();
            CalcVelocity();
        }
        //===============================================Row 1

        if (Input.GetKeyDown(KeyCode.Q))
        {
            previousPosition = currentPosition;
            currentPosition = new Vector2(1, 0);
            CalcTime();
            CalcVelocity();
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            previousPosition = currentPosition;
            currentPosition = new Vector2(1, 1);
            CalcTime();
            CalcVelocity();
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            previousPosition = currentPosition;
            currentPosition = new Vector2(1, 2);
            CalcTime();
            CalcVelocity();
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            previousPosition = currentPosition;
            currentPosition = new Vector2(1, 3);
            CalcTime();
            CalcVelocity();
        }

        if (Input.GetKeyDown(KeyCode.T))
        {
            previousPosition = currentPosition;
            currentPosition = new Vector2(1, 4);
            CalcTime();
            CalcVelocity();
        }

        if (Input.GetKeyDown(KeyCode.Y))
        {
            previousPosition = currentPosition;
            currentPosition = new Vector2(1, 5);
            CalcTime();
            CalcVelocity();
        }

        if (Input.GetKeyDown(KeyCode.U))
        {
            previousPosition = currentPosition;
            currentPosition = new Vector2(1, 6);
            CalcTime();
            CalcVelocity();
        }

        if (Input.GetKeyDown(KeyCode.I))
        {
            previousPosition = currentPosition;
            currentPosition = new Vector2(1, 7);
            CalcTime();
            CalcVelocity();
        }

        if (Input.GetKeyDown(KeyCode.O))
        {
            previousPosition = currentPosition;
            currentPosition = new Vector2(1, 8);
            CalcTime();
            CalcVelocity();
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            previousPosition = currentPosition;
            currentPosition = new Vector2(1, 9);
            CalcTime();
            CalcVelocity();
        }
        //==========================================Row 2
        if (Input.GetKeyDown(KeyCode.A))
        {
            previousPosition = currentPosition;
            currentPosition = new Vector2(2, 0);
            CalcTime();
            CalcVelocity();
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            previousPosition = currentPosition;
            currentPosition = new Vector2(2, 1);
            CalcTime();
            CalcVelocity();
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            previousPosition = currentPosition;
            currentPosition = new Vector2(2, 2);
            CalcTime();
            CalcVelocity();
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            previousPosition = currentPosition;
            currentPosition = new Vector2(2, 3);
            CalcTime();
            CalcVelocity();
        }

        if (Input.GetKeyDown(KeyCode.G))
        {
            previousPosition = currentPosition;
            currentPosition = new Vector2(2, 4);
            CalcTime();
            CalcVelocity();
        }

        if (Input.GetKeyDown(KeyCode.H))
        {
            previousPosition = currentPosition;
            currentPosition = new Vector2(2, 5);
            CalcTime();
            CalcVelocity();
        }

        if (Input.GetKeyDown(KeyCode.J))
        {
            previousPosition = currentPosition;
            currentPosition = new Vector2(2, 6);
            CalcTime();
            CalcVelocity();
        }

        if (Input.GetKeyDown(KeyCode.K))
        {
            previousPosition = currentPosition;
            currentPosition = new Vector2(2, 7);
            CalcTime();
            CalcVelocity();
        }

        if (Input.GetKeyDown(KeyCode.L))
        {
            previousPosition = currentPosition;
            currentPosition = new Vector2(2, 8);
            CalcTime();
            CalcVelocity();
        }

        if (Input.GetKeyDown(KeyCode.Semicolon))
        {
            previousPosition = currentPosition;
            currentPosition = new Vector2(2, 9);
            CalcTime();
            CalcVelocity();
        }
        //===============================================Row 3
        if (Input.GetKeyDown(KeyCode.Z))
        {
            previousPosition = currentPosition;
            currentPosition = new Vector2(3, 0);
            CalcTime();
            CalcVelocity();
        }

        if (Input.GetKeyDown(KeyCode.X))
        {
            previousPosition = currentPosition;
            currentPosition = new Vector2(3, 1);
            CalcTime();
            CalcVelocity();
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            previousPosition = currentPosition;
            currentPosition = new Vector2(3, 2);
            CalcTime();
            CalcVelocity();
        }

        if (Input.GetKeyDown(KeyCode.V))
        {
            previousPosition = currentPosition;
            currentPosition = new Vector2(3, 3);
            CalcTime();
            CalcVelocity();
        }

        if (Input.GetKeyDown(KeyCode.B))
        {
            previousPosition = currentPosition;
            currentPosition = new Vector2(3, 4);
            CalcTime();
            CalcVelocity();
        }

        if (Input.GetKeyDown(KeyCode.N))
        {
            previousPosition = currentPosition;
            currentPosition = new Vector2(3, 5);
            CalcTime();
            CalcVelocity();
        }

        if (Input.GetKeyDown(KeyCode.M))
        {
            previousPosition = currentPosition;
            currentPosition = new Vector2(3, 6);
            CalcTime();
            CalcVelocity();
        }

        if (Input.GetKeyDown(KeyCode.Comma))
        {
            previousPosition = currentPosition;
            currentPosition = new Vector2(3, 7);
            CalcTime();
            CalcVelocity();
        }

        if (Input.GetKeyDown(KeyCode.Period))
        {
            previousPosition = currentPosition;
            currentPosition = new Vector2(3, 8);
            CalcTime();
            CalcVelocity();
        }

        if (Input.GetKeyDown(KeyCode.Slash))
        {
            previousPosition = currentPosition;
            currentPosition = new Vector2(3, 9);
            CalcTime();
            CalcVelocity();
        }
        //===================================================Combo
        if (currentCombo > 0)
        {
            comboDecreaseTime -= Time.deltaTime;
            if (comboDecreaseTime <= 0)
            {
                DecreaseCombo();
            }
        }
    }
    void CalcVelocity()
    {
        distance = Vector2.Distance(previousPosition, currentPosition);
        direction = new Vector3(currentPosition.y - previousPosition.y, (previousPosition.x - currentPosition.x) * upSpeedMultiplier, 0f);
        if (distance <= maxDistance)
        {
            playerRigidbody.AddForce(direction * speedMultiplier * comboSpeedMultiplier);
        }
    }
    void CalcTime()
    {
        previousTime = currentTime;
        currentTime = Time.time;
        timeBetweenPresses = currentTime - previousTime;
        if (timeBetweenPresses >= maxTime)
        {
            previousPosition = currentPosition;
            previousTime = currentTime;
        }
    }

    void ApplyCombo()
    {
        previousComboTime = currentComboTime;
        currentComboTime = Time.time;
        timeBetweenCombo = currentComboTime - previousComboTime;
        if (timeBetweenCombo <= comboReachTimes[currentCombo])
        {
            currentCombo++;
            if (currentCombo > (comboReachTimes.Length - 1))
            {
                currentCombo = (comboReachTimes.Length - 1);
            }
            else
            {
                comboSpeedMultiplier = comboSpeedMultipliers[currentCombo];
                EffectTrigger();
            }
        }
        if (currentCombo > 0)
        {
            comboDecreaseTime = comboDecreaseTimes[currentCombo - 1];
        }
    }

    void DecreaseCombo()
    {
        currentCombo--;
        comboSpeedMultiplier = comboSpeedMultipliers[currentCombo];
        if (currentCombo > 0)
        {
            comboDecreaseTime = comboDecreaseTimes[currentCombo - 1];
        }
    }

    void EffectTrigger()
    {
        //put effects for getting a higher combo
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Pickup")
        {
            ApplyCombo();
        }
    }
}

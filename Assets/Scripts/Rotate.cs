using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    public float xSpeed;
    public float ySpeed;
    public float zSpeed;

    public Vector2 xRandomSpeedRange;
    public Vector2 yRandomSpeedRange;
    public Vector2 zRandomSpeedRange;

    public float maxXSpeed;
    public float maxYSpeed;
    public float maxZSpeed;

    public string axis;

    public bool isRotateSpeedRandom = false;

    public int interval = 10;

    private bool isRotatingPaused = false;

    // Start is called before the first frame update
    void Start()
    {

        if(isRotateSpeedRandom == true)
        {
            xSpeed = Random.Range(xRandomSpeedRange.x, xRandomSpeedRange.y);
            ySpeed = Random.Range(yRandomSpeedRange.x, yRandomSpeedRange.y);
            zSpeed = Random.Range(zRandomSpeedRange.x, zRandomSpeedRange.y);
        }

        xSpeed *= Time.deltaTime;
        ySpeed *= Time.deltaTime;
        zSpeed *= Time.deltaTime;

        StartCoroutine(IncreaseRotationalSpeed());
    }

    // Update is called once per frame
    void Update()
    {
        //if (PauseGame.isGamePaused)
        //{
        //    return;
        //}

        if (isRotatingPaused)
            return;

        ModifyRotation();
        transform.Rotate(xSpeed, ySpeed, zSpeed);
    }

    private IEnumerator IncreaseRotationalSpeed()
    {
        float speed = 0;
        float maxSpeed = 0;

        switch (axis)
        {
            case "x":
                speed = xSpeed;
                maxSpeed = maxXSpeed;
                break;
            case "y":
                speed = ySpeed;
                maxSpeed = maxYSpeed;
                break;
            case "z":
                speed = zSpeed;
                maxSpeed = maxZSpeed;
                break;
        }

        while (speed <= maxSpeed)
        {
            yield return new WaitForSeconds(interval);
            xSpeed *= 1.1f;
            ySpeed *= 1.1f;
            zSpeed *= 1.1f;

            switch (axis)
            {
                case "x":
                    speed = xSpeed;
                    maxSpeed = maxXSpeed;
                    break;
                case "y":
                    speed = ySpeed;
                    maxSpeed = maxYSpeed;
                    break;
                case "z":
                    speed = zSpeed;
                    maxSpeed = maxZSpeed;
                    break;
            }
        }
    }

    public void PauseRotating()
    {
        isRotatingPaused = true;
    }

    public void ResumeRotating()
    {
        isRotatingPaused = false;
    }

    protected virtual void ModifyRotation()
    {
        
    }

}

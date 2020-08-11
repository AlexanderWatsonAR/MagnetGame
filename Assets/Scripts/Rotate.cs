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

    public bool isRotateSpeedRandom = false;

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
    }

    // Update is called once per frame
    void Update()
    {
        //if (PauseGame.isGamePaused)
        //{
        //    return;
        //}

        if (GameStopWatch.TimeElapsedInSeconds > 1 && GameStopWatch.TimeElapsedInSeconds % 30 == 0)
        {
            xSpeed *= 1.1f;
            ySpeed *= 1.1f;
            zSpeed *= 1.1f;
        }

        ModifyRotation();
        transform.Rotate(xSpeed, ySpeed, zSpeed);
    }

    protected virtual void ModifyRotation()
    {
        
    }

}

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
        transform.Rotate(xSpeed * Time.deltaTime, ySpeed * Time.deltaTime, zSpeed * Time.deltaTime);
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

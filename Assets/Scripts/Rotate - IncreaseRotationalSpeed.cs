using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateIncreaseRotationalSpeed : MonoBehaviour
{
    public Rotate rotate;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(IncreaseRotationalSpeed());
    }

    private IEnumerator IncreaseRotationalSpeed()
    {
        float speed = 0;
        float maxSpeed = 0;

        switch (rotate.axis)
        {
            case "x":
                speed = rotate.xSpeed;
                maxSpeed = rotate.maxXSpeed;
                break;
            case "y":
                speed = rotate.ySpeed;
                maxSpeed = rotate.maxYSpeed;
                break;
            case "z":
                speed = rotate.zSpeed;
                maxSpeed = rotate.maxZSpeed;
                break;
        }

        while (speed <= maxSpeed)
        {
            yield return new WaitForSeconds(rotate.interval);
            rotate.xSpeed *= 1.1f;
            rotate.ySpeed *= 1.1f;
            rotate.zSpeed *= 1.1f;

            switch (rotate.axis)
            {
                case "x":
                    speed = rotate.xSpeed;
                    maxSpeed = rotate.maxXSpeed;
                    break;
                case "y":
                    speed = rotate.ySpeed;
                    maxSpeed = rotate.maxYSpeed;
                    break;
                case "z":
                    speed = rotate.zSpeed;
                    maxSpeed = rotate.maxZSpeed;
                    break;
            }
        }
    }
}

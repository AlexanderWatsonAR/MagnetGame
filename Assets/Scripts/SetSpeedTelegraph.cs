using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetSpeedTelegraph : MonoBehaviour
{
    public enum Speed
    {
        STOP, DeadSlow, Slow, Normal, Fast, VeryFast, Reverse
    }

    //private float rotationalAcceleration = 5.0f;
    private float[] targetRotationalSpeeds = { 0.0f, 30.0f, 60.0f, 120.0f, 160.0f, 200.0f, -120.0f };

    private float movementAcceleration = 0.01f;
    private Speed currentSpeed = Speed.STOP;
    private Speed previousSpeed = Speed.STOP;
    private float[] yLocalPositions = { 2.75f, 2.315f, 1.885f, 1.455f, 1.0f, 0.625f, 0.235f };
    public Material greyParticle;
    public Material whiteParticle;
    public GameObject[] objects;

    private IEnumerator ChangeSpeed()
    {
        while (true)
        {
            yield return new WaitForSeconds(10);
            if (currentSpeed == Speed.Reverse)
                currentSpeed = Speed.Normal;
            else
            {
                previousSpeed = currentSpeed;
                currentSpeed++;
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ChangeSpeed());
    }

    // Update is called once per frame
    void Update()
    {
        if (currentSpeed == previousSpeed)
            return;

        if (transform.localPosition.y + movementAcceleration > yLocalPositions[(int)currentSpeed] &&
            transform.localPosition.y - movementAcceleration < yLocalPositions[(int)currentSpeed])
        {
            foreach(GameObject go in objects)
                go.GetComponent<Renderer>().material = greyParticle;

            objects[(int)currentSpeed].GetComponent<Renderer>().material = whiteParticle;
            GameObject.FindGameObjectWithTag("Spinning").GetComponent<Rotate>().ySpeed = targetRotationalSpeeds[(int)currentSpeed];
        }
        else
        {
            if (transform.localPosition.y > yLocalPositions[(int)currentSpeed])
                transform.localPosition += Vector3.down * movementAcceleration;
            else
                transform.localPosition += Vector3.up * movementAcceleration;
        }
    }
}

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
    private float[] targetAnimationSpeeds = { 0.0f, 0.1f, 0.2f, 0.5f, 0.9f, 1.2f, 1.0f };

    private float movementAcceleration = 0.6f;
    private Speed currentSpeed = Speed.STOP;
    private Speed previousSpeed = Speed.STOP;
    private float[] yLocalPositions = { 2.75f, 2.315f, 1.885f, 1.455f, 1.0f, 0.625f, 0.235f };
    public Material greyParticle;
    public Material whiteParticle;
    public GameObject[] objects;

    GameObject spinningWheel;
    GameObject movingBlock;

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
        spinningWheel = GameObject.FindGameObjectWithTag("Spinning");
        movingBlock = GameObject.FindGameObjectWithTag("Moving");
        movingBlock.GetComponent<Animator>().speed = 0;
        StartCoroutine(ChangeSpeed());
    }

    // Update is called once per frame
    void Update()
    {
        if (currentSpeed == previousSpeed)
            return;

        if (!movingBlock.GetComponent<Animator>().enabled)
            movingBlock.GetComponent<Animator>().enabled = true;

        if (transform.localPosition.y + (movementAcceleration * Time.smoothDeltaTime) > yLocalPositions[(int)currentSpeed] &&
            transform.localPosition.y - (movementAcceleration * Time.smoothDeltaTime) < yLocalPositions[(int)currentSpeed])
        {
            foreach(GameObject go in objects)
                go.GetComponent<Renderer>().material = greyParticle;

            objects[(int)currentSpeed].GetComponent<Renderer>().material = whiteParticle;
            spinningWheel.GetComponent<Rotate>().ySpeed = targetRotationalSpeeds[(int)currentSpeed];
            if (currentSpeed != Speed.Reverse)
            {
                if (movingBlock.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("NewBlockExtrudeAnimation"))
                    movingBlock.GetComponent<Animator>().Play("NewBlockIntrudeAnimation");
                movingBlock.GetComponent<Animator>().speed = targetAnimationSpeeds[(int)currentSpeed];
            }
            else
            {
                movingBlock.GetComponent<Animator>().Play("NewBlockExtrudeAnimation");
                movingBlock.GetComponent<Animator>().speed = 1;
            }
        }
        else
        {
            if (transform.localPosition.y > yLocalPositions[(int)currentSpeed])
                transform.localPosition += Vector3.down * (movementAcceleration * Time.smoothDeltaTime);
            else
                transform.localPosition += Vector3.up * (movementAcceleration * Time.smoothDeltaTime);
        }
    }
}

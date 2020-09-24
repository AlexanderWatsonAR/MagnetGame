using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blob : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if ((GetComponent<HingeJoint>() == null && collision.gameObject.tag != "Blob") ||
            (GetComponent<HingeJoint>() != null && collision.gameObject.tag == "Blob"))
            return;
        gameObject.AddComponent<HingeJoint>();
        GetComponent<HingeJoint>().connectedBody = collision.rigidbody;
        //GetComponent<HingeJoint>().breakForce = 10.0f;
        //GetComponent<HingeJoint>().breakTorque = 10.0f;
    }
}

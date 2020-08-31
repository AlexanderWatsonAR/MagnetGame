using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetRigidBodyVelocity : MonoBehaviour
{
    [HideInInspector]
    public Transform parent;
    public float speed = 15.5f;

    public bool isConstantForce = true;
    public bool isVelocity = true;

    // Start is called before the first frame update
    void Start()
    {
        if(isVelocity)
         GetComponent<Rigidbody>().velocity = new Vector3(parent.forward.x * speed, parent.forward.y * speed, parent.forward.z * speed);

        speed /= 3;
        if(GetComponent<ConstantForce>() != null && isConstantForce)
            GetComponent<ConstantForce>().force = new Vector3(parent.forward.x * speed, parent.forward.y * speed, parent.forward.z * speed);
    }
}

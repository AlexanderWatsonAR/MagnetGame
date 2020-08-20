using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetRigidBodyVelocity : MonoBehaviour
{
    public Transform parent;
    public float speed = 15.5f;

    // Start is called before the first frame update
    void Start()
    {
        //Transform parent = transform.parent;
        //while(!parent.gameObject.name.Contains("Gun"))
        //{
        //    parent = parent.parent;
        //}

        //Transform gun = GameObject.Find("Gun 1").transform;

        GetComponent<Rigidbody>().velocity = new Vector3(parent.forward.x * speed, parent.forward.y * speed, parent.forward.z * speed);

        speed /= 3;
        if(GetComponent<ConstantForce>() != null)
            GetComponent<ConstantForce>().force = new Vector3(parent.forward.x * speed, parent.forward.y * speed, parent.forward.z * speed);
    }
}

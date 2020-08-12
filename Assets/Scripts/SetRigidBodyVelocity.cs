using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetRigidBodyVelocity : MonoBehaviour
{
    public float speed = 15.5f;

    // Start is called before the first frame update
    void Start()
    {
        //Transform parent = transform.parent;
        //while(!parent.gameObject.name.Contains("Gun"))
        //{
        //    parent = parent.parent;
        //}

        Transform gun = GameObject.Find("Gun 1").transform;

        GetComponent<Rigidbody>().velocity = new Vector3(gun.forward.x * speed, gun.forward.y * speed, gun.forward.z * speed);
    }
}

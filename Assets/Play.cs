using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Play : MonoBehaviour
{
    public GameObject blob;
    Vector3 startPosition;

    private void Start()
    {
        startPosition = blob.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.anyKeyDown)
        {
            //GetComponent<Animator>().enabled = true;
            //GetComponent<Animator>().Play(0);

            GameObject.Instantiate(blob);
            blob.transform.position = startPosition;

        }
    }
}

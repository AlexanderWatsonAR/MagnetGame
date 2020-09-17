using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Play : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        if(Input.anyKeyDown)
        {
            GetComponent<Animator>().enabled = true;
            GetComponent<Animator>().Play(0);
        }
    }
}

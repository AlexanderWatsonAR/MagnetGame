using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestruct : MonoBehaviour
{
    public float elapedMilliseconds;

    IEnumerator Start()
    {
        yield return new WaitForSeconds(elapedMilliseconds / 1000);

        Destroy(gameObject);
    }
}

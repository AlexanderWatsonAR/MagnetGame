using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyIfChildless : MonoBehaviour
{
    // Start is called before the first frame update
    IEnumerator Start()
    {
        while(transform.childCount > 0)
            yield return new WaitForSeconds(5);

        Destroy(gameObject);
    }
}

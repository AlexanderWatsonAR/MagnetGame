using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnExitTrigger : MonoBehaviour
{
    private void OnTriggerExit(Collider other)
    {
        Destroy(other.gameObject);
    }
}

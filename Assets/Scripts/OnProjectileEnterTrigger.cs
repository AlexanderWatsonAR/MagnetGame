using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnProjectileEnterTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        ScoreManager.Score++;
        Destroy(other.gameObject);
    }
}

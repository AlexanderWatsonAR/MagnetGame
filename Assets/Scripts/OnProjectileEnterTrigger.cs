using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnProjectileEnterTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        //ScoreManager.Score += other.GetComponent<CollectableProperties>().score;
        BatteryManager.BatteryStatus += other.GetComponent<CollectableProperties>().charge;
        if(other.name.Contains("Battery"))
            Destroy(other.gameObject);
    }
}

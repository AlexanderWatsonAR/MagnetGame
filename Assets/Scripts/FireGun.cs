using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireGun : MonoBehaviour
{
    public bool randomizeInterval;
    public float Interval;
    public Projectile[] projectiles;
    public float FirstShotInSeconds;

    [HideInInspector]
    public bool hasShootingStarted;
    public bool fireModeActive = true;

    // Start is called before the first frame update
    IEnumerator Start()
    {
        yield return new WaitForSeconds(FirstShotInSeconds);
        hasShootingStarted = true;
        StartCoroutine(Shoot());
    }

    IEnumerator Shoot()
    {
        while (fireModeActive)
        {
            if (!fireModeActive)
                yield return new WaitForSeconds(Interval);
            else
            {
                int index = Random.Range(0, projectiles.Length);

                GameObject shot = Instantiate(projectiles[index].prefab);
                
                shot.tag = "Metallic";
                shot.transform.localScale = projectiles[index].localScale;
                shot.transform.position = transform.position + projectiles[index].localPosition;
                shot.transform.eulerAngles = projectiles[index].localRotation;

                if (shot.GetComponent<Rigidbody>() != null)
                {
                    shot.GetComponent<Rigidbody>().mass = projectiles[index].mass;
                    //shot.GetComponent<Rigidbody>().angularVelocity
                    shot.GetComponent<Rigidbody>().velocity = Vector3.zero;
                    //shot.GetComponent<Rigidbody>().velocity = new Vector3(transform.forward.x * projectiles[index].speed, transform.forward.y * projectiles[index].speed, transform.forward.z * projectiles[index].speed);
                    shot.AddComponent<CollectableProperties>();

                    shot.GetComponent<CollectableProperties>().goldQuantity = projectiles[index].collectableProperty.GetComponent<CollectableProperties>().goldQuantity;
                    shot.GetComponent<CollectableProperties>().silverQuantity = projectiles[index].collectableProperty.GetComponent<CollectableProperties>().silverQuantity;
                    shot.GetComponent<CollectableProperties>().copperQuantity = projectiles[index].collectableProperty.GetComponent<CollectableProperties>().copperQuantity;
                    shot.GetComponent<CollectableProperties>().emeraldQuantity = projectiles[index].collectableProperty.GetComponent<CollectableProperties>().emeraldQuantity;
                    shot.GetComponent<CollectableProperties>().diamondQuality = projectiles[index].collectableProperty.GetComponent<CollectableProperties>().diamondQuality;
                    shot.GetComponent<CollectableProperties>().charge = projectiles[index].collectableProperty.GetComponent<CollectableProperties>().charge;
                    shot.GetComponent<CollectableProperties>().isDiamagnetic = projectiles[index].collectableProperty.GetComponent<CollectableProperties>().isDiamagnetic;
                    shot.GetComponent<CollectableProperties>().isMagnetic = projectiles[index].collectableProperty.GetComponent<CollectableProperties>().isMagnetic;
                }

                shot.SetActive(true);

                float tempInterval = Interval;
                if (randomizeInterval)
                    tempInterval = Random.Range(Interval / 2, Interval);

                yield return new WaitForSeconds(tempInterval);
            }
        }
    }
}

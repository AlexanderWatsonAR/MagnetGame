using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireGun : MonoBehaviour
{
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

                if (shot.GetComponent<Rigidbody>())
                {
                    shot.GetComponent<Rigidbody>().mass = projectiles[index].mass;
                    //shot.GetComponent<Rigidbody>().angularVelocity
                    shot.GetComponent<Rigidbody>().velocity = new Vector3(transform.forward.x * projectiles[index].speed, transform.forward.y * projectiles[index].speed, transform.forward.z * projectiles[index].speed);
                    shot.AddComponent<CollectableProperties>();
                    shot.GetComponent<CollectableProperties>().score = projectiles[index].score;
                    shot.GetComponent<CollectableProperties>().charge = projectiles[index].charge;
                    shot.GetComponent<CollectableProperties>().isDiamagnetic = projectiles[index].isDiamagnetic;
                    shot.GetComponent<CollectableProperties>().isMagnetic = projectiles[index].isMagnetic;
                }
                else
                {
                    //Transform child = shot.transform.GetChild(0);
                    //int itr = 0;
                    //while (child.gameObject.GetComponent<SetRigidBodyVelocity>() == null)
                    //{
                    //    itr++;
                    //    child = shot.transform.GetChild(itr);
                    //}
                    //child.gameObject.GetComponent<SetRigidBodyVelocity>().parent = transform;
                }

                shot.SetActive(true);

                yield return new WaitForSeconds(Interval);
            }
        }
    }
}

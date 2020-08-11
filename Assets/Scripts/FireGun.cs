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
                shot.GetComponent<Rigidbody>().mass = projectiles[index].mass;
                shot.tag = "Metallic";
                shot.transform.localScale = projectiles[index].localScale;
                shot.transform.position = transform.position + projectiles[index].localPosition;
                shot.SetActive(true);
                shot.GetComponent<Rigidbody>().velocity = new Vector3(transform.forward.x * projectiles[index].speed, transform.forward.y * projectiles[index].speed, transform.forward.z * projectiles[index].speed);
                yield return new WaitForSeconds(Interval);
            }
        }
    }
}

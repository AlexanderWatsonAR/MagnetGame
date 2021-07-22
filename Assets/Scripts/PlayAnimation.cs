using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAnimation : MonoBehaviour
{
    public GameObject aGameObject;
    public string firstAnimationName;
    public GameObject bGameObject;
    public string secondAnimationName;

    public void PlayOther()
    {
        aGameObject.GetComponent<Animator>().enabled = true;
        aGameObject.GetComponent<Animator>().Play(firstAnimationName);

        if(bGameObject != null)
        {
            bGameObject.GetComponent<Animator>().enabled = true;
            bGameObject.GetComponent<Animator>().Play(secondAnimationName);
        }
    }
}

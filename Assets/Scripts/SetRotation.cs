using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetRotation : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        transform.eulerAngles = new Vector3(IntroSceneLoadData.LocalEulerAngle.x, IntroSceneLoadData.LocalEulerAngle.y, IntroSceneLoadData.LocalEulerAngle.z);
    }
}

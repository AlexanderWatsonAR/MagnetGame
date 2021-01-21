using UnityEngine;

public class DefineIntroSceneLoadData : MonoBehaviour
{
    public void DefineValue()
    {
        IntroSceneLoadData.LocalEulerAngle = transform.rotation.eulerAngles;
    }
}

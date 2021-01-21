using UnityEngine;

public static class IntroSceneLoadData
{
    private static Vector3 localEulerAngle;

    public static Vector3 LocalEulerAngle
    {
        get
        {
            return localEulerAngle;
        }

        set
        {
            localEulerAngle = value;
        }
    }

}

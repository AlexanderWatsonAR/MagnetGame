using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchSceneTrigger : MonoBehaviour
{
    public string sceneName;

    private void OnTriggerEnter(Collider other)
    {
        IntroSceneLoadData.LocalEulerAngle = other.transform.rotation.eulerAngles;
        SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
    }
}

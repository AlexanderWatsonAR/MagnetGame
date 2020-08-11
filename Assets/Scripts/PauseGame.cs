using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PauseGame : MonoBehaviour
{
    public GameObject pauseWindow;
    public GameObject deathWindow;

    public static bool isGamePaused = false;
    private bool isAtHome = true;

    private void OnApplicationPause(bool pause)
    {
        if (!isGamePaused && Time.frameCount > 0  && !isAtHome && !deathWindow.activeSelf)
        {
            Pause();
            pauseWindow.SetActive(true);
        }
    }

    public static void PleasePause()
    {
        isGamePaused = true;
        AudioSource[] allAudio = FindObjectsOfType<AudioSource>();
        foreach (AudioSource source in allAudio)
        {
            source.mute = true;
            source.Stop();
        }
        Time.timeScale = 0.0f;
    }

    public static void PleaseResume()
    {
        isGamePaused = false;
        AudioSource[] allAudio = FindObjectsOfType<AudioSource>();
        foreach (AudioSource source in allAudio)
        {
            source.mute = false;
            if (source.loop)
                source.Play();
        }
        Time.timeScale = 1.0f;
    }

    public void Pause()
    {
        PleasePause();
    }

    public void Resume()
    {
        PleaseResume();
    }

    public void AtHome()
    {
        isAtHome = true;
    }

    public void NotAtHome()
    {
        isAtHome = false;
    }
}

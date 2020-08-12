using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;

public class GameStopWatch : MonoBehaviour
{
    private static Stopwatch gameStopWatch;
    bool isStopwatchPaused;

    public static int TimeElapsedInSeconds
    {
        get
        {
            return (int) gameStopWatch.ElapsedMilliseconds / 1000;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        gameStopWatch = new Stopwatch();
        gameStopWatch.Reset();
        gameStopWatch.Restart();
    }

    // Update is called once per frame
    void Update()
    {
        if (PauseGame.isGamePaused)
        {
            gameStopWatch.Stop();
            isStopwatchPaused = true;
            return;
        }

        if (!PauseGame.isGamePaused && isStopwatchPaused)
        {
            isStopwatchPaused = false;
            gameStopWatch.Start();
        }
    }

    public void Restart()
    {
        gameStopWatch.Restart();
    }

    public void Stop()
    {
        gameStopWatch.Stop();
    }
}

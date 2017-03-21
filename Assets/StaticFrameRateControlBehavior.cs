using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class StaticFrameRateControlBehavior : MonoBehaviour {

	// Use this for initialization
	void Start () {
        // WARN: if you touch quality setting in the code,
        // it will fail. occurs access violation.

        // WARN: In hololens, setting targetFrameRate doesn't work.
        // Application.targetFrameRate = 10;

        lastTimeInSec = Time.time;
        globalTimer.Start();
        fakeSleepStopwatch.Start();
    }

    private double lastTimeInSec;
    private double targetFrameRate = 30;
    private Stopwatch globalTimer = new Stopwatch();
	
	// Update is called once per frame
	void Update ()
    {
        double currentTime = globalTimer.Elapsed.TotalSeconds;

        double realDeltaTime = currentTime - lastTimeInSec;
        double desiredDeltaTime = 1.0f / targetFrameRate;
        double remainderDeltaTime = desiredDeltaTime - realDeltaTime;

        if (remainderDeltaTime > 0)
        {
            fakeSleep(remainderDeltaTime);
        }

        lastTimeInSec = globalTimer.Elapsed.TotalSeconds;
    }

    volatile private bool sleepLoopingCondition = false;

    Stopwatch fakeSleepStopwatch = new Stopwatch();

    void fakeSleep(double seconds)
    {
        double startTime = fakeSleepStopwatch.Elapsed.TotalSeconds;

        sleepLoopingCondition = true;

        while (true)
        {
            sleepLoopingCondition = fakeSleepStopwatch.Elapsed.TotalSeconds - startTime < seconds;

            if (!sleepLoopingCondition)
                break;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartRateStats : MonoBehaviour
{
    public GameObject HeartRateClient;
    private HelloClient bpmScript;

    public float currentBPM = 0f;


    public float peakMeasureTime = 15f;
    private float measureTimeCountDown = 0f;
    private float avgBpmInPeriod = 0f;
    private int noOfMeasurements = 0;
    private float previousAvgBpm = 0f;


    public float changeTolerance = 2f; // variance within which the bpm is considered same
    public int changeInBpm = 0; // <0 -> decreased, =0 -> around same, >0 -> increased
    // Start is called before the first frame update
    void Start()
    {
        bpmScript = HeartRateClient.GetComponent<HelloClient>();
        previousAvgBpm = bpmScript.GetCurrentHeartRate();
        measureTimeCountDown = peakMeasureTime;
    }

    // Update is called once per frame
    void Update()
    {
        // get current heart rate, this should be safe to access as many times as needed
        currentBPM = bpmScript.GetCurrentHeartRate();
        
        avgBpmInPeriod += currentBPM;
        ++noOfMeasurements;

        // getting the period's maximum
        measureTimeCountDown -= Time.deltaTime;
        if (measureTimeCountDown <= 0)
        {
            // noOfMeasurements has to be at least one because we call the incrementer just before
            avgBpmInPeriod = avgBpmInPeriod / (float)noOfMeasurements;
            if (avgBpmInPeriod > previousAvgBpm + changeTolerance)
            {
                changeInBpm = 1;
            }
            else if (avgBpmInPeriod < previousAvgBpm - changeTolerance)
            {
                changeInBpm = -1;
            }
            else
            {
                changeInBpm = 0;
            }

            previousAvgBpm = avgBpmInPeriod;
            
            avgBpmInPeriod = 0f;
            noOfMeasurements = 0;
            
            measureTimeCountDown = peakMeasureTime;
        }
    }
}

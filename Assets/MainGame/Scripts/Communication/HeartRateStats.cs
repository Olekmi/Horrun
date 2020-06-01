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
    private float maxBpmInPeriod = 0f;
    private float previousMaxBpm = 0f;


    public float changeTolerance = 2f; // variance within which the bpm is considered same
    public int changeInBpm = 0; // <0 -> decreased, =0 -> around same, >0 -> increased
    // Start is called before the first frame update
    void Start()
    {
        bpmScript = HeartRateClient.GetComponent<HelloClient>();
        previousMaxBpm = bpmScript.GetCurrentHeartRate();
        measureTimeCountDown = peakMeasureTime;
    }

    // Update is called once per frame
    void Update()
    {
        // get current heart rate, this should be safe to access as many times as needed
        currentBPM = bpmScript.GetCurrentHeartRate();
        if (currentBPM > maxBpmInPeriod)
            maxBpmInPeriod = currentBPM;

        // getting the period's maximum
        measureTimeCountDown -= Time.deltaTime;
        if (measureTimeCountDown <= 0)
        {
            if (currentBPM < 50f)
            {
                changeInBpm = 0;
                return;
            }
            if (maxBpmInPeriod > previousMaxBpm + changeTolerance)
            {
                changeInBpm = 1;
            }
            else if (maxBpmInPeriod < previousMaxBpm - changeTolerance)
            {
                changeInBpm = -1;
            }
            else
            {
                changeInBpm = 0;
            }

            previousMaxBpm = maxBpmInPeriod;
            maxBpmInPeriod = 0f;
            measureTimeCountDown = peakMeasureTime;
        }
    }
}

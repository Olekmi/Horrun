using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeartRateDisp : MonoBehaviour
{
    public GameObject heartRateStats;
    private HeartRateStats hrScript;
    private Text bpmDisplay;
    // Start is called before the first frame update
    void Start()
    {
        bpmDisplay = GetComponent<Text>();
        hrScript = heartRateStats.GetComponent<HeartRateStats>();
    }

    // Update is called once per frame
    void Update()
    {
        bpmDisplay.text = hrScript.currentBPM.ToString("00.00") + "BPM " + hrScript.changeInBpm;
    }
}

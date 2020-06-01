using UnityEngine;

public class HelloClient : MonoBehaviour
{
    private HelloRequester _helloRequester;

    private void Start()
    {
        _helloRequester = new HelloRequester();
        _helloRequester.Start();
    }

    private void OnDestroy()
    {
        _helloRequester.Stop();
    }

    public float GetCurrentHeartRate()
    {
        // hackish method to handle race condition
        float temp = _helloRequester.bpm;
        while (_helloRequester.bpm != temp) temp = _helloRequester.bpm;
        return temp;
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayRain : MonoBehaviour 
{

    [SerializeField]
    private AudioSource _audio;
    [SerializeField]
    private float _time;

    private void Awake()
    {
        _audio.volume = 0.0f;
        _audio.Play();
        StartCoroutine(FadeInRain(_time));
    }

    private IEnumerator FadeInRain(float _time)
    {
        float curTime = 0.0f;

        while(curTime < _time)
        {
            float t = curTime / _time;

            curTime += Time.deltaTime;

            _audio.volume = t;

            yield return new WaitForEndOfFrame();
        }

        _audio.volume = 1.0f;
    }
}

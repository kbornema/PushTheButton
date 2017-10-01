using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecayTrigger : Triggerable 
{
    [SerializeField]
    private float _changeTime;

    [Header("Background")]
    [SerializeField]
    private Camera _cam;
    [SerializeField]
    private Color _camBackground;

    [Header("Cloud")]
    [SerializeField]
    private CloudGenerator _cloudGenerator;
    [SerializeField]
    private Color _cloudColor;

    [Header("Surface")]
    [SerializeField]
    private LineSurface _defaultSurface;
    [SerializeField]
    private LineSurface _otherSurface;

    private Color _hideColor = new Color(1.0f, 1.0f, 1.0f, 0.0f);


    private void Start()
    {
        if (_otherSurface.gameObject.activeSelf)
            _otherSurface.gameObject.SetActive(false);

        _otherSurface.SetColor(_hideColor);
    }

    public override void Trigger()
    {   
        if(_camBackground != _cam.backgroundColor)
            StartCoroutine(ColorCam(_changeTime, _camBackground));
            
        if (!_otherSurface.gameObject.activeSelf)
            FadeBetweenSurfaces(_hideColor, Color.white, _changeTime);
  
        _cloudGenerator.ColorClouds(_cloudColor, _changeTime);
    }

    private IEnumerator ColorCam(float time, Color color)
    {
        

        float curTime = 0.0f;
        Color startColor = _cam.backgroundColor;

        while (curTime < time)
        {
            float t = curTime / time;

            curTime += Time.deltaTime;

            _cam.backgroundColor = Color.Lerp(startColor, color, t);

            yield return new WaitForEndOfFrame();
        }

        _cam.backgroundColor = color;
    }

    public void FadeBetweenSurfaces(Color a, Color b, float time)
    {
        _defaultSurface.StartFadeColor(a, time);
        _otherSurface.StartFadeColor(b, time);
    }
}

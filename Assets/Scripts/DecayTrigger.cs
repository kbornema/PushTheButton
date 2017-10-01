using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecayTrigger : Triggerable 
{
    [SerializeField]
    private float _changeTime;
    [SerializeField]
    private float _triggerCooldown = 2.0f;

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
    [SerializeField]
    private bool _hideOtherSurface;

    [Header("Trees")]
    [SerializeField]
    private TreeManager _trees;
    [SerializeField]
    private bool _toDry;

    [Header("WorldChange")]
    [SerializeField]
    private ChangeWorld _firstChange;
    [SerializeField]
    private ChangeWorld _secondChange;

    [Header("Other")]
    [SerializeField]
    private List<Bla> _objectsToActivate;


    private Color _hideColor = new Color(1.0f, 1.0f, 1.0f, 0.0f);

    private int _triggerCount;


    private float _curTriggerCooldown;
    private bool CanTrigger { get { return _curTriggerCooldown <= 0.0f; } }

    private void Start()
    {
        if (_otherSurface.gameObject.activeSelf && _hideOtherSurface)
        {
            _otherSurface.gameObject.SetActive(false);
            _otherSurface.SetColor(_hideColor);
        }

    }

    private void Update()
    {
        if(!CanTrigger)
            _curTriggerCooldown -= Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.L))
            Trigger();
    }

    public override void Trigger()
    {
        if (CanTrigger)
        {
            _curTriggerCooldown = _triggerCooldown;

            if (_triggerCount == 0)
                _trees.ChangeTrees(_changeTime, _toDry);

            else if (_triggerCount == 1)
            {
                _cloudGenerator.ColorClouds(_cloudColor, _changeTime);
                _firstChange.Apply();
            }

            else if (_triggerCount == 2){
                FadeBetweenSurfaces(_hideColor, Color.white, _changeTime);
                
            }

            else if (_triggerCount == 3)
                StartCoroutine(ColorCam(_changeTime, _camBackground));

            else if (_triggerCount == 4)
            {
                //_objectToHide.SetActive(false);
                //_changeWorld.Apply();
            }

            for (int i = 0; i < _objectsToActivate.Count; i++)
            {
                if(_objectsToActivate[i].triggerId == _triggerCount)
                    _objectsToActivate[i].obj.SetActive(_objectsToActivate[i].value);
            }

            _triggerCount++;
        }
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


    [System.Serializable]
    public class Bla
    {
        public GameObject obj;
        public int triggerId;
        public bool value;
    }
}

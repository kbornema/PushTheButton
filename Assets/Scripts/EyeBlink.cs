using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeBlink : MonoBehaviour 
{
    [SerializeField]
    private GameObject[] _objs;

    [SerializeField]
    private AnimationCurve _curve;
    [SerializeField]
    private float _cooldown;
    [SerializeField]
    private float _time;

    private float _curCd;

	// Use this for initialization
	void Start () {
        _curCd = _cooldown;
	}
	
	// Update is called once per frame
	void Update () {
        _curCd -= Time.deltaTime;

        if(_curCd <= 0.0f)
        {
            Blink();
            _curCd = _cooldown;
        }
	}

    private void Blink()
    {
        StartCoroutine(BlinkRoutine(_time));
    }

    private IEnumerator BlinkRoutine(float _time)
    {
        float curTime = 0.0f;

        while(curTime < _time)
        {
            float t = curTime / _time;
            curTime += Time.deltaTime;
            ApplyScale(t);
            yield return new WaitForEndOfFrame();
        }

        ApplyScale(1.0f);
    }

    private void ApplyScale(float p)
    {
        float scaleY = _curve.Evaluate(p);

        for (int i = 0; i < _objs.Length; i++)
        {
            var scale = _objs[i].transform.localScale;
            scale.y = scaleY;
            _objs[i].transform.localScale = scale;
        }
    }
}

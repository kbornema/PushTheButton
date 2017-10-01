using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeBehavior : MonoBehaviour 
{
    [SerializeField]
    private SpriteRenderer _normalTree;
    [SerializeField]
    private SpriteRenderer _dryTree;

    private Color _hideColor = new Color(1.0f, 1.0f, 1.0f, 0.0f);

    private void Start()
    {
        if(_dryTree.gameObject.activeSelf)
        {
            _dryTree.color = _hideColor;
            _dryTree.gameObject.SetActive(false);
        }
    }

    public void Fade(float time, bool toDry)
    {
        _dryTree.gameObject.SetActive(true);
        _normalTree.gameObject.SetActive(true);

        StartCoroutine(FadeRoutine(time, toDry));
    }

    private IEnumerator FadeRoutine(float time, bool toDry)
    {
        float curTime = 0.0f;

        while(curTime < time)
        {
            float t = curTime / time;
            curTime += Time.deltaTime;

            ApplyColors(t, toDry);    

            yield return new WaitForEndOfFrame();
        }

        ApplyColors(1.0f, toDry);

        _dryTree.gameObject.SetActive(!toDry);
        _normalTree.gameObject.SetActive(toDry);
    }

    private void ApplyColors(float t, bool toDry)
    {
        if (!toDry)
            t = 1.0f - t;

        _normalTree.color = new Color(1.0f, 1.0f, 1.0f, t);
        _dryTree.color = new Color(1.0f, 1.0f, 1.0f, 1.0f - t);
    }
}

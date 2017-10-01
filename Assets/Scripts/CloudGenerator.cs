using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudGenerator : Triggerable 
{
    [SerializeField]
    private Sprite[] _cloudSprites;

    [SerializeField]
    private SpriteRenderer _cloudPrefab;

    [SerializeField]
    private float _radiusMin;
    [SerializeField]
    private float _radiusMax;

    [SerializeField]
    private int _numClouds;

    private List<CloudBehavior> _allClouds;
	
    void Start()
    {
        _allClouds = new List<CloudBehavior>();

        for (int i = 0; i < _numClouds; i++)
        {
            var instance = Instantiate(_cloudPrefab);

            instance.sprite = _cloudSprites[Random.Range(0, _cloudSprites.Length)];

            Vector2 dir = Random.insideUnitCircle;
            dir.Normalize();

            dir = dir * Random.Range(_radiusMin, _radiusMax);

            instance.transform.position = new Vector2(transform.position.x, transform.position.y) + dir;

            var cloud = instance.GetComponent<CloudBehavior>();
            _allClouds.Add(cloud);
            cloud.SetCenter(transform);

            instance.transform.SetParent(transform);

            
        }
    }

    public override void Trigger()
    {
        Color color = new Color(0.25f, 0.25f, 0.25f, 0.5f);
        ColorClouds(color, 2.0f);
    }

    public void ColorClouds(Color newColor, float time)
    {
        StartCoroutine(ColorCloudsRoutine(newColor, time));
    }

    private IEnumerator ColorCloudsRoutine(Color newColor, float time)
    {
        float curTime = 0.0f;

        Color startColor = _allClouds[0].TheSpriteRenderer.color;

        while(curTime < time)
        {
            float t = curTime / time;

            Color curColor = Color.Lerp(startColor, newColor, t);

            ApplyColorToAllClouds(curColor);

            curTime += Time.deltaTime;

            yield return new WaitForEndOfFrame();
        }

        ApplyColorToAllClouds(newColor);
    }

    private void ApplyColorToAllClouds(Color curColor)
    {
        for (int i = 0; i < _allClouds.Count; i++)
            _allClouds[i].TheSpriteRenderer.color = curColor;
    }
}

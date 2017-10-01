using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudGenerator : MonoBehaviour 
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
	
    void Start()
    {
        for (int i = 0; i < _numClouds; i++)
        {
            float radius = Random.Range(_radiusMin, _radiusMax);

            var instance = Instantiate(_cloudPrefab);

            instance.sprite = _cloudSprites[Random.Range(0, _cloudSprites.Length)];

            Vector2 dir = Random.insideUnitCircle;
            dir.Normalize();

            dir = dir * Random.Range(_radiusMin, _radiusMax);

            instance.transform.position = dir;

            instance.GetComponent<CloudBehavior>().SetCenter(transform);

            instance.transform.SetParent(transform);
        }
    }
}

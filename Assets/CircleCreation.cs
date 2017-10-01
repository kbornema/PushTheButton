using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleCreation : MonoBehaviour {

    [SerializeField]
    private Transform _pointRoot;

    [SerializeField]
    private float _radius = 5.0f;

    [SerializeField]
    private int _segments = 32;

    [ContextMenu("Generate")]
    private void Generate()
    {
        while(_pointRoot.transform.childCount > 0)
            DestroyImmediate(_pointRoot.transform.GetChild(0).gameObject);

        float delta = (Mathf.PI * 2.0f) / _segments;

        for (int i = 0; i < _segments; i++)
        {
            float cur = delta * i;

            float x = Mathf.Sin(cur) * _radius;
            float y = Mathf.Cos(cur) * _radius;

            Vector2 pos = new Vector2(x, y);

            GameObject obj = new GameObject(i.ToString());
            obj.transform.SetParent(_pointRoot);

            obj.transform.localPosition = pos;

        }
    }
}

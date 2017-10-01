using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blink : MonoBehaviour 
{
    [SerializeField]
    private SpriteRenderer _spriteRenderer;
    [SerializeField]
    private Color color;

    [SerializeField]
    private float _speed;

    private float _time;
	
	// Update is called once per frame
	void Update () 
    {
        _time += Time.deltaTime;
        float t = Mathf.Abs(Mathf.Sin(_time));
        _spriteRenderer.color = new Color(color.r, color.g, color.b, t);
	}
}

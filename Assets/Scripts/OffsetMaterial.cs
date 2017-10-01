using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OffsetMaterial : MonoBehaviour {

    [SerializeField]
    private Renderer _myRenderer;
    [SerializeField]
    private float _speed = 2.0f;
    [SerializeField]
    private float _amount = 1.0f;

    private Material _mat;
    private float _time;
	
    private void Start()
    {
        _mat = _myRenderer.material;
    }

	// Update is called once per frame
	void Update () 
    {
        _time += Time.deltaTime * _speed;

        float value = Mathf.Sin(_time);

        _mat.mainTextureOffset = new Vector2(value * _amount, 0.0f);
	}
}

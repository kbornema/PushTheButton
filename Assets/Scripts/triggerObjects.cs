using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggerObjects : MonoBehaviour {

    public Triggerable[] objects;

	// Use this for initialization
	void Start () {
        foreach (Triggerable element in objects){
            element.Trigger();
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

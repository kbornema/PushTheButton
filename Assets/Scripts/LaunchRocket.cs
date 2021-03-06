using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchRocket : MonoBehaviour {

    private bool triggered = false;
    public Vector3 offset;
    public float rotation;
    float startRotation, endRotation;
    Vector3 startPosition, endPosition;
    public float animLength = 5;
    public float fadeSpeed = 0.8f;
    Vector3 originalPosition;
    float fullAnimLength;
    public AnimationCurve animCurve;
    private bool fade = false;

     public Texture2D fadeOutTexture; // the texture that will overlay the screen. This can be a black image or a loading graphic

 private int drawDepth = -1000;  // the texture's order in the draw hierarchy: a low number means it renders on top
 private float alpha = 1.0f;   // the texture's alpha value between 0 and 1
 private int fadeDir = -1;   // the direction to fade: in = -1 or out = 1

    void Start()
    {
        originalPosition = transform.position;
        fullAnimLength = animLength;
        startPosition = transform.position;
        endPosition = startPosition + offset;
        startRotation = transform.rotation.eulerAngles.z;
        endRotation = rotation + transform.rotation.eulerAngles.z;
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Player" && fade == false)
        {
            triggered = true;
        }
    }

    void FixedUpdate()
    {
        if (triggered)
        {
            triggered = false;
            BeginFade(1);
            fade = true;
        }
    }


    void Update()
    {
        if(Input.GetKey(KeyCode.F1))
        {
            Application.LoadLevel("default Kai");
        }
    }


 void OnGUI()
 {
     if(fade)
     {
         // fade out/in the alpha value using a direction, a speed and Time.deltaTime to convert the operation to seconds
         alpha += 1 * fadeSpeed * Time.deltaTime;
         // force (clamp) the number to be between 0 and 1 because GUI.color uses Alpha values between 0 and 1
         alpha = Mathf.Clamp01(alpha);

         // set color of our GUI (in this case our texture). All color values remain the same & the Alpha is set to the alpha variable
         GUI.color = new Color(GUI.color.r, GUI.color.g, GUI.color.b, alpha);
         GUI.depth = drawDepth;                // make the black texture render on top (drawn last)
         GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), fadeOutTexture);  // draw the texture to fit the entire screen area
     }
     if (alpha == 1 && fade == true)
         Application.LoadLevel("default Kai");

 }

 // sets fadeDir to the direction parameter making the scene fade in if -1 and out if 1
 public float BeginFade (int direction)
 {
     alpha = 0;
  fadeDir = direction;
  return (fadeSpeed);
 }

}﻿


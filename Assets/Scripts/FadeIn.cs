using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeIn : MonoBehaviour {

    private bool fade = false;
    private float alpha = 1;
    public float fadeSpeed = 0.3f;
    private int drawDepth = -1000;
    public Texture2D fadeOutTexture;

	// Use this for initialization
	void Start () {
        fade = true;
	}

    void OnGUI()
    {
        if (fade)
        {
            // fade out/in the alpha value using a direction, a speed and Time.deltaTime to convert the operation to seconds
            alpha += -1 * fadeSpeed * Time.deltaTime;
            // force (clamp) the number to be between 0 and 1 because GUI.color uses Alpha values between 0 and 1
            alpha = Mathf.Clamp01(alpha);

            // set color of our GUI (in this case our texture). All color values remain the same & the Alpha is set to the alpha variable
            GUI.color = new Color(GUI.color.r, GUI.color.g, GUI.color.b, alpha);
            GUI.depth = drawDepth;                // make the black texture render on top (drawn last)
            GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), fadeOutTexture);  // draw the texture to fit the entire screen area
        }
        if (fade == true && alpha == 1 )
            fade = false;

    }

	// Update is called once per frame
	void Update () {
		
	}
}

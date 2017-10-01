using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GraveyardTrigger : MonoBehaviour 
{
    [SerializeField]
    private float _delay;
    [SerializeField]
    private Texture2D _fadeTexture;
    [SerializeField]
    private int _drawDepth = 0;
    [SerializeField]
    private float _fadeDur = 15.0f;

    private bool _fade;
    private float _time;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.GetComponent<Movement>())
        {
            StartCoroutine(EndRoutine(_delay));
        }
    }

    private IEnumerator EndRoutine(float _delay)
    {
        yield return new WaitForSeconds(_delay);

        _fade = true;
        //TODO: fade out and end:
    }

    private void OnGUI()
    {
        if (_fade)
        {
            // fade out/in the alpha value using a direction, a speed and Time.deltaTime to convert the operation to seconds
            float alpha = Mathf.Clamp01(_time / _fadeDur);
            _time += Time.deltaTime;

            // set color of our GUI (in this case our texture). All color values remain the same & the Alpha is set to the alpha variable
            GUI.color = new Color(GUI.color.r, GUI.color.g, GUI.color.b, alpha);
            GUI.depth = _drawDepth;                // make the black texture render on top (drawn last)
            GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), _fadeTexture);  // draw the texture to fit the entire screen area

            if(alpha >= 1.0f)
            {   
                SceneManager.LoadScene("startScene");
            }
        }
    }
}

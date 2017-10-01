using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressedButton : MonoBehaviour {

    public Triggerable[] objects;

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            foreach (Triggerable element in objects)
            {
                element.Trigger();
            }
        }
    }
}

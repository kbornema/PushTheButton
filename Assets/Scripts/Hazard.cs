using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Hazard : MonoBehaviour 
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        var player = other.GetComponent<Movement>();

        if(player)
        {
            player.Respawn();
        }
    }
}

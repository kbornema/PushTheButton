using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour 
{

    private void Start()
    {
        CheckpointManager.instance.RegisterCheckpoint(this);
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.tag == "Player")
        {
            var movement = coll.gameObject.GetComponent<Movement>();
            movement.lastCheckpoint = transform;
        }
    }
}

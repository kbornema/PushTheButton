using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour 
{   
  
    private void Start()
    {
        CheckpointManager.instance.RegisterCheckpoint(this);
    }


}

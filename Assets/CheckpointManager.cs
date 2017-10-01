using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointManager : MonoBehaviour {

    public static CheckpointManager instance;

    private List<Checkpoint> _checkpoints;


	// Use this for initialization
	void Awake () 
    {
        _checkpoints = new List<Checkpoint>();
        instance = this;
	}

    public void RegisterCheckpoint(Checkpoint p)
    {
        _checkpoints.Add(p);
    }
	
	public Vector3 GetRespawnPos(Vector3 playerPos)
    {
        float minDist = float.PositiveInfinity;
        int id = -1;

        for (int i = 0; i < _checkpoints.Count; i++)
        {
            float curDist = (_checkpoints[i].transform.position - playerPos).sqrMagnitude;

            if(curDist < minDist)
            {
                minDist = curDist;
                id = i;
            }
        }


        return _checkpoints[id].transform.position;
    }
}

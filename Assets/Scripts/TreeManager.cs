using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeManager : MonoBehaviour 
{
    private List<TreeBehavior> _trees;

	// Use this for initialization
	void Start () 
    {
        _trees = new List<TreeBehavior>();
        for (int i = 0; i < transform.childCount; i++)
        {
            var tree = transform.GetChild(i).GetComponent<TreeBehavior>();
            
            if(tree)
                _trees.Add(tree);
        }
	}
	
    public void ChangeTrees(float time, bool toDry)
    {
        for (int i = 0; i < _trees.Count; i++)
            _trees[i].Fade(time, toDry);
    }
	
}

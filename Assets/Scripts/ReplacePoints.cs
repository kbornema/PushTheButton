using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReplacePoints : MonoBehaviour {

    [SerializeField]
    private List<Replacer> _points;
    [SerializeField]
    private Transform _oldPointRoot;

    private Dictionary<Transform, Transform> _dict;

    [SerializeField]
    private Transform _newPointRoot;
    public Transform NewPointRoot { get { return _newPointRoot; } }

    private void Awake()
    {
        _dict = new Dictionary<Transform, Transform>();

        for (int i = 0; i < _points.Count; i++)
            _dict.Add(_points[i]._old, _points[i]._new);

        CreatePoints();
    }

    public void CreatePoints()
    {
        
        for (int i = 0; i < _oldPointRoot.childCount; i++)
        {
            Transform cur = _oldPointRoot.GetChild(i);

            GameObject newPoint = new GameObject();
            newPoint.transform.SetParent(_newPointRoot);

            if(_dict.ContainsKey(cur))
            {  
                newPoint.transform.localPosition = _dict[cur].localPosition;
            }
               

            else
            {
                newPoint.transform.localPosition = cur.localPosition;
            }
               
        }
    }
    

    [System.Serializable]
    public class Replacer
    {
        public Transform _old;
        public Transform _new;
    }
}

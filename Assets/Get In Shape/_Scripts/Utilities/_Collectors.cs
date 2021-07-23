using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _Collectors : MonoBehaviour
{
    public List<Transform> colPosition = new List<Transform>(); //collectors postion for diamond spwan

    private GameObject diamond;
    void Start()
    {     
        //diamond = _LevelManager.levelManager.diamond;
        foreach(Transform t in transform)
        {
            colPosition.Add(t.transform);
        }
        for(int i = 0; i <= colPosition.Count - 1; i++)
        {
            Instantiate(_LevelManager.levelManager.diamond, colPosition[i].position, Quaternion.identity).transform.parent = transform;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

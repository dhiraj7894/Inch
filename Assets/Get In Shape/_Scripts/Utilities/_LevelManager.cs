using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _LevelManager : MonoBehaviour
{
    public static _LevelManager levelManager;

    [Header("Level Objects")]
    public GameObject diamond;

    [Header("Level")]
    public GameObject Level;

    void Start()
    {
        levelManager = this;
        Instantiate(Level, transform.position, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{

    public bool isCollided=false;
    public bool playerPassed = false;

    public float RSSpeed = 10;
    private void Start()
    {
        transform.GetComponent<MeshRenderer>().material.color = Color.red;
    }
    private void Update()
    {
        if (playerPassed)
        {
            transform.GetComponent<MeshRenderer>().material.color = Color.green;
            transform.localScale -= new Vector3(RSSpeed, RSSpeed, RSSpeed) * Time.deltaTime;

        }
        else if (isCollided)
        {
            FindObjectOfType<_playerM>().movementSpeed = 0;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isCollided = true;
        }
    }
}

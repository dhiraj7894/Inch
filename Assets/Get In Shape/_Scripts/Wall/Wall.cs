using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{

    public bool isCollided=false;
    public bool playerPassed = false;

    private bool countAdded = false;

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
            if(transform.localScale.x >= 0)
            {
                transform.localScale -= new Vector3(RSSpeed, RSSpeed, RSSpeed) * Time.deltaTime;
            }
            if (!countAdded)
            {
                GameManager.gameManager.CountOfWallPassed++;
                countAdded = true;
            }
        }
        else if (isCollided)
        {
            GameManager.gameManager.playerMS = 0;
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _playerM : MonoBehaviour
{
    public Transform WallRays;
    public GameObject TargetedWall;

    public float movementSpeed = 2;
    public float wDDistance; //wall ditaction distance
    public float dFTWall; //Distance From Target Wall


    public LayerMask wall;

    void Update()
    {
        move();
        WallChecker();
        distanceCalculator();
    }

    void move()
    {
        transform.Translate(transform.forward * movementSpeed * Time.deltaTime);
    }

    void WallChecker()
    {
        RaycastHit hit;
        if (Physics.Raycast(WallRays.position, WallRays.forward,out hit, wDDistance, wall))
        {
            TargetedWall = hit.transform.gameObject;
        }
    }

    void distanceCalculator()
    {
        if (TargetedWall == null)
            return;
        dFTWall = TargetedWall.transform.position.z - transform.position.z;

        if (dFTWall <= -2)
        {
            TargetedWall.GetComponent<Wall>().playerPassed = true;
        }
    }


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.black;
        Gizmos.DrawLine(WallRays.position, WallRays.forward * 10);
    }
}

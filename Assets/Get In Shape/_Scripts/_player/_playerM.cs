using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;

public class _playerM : MonoBehaviour
{
    public Transform WallRays;
    public GameObject TargetedWall;

    private Animator animation;
    private float movementSpeed;
    
    public float wDDistance; //wall ditaction distance
    public float dFTWall; //Distance From Target Wall


    public LayerMask wall;


    private void Start()
    {
        animation = transform.GetChild(0).GetComponent<Animator>();
    }
    void Update()
    {
        movementSpeed = GameManager.gameManager.playerMS;
        move();
        WallChecker();
        distanceCalculator();
        GameOverFun();
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

    void GameOverFun()
    {
        if (GameManager.gameManager.GameOver)
        {
            transform.GetChild(0).GetComponent<RigBuilder>().enabled = false;
            animation.SetTrigger("dance");
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.black;
        Gizmos.DrawLine(WallRays.position, WallRays.forward * 10);
    }
}

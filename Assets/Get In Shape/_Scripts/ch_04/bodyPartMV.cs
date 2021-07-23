using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bodyPartMV : MonoBehaviour
{
    private SpriteRenderer sIndicator;
    private Vector3 mOffset;
    private float mZCoord;

    public bool isMoving = false;
    private void Start()
    {
        sIndicator = transform.GetChild(0).GetComponent<SpriteRenderer>();
        sIndicator.color = new Color (1,0,0,0.6f);
    }
    private void Update()
    {
        GameOverFun();
        if (isMoving)
        {
            transform.position = GetMouseAsWorldPoint() + mOffset;
        }
    }
    void OnMouseDown()
    {
        isMoving = true;
        mZCoord = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
        // Store offset = gameobject world pos - mouse world pos
        mOffset = gameObject.transform.position - GetMouseAsWorldPoint();
        sIndicator.color = new Color(0, 1, 0, 0.6f);
    }
    private void OnMouseUp()
    {
        isMoving = false;
        sIndicator.color = new Color(1,0,0,0.6f);
    }
    private Vector3 GetMouseAsWorldPoint()
    {
        // Pixel coordinates of mouse (x,y)

        Vector3 mousePoint = Input.mousePosition;

        // z coordinate of game object on screen

        mousePoint.z = mZCoord;
        // Convert it to world points

        return Camera.main.ScreenToWorldPoint(mousePoint);
    }

    void GameOverFun()
    {
        if (GameManager.gameManager.GameOver)
        {
            sIndicator.enabled = false;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager gameManager;

    public Animator CinemachineCam;
    public GameObject Confetti;
    public float playerMS;
    public int CountOfWallToBePass;
    public int CountOfWallPassed;

    public bool GameOver = false;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = this;
        Confetti.SetActive(false);
        playerMS = 0;
        StartCoroutine(startGame(0.5f));
    }

    // Update is called once per frame
    void Update()
    {
        playerMMange();
        GameOverFunc();
    }

    void playerMMange()
    {
        if (CountOfWallPassed == CountOfWallToBePass && !GameOver)
        {
            playerMS = 6;
        }
    }
    void GameOverFunc()
    {
        if (GameOver)
        {
            StartCoroutine(confettieEffect(1f));
            CinemachineCam.Play("cam2");
        }
    }

    IEnumerator confettieEffect(float t)
    {
        yield return new WaitForSeconds(t);
        Confetti.SetActive(true);
    }

    IEnumerator startGame(float t)
    {
        yield return new WaitForSeconds(t);
        playerMS = 3;
    }
}

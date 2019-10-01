using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public Text scoreText;
    private int score;
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
    }

    public void AddScore(int scoreValue)
    {
        score += scoreValue;
        scoreText.text = "Score:" + score;
    }
}

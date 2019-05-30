using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;  // 忘れずに！
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    private int score = 0;
    private Text scoreLabel;

    void Start()
    {

        scoreLabel = GameObject.Find("ScoreLabel").GetComponent<Text>();
        scoreLabel.text = "SCORE：" + score;
    }
    
    // スコアを増加させるメソッド
    // 外部からアクセスするためpublicで定義する
    public void AddScore(int amount)
    {
        score += amount;
        scoreLabel.text = "SCORE：" + score;

        if(score >= 100)
        {
            SceneManager.LoadScene("Clear");
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement; // この１行を忘れないこと。

public class GameStart : MonoBehaviour
{
    // メソッドに「public」が付いていることを確認する（ポイント）
    public void OnStartButtonClicked()
    {
        SceneManager.LoadScene("Main");
    }
}

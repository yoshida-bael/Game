using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TankHealth : MonoBehaviour
{
    public int tankHP;
    public Text HPLabel;

    private void Start()
    {
        HPLabel.text = "HP:"+tankHP;
    }

    void OnTriggerEnter(Collider other)
    {

        // もしもぶつかってきた相手のTagが”EnemyShell”であったならば（条件）
        if (other.gameObject.tag == "EnemyShell")
        {
            // HPを１ずつ減少させる。
            tankHP -= 1;
            HPLabel.text = "HP:" + tankHP;

            // ぶつかってきた相手方（敵の砲弾）を破壊する。
            Destroy(other.gameObject);

            if (tankHP <= 0)
            {
                // プレーヤーを破壊する。
                //Destroy(gameObject);

                // プレーヤーを破壊せずに画面から見えなくする（ポイント・テクニック）
                // プレーヤーを破壊すると、その時点でメモリー上から消えるので、以降のコードが実行されなくなる。
                this.gameObject.SetActive(false);

                // ★追加
                // 1.5秒後に「GoToGameOver()」メソッドを実行する。
                Invoke("GoToGameOver", 1.5f);
            }
        }
    }

    public void AddHP(int amount)
    {

        // shotCountをamount分だけ回復させる
        tankHP += amount;

        // ただし、残弾数が最大値を超えないようする。(最大値は自由に設定)
        if (tankHP > 20)
        {
            tankHP = 20;
        }

        // 回復をUIに反映させる。
        HPLabel.text = "HP：" + tankHP;
    }

    void GoToGameOver()
    {
        SceneManager.LoadScene("GameOver");
    }
}

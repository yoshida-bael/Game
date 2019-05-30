using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShotShell : MonoBehaviour
{
    public GameObject enemyShellPrefab;
    public float shotSpeed;
    private float shotIntarval;

    public float stopTimer = 5.0f;

    void Update()
    {

        shotIntarval += 1;

        stopTimer -= Time.deltaTime;
        // タイマーが0未満になったら、0で止める。
        if (stopTimer < 0)
        {
            stopTimer = 0;
        }
        print("攻撃開始まであと" + stopTimer + "秒");

        if (shotIntarval % 60 == 0 && stopTimer <= 0)
        {
            GameObject enemyShell = (GameObject)Instantiate(enemyShellPrefab, transform.position, Quaternion.identity);

            Rigidbody enemyShellRb = enemyShell.GetComponent<Rigidbody>();

            // forwardはZ軸方向（青軸方向）、この方向に力を加える。
            enemyShellRb.AddForce(transform.forward * shotSpeed);

            Destroy(enemyShell, 3.0f);
        }
    }
    // 敵の攻撃をストップさせるメソッド（Timerの時間を増加させることで攻撃の停止時間を伸ばす）
    // （考え方）HPを増加させるアイテム等と同じ
    // このアイテムを複数取得すると、それだけ攻撃停止時間も「加算」される。
    public void AddStopTimer(float amount)
    {
        stopTimer += amount;
    }

}

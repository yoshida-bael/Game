using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopItem : MonoBehaviour
{
    private GameObject[] targets;

    void Update()
    {
        // 「EnemyShotShell」オブジェクトに「EnemyShotShell」タグを設定してください（ポイント）
        targets = GameObject.FindGameObjectsWithTag("EnemyShotShell");
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            for (int i = 0; i < targets.Length; i++)
            {
                // 攻撃停止時間を３秒加算する。
                targets[i].GetComponent<EnemyShotShell>().AddStopTimer(3.0f);
            }
            Destroy(gameObject);
        }
    }
}

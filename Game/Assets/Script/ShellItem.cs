using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShellItem : MonoBehaviour
{
    private ShotShell ss;
    private int reward = 5; // 弾数をいくつ回復させるかを決める。

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            // Find()メソッドは、「名前」でオブジェクトを探し特定します。
            // 「ShotShell」オブジェクトを探し出して、それに付いている「ShotShell」スクリプト（component）のデータを取得。
            //今回はtankに付いているShotShellスクリプトのデータを取得
            // 取得したデータを「ss」の箱の中に入れる。
            ss = GameObject.Find("ShotShell").GetComponent<ShotShell>();

            //  ShotShellスクリプトの中に記載されている「AddShellメソッド」を呼び出す。
            // rewardで設定した数値分だけ弾数が回復する。
            ss.AddShell(reward);

            // アイテムを画面から削除する。
            Destroy(gameObject);
        }
    }
}

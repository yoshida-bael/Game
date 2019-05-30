using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class ShotShell : MonoBehaviour
{
    public GameObject shellPrefab;
    public float shotSpeed;
    public AudioClip shotSound;

    private float timeBetweenShot = 0.35f;
    private float timer;
    public int shotCount;

    public Text shellLabel;

    // Startの「S」は大文字なので注意！
    void Start()
    {
        shellLabel.text = "砲弾：" + shotCount;
    }

    void Update()
    {
        timer += Time.deltaTime;

        // もしもSpaceキーを押したならば（条件）
        // 「Space」の部分を変更することで他のキーにすることができる（ポイント）
        if (Input.GetKeyDown(KeyCode.Space) && timer>timeBetweenShot)
        {

            if (shotCount < 1)
            {
                return;
            }

            // ★追加
            shotCount -= 1;
            shellLabel.text = "砲弾：" + shotCount;


            // タイマーの時間を０に戻す。
            timer = 0.0f;

            // 砲弾のプレハブを実体化（インスタンス化）する。
            GameObject shell = Instantiate(shellPrefab, transform.position, Quaternion.identity) as GameObject;

            // 砲弾に付いているRigidbodyコンポーネントにアクセスする。
            Rigidbody shellRb = shell.GetComponent<Rigidbody>();

            // forward（青軸＝Z軸）の方向に力を加える。
            shellRb.AddForce(transform.forward * shotSpeed);

            // 発射した砲弾を３秒後に破壊する。
            // （重要な考え方）不要になった砲弾はメモリー上から削除すること。
            Destroy(shell, 3.0f);

            // 砲弾の発射音を出す。
            //AudioSource.PlayClipAtPoint(shotSound, transform.position);
        }
    }

    // 残弾数を増加させるメソッド（関数・命令ブロック）
    // 外部からこのメソッドを呼び出せるように「public」をつける（重要ポイント）
    // この「AddShellメソッド」を「ShellItem」スクリプトから呼び出す。
    public void AddShell(int amount)
    {

        // shotCountをamount分だけ回復させる
        shotCount += amount;

        // ただし、残弾数が最大値を超えないようする。(最大値は自由に設定)
        if (shotCount > 30)
        {
            shotCount = 30;
        }

        // 回復をUIに反映させる。
        shellLabel.text = "砲弾：" + shotCount;
    }
}

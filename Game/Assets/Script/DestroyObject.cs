using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObject : MonoBehaviour
{

    public int objectHP;
    //public GameObject itemPrefab;
    // 配列の定義・・・＞複数のデータを入れることのできる箱の作成
    public GameObject[] itemPrefabs;

    public int scoreValue;  // これが敵を倒すと得られる点数になる
    private ScoreManager sm;

    void Start()
    {
        // 「ScoreManagerオブジェクト」に付いている「ScoreManagerスクリプト」の情報を取得して「sm」の箱に入れる。
        sm = GameObject.Find("ScoreManager").GetComponent<ScoreManager>();
    }

    // このメソッドはぶつかった瞬間に呼び出される
    void OnTriggerEnter(Collider other)
    {
        // オブジェクトのHPを１ずつ減少させる。
        objectHP -= 1;

        // もしもぶつかった相手のTagにShellという名前が書いてあったならば（条件）
        if (other.CompareTag("Shell"))
        {
            // ぶつかってきたオブジェクトを破壊する
            Destroy(other.gameObject);
            if (objectHP < 0)
            {
                // このスクリプトがついているオブジェクトを破壊する（thisは省略が可能）
                Destroy(this.gameObject);

                // 「Length」というプロパティを使うと、配列の要素数（「幾つの」データが入っているか）を測ることができます。
                //　配列に入っているitemPrefabsからランダムにdropItemに入れる
                GameObject dropItem = itemPrefabs[Random.Range(0, itemPrefabs.Length)];

                //アイテムの生成
                Vector3 pos = transform.position;

                // dropItemを生成する
                Instantiate(dropItem, new Vector3(pos.x, pos.y + 0.5f, pos.z), Quaternion.identity);

                sm.AddScore(scoreValue);
            }
        }
    }
}

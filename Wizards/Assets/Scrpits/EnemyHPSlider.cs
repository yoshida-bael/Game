using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHPSlider : MonoBehaviour
{
    private Slider slider;
    private int eHP;
    private GameObject enemyCanvas;
    void Start()
    {
        // （ポイント）
        // transform.root.gameObject・・・＞Findを使わずに、一番上の階層にある親の情報を取得できる。
        eHP = transform.root.gameObject.GetComponent<Destroy>().EnemyHP;

        slider = GetComponent<Slider>();
        slider.value = eHP;
        slider.maxValue = eHP;
        enemyCanvas = transform.parent.gameObject;
    }

    void Update()
    {
        eHP = transform.root.gameObject.GetComponent<Destroy>().EnemyHP;
        slider.value = eHP;
        enemyCanvas.transform.LookAt(GameObject.Find("FPS Camera").transform);
    }
}

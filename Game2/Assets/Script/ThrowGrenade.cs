using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowGrenade : MonoBehaviour
{
    public GameObject grenadePrefab;
    public AudioClip throwSound;
    public float throwSpeed;
    public int grenadeCount;
    private float timeBetweenShot = 0.35f;
    private float timer;

    void Update()
    {
        timer += Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Mouse0) && grenadeCount > 0 && timer > timeBetweenShot)
        {
            grenadeCount -= 1;
            // タイマーの時間を０に戻す。
            timer = 0.0f;

            GameObject grenade = (GameObject)Instantiate(grenadePrefab, transform.position, Quaternion.identity);
            Rigidbody grenadeRb = grenade.GetComponent<Rigidbody>();
            grenadeRb.AddForce(transform.forward * throwSpeed);
            AudioSource.PlayClipAtPoint(throwSound, Camera.main.transform.position);
        }
    }
}

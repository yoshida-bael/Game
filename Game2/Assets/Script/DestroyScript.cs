﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyScript : MonoBehaviour
{
    public GameObject effectPrefab;
    public AudioClip effectSound;

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Ground")
        {
            Invoke("DestroyG", 3.0f);
        }
    }

    void DestroyG()
    {
        Destroy(gameObject);
        GameObject effect = (GameObject)Instantiate(effectPrefab, transform.position, Quaternion.identity);
        Destroy(effect, 1.0f);
        AudioSource.PlayClipAtPoint(effectSound, Camera.main.transform.position);
    }
}

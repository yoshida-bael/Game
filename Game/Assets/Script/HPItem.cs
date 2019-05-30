using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPItem : MonoBehaviour
{
    private TankHealth th;
    private int reward = 3;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            th = GameObject.Find("Tank").GetComponent<TankHealth>();
            th.AddHP(reward);

            Destroy(gameObject);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicEmit : MonoBehaviour
{
    public GameObject MagicPrefab;
	public float shotSpeed;

	void Update () {
		if (Input.GetKey (KeyCode.Mouse0)) {
			GameObject Magic = (GameObject)Instantiate (MagicPrefab, transform.position, Quaternion.Euler (transform.parent.eulerAngles.x, transform.parent.eulerAngles.y, 0));
			Rigidbody MagicRb = Magic.GetComponent<Rigidbody> ();
			MagicRb.AddForce (transform.forward * shotSpeed);
        }
	}
}

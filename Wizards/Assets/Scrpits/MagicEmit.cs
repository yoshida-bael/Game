using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicEmit : MonoBehaviour
{
	public GameObject MagicPrefab;
	public float shotSpeed;
	private Animator animator;
	private CharacterController characterController;
	private GameObject child;

	void Start (){
		characterController = GetComponent<CharacterController>();
		animator = GetComponent<Animator>();
		child = this.transform.Find("MagicEmittion").gameObject;
	}

	void Update () {
		if (Input.GetKey (KeyCode.Mouse0)) {
			animator.SetBool("Magic1",true);
			GameObject Magic = (GameObject)Instantiate (MagicPrefab, child.transform.position, Quaternion.Euler (child.transform.eulerAngles.x, child.transform.eulerAngles.y, 0));
        }
	}
}

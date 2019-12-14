using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicEmit : MonoBehaviour
{

	public GameObject[] MagicPrefabs;
	public float shotSpeed;
	public int currentNum = 0;
	private Animator animator;
	private CharacterController characterController;
	private GameObject child;

	void Start (){
		characterController = GetComponent<CharacterController>();
		animator = GetComponent<Animator>();
		child = this.transform.Find("MagicEmittion").gameObject;

		for(int i=0;i<MagicPrefabs.Length;i++){
            if(i == currentNum){
                //SetActiveでtrueになっているのが実際に使えるやつ
                MagicPrefabs[i].SetActive(true);
            }else{
                MagicPrefabs[i].SetActive(false);
            }
        }
	}

	void Update () {
		if (Input.GetKey(KeyCode.Mouse0)) {
			animator.SetBool("Magic1",true);
        }else{
			animator.SetBool("Magic1",false);
		}
	}

	void MagicAttack(){
		if(Input.GetKeyDown(KeyCode.p)){
            currentNum=(currentNum+1)%MagicPrefabs.Length;

            for(int i=0;i<magics.Length;i++){
                if(i == currentNum){
                    MagicPrefabs[i].SetActive(true);
                }else{
                    MagicPrefabs[i].SetActive(false);
                }
            }
        }
		GameObject Magic = (GameObject)Instantiate (MagicPrefabs[i], child.transform.position, Quaternion.Euler (child.transform.eulerAngles.x, child.transform.eulerAngles.y, 0));
	}
}

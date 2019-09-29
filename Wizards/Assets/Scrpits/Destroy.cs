using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    public int EnemyHP;
    private Animator animator;

    private void OnParticleCollision(GameObject other)
    {
        if (other.CompareTag("Magic"))
        {
            EnemyHP -= 3;

            // ★★追加
            // もしもHPが0よりも大きい場合には（条件）
            if (EnemyHP < 0)
            {
                animator = GetComponent<Animator>();
                animator.SetBool("Delete",true);
                Destroy(this.gameObject,4.0f);
            }
            else
            { 
            }
        }
    }
}

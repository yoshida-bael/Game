using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicDamage : MonoBehaviour
{
    private Animator animator;

     void OnParticleCollision(GameObject other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            Destroy(other.gameObject,3.0f);
        }
    }
}

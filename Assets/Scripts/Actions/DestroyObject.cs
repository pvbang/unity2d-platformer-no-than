using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObject : MonoBehaviour
{
    public float time;
    public bool setTime = false;
    private Animator animator;

    void Start()
    {
        animator = GetComponentInChildren<Animator>();

        if (setTime)
        {
            Destroy(this.gameObject, time);
        } else
        {
            time = animator.GetCurrentAnimatorStateInfo(0).length;
            Destroy(this.gameObject, time);
        }
    }
}

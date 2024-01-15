using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public PlayerHealth playerHealth;
    public Transform skillPos;

    // skill 1
    public GameObject skill1;
    public float timeBetweenSkill1 = 2f;
    private float skill1Timer;

    // skill 2
    public GameObject skill2;

    // take damage effect
    public GameObject takeDamageEffect;
    public GameObject takeDamagePos;
    GameObject takeDamageEffectSwam;

    private Animator animator;
    EnemyController enemyController;

    public int minDamage;
    public int maxDamage;

    private void Awake()
    {
        playerHealth = GetComponent<PlayerHealth>();
        animator = GetComponentInChildren<Animator>();
    }

    private void Update()
    {
        skill1Timer -= Time.deltaTime;
    }

    public void TakeDamage(int damage)
    {
        animator.SetTrigger("takeDamage");
        playerHealth.TakeDamage(damage);
        if (takeDamageEffectSwam == null)
        {
            takeDamageEffectSwam = Instantiate(takeDamageEffect, takeDamagePos.transform.position, Quaternion.identity);
        }
    }

    public void Healing(int healing)
    {
        playerHealth.Healing(healing);
    }

    public void HeadlingFullHP()
    {
        playerHealth.Healing(playerHealth.maxHealth);
    }


    public void Skill1()
    {
        animator.SetTrigger("skill1");
        GameObject skill1Swam = Instantiate(skill1, skillPos.position, Quaternion.identity);
    }

    public void Skill2()
    {
        if (skill1Timer > 0)
        {
            return;
        }
        skill1Timer = timeBetweenSkill1;

        animator.SetTrigger("skill2");
        StartCoroutine(ShowSkill2());
    }

    IEnumerator ShowSkill2()
    {
        yield return new WaitForSeconds(0.6f);

        GameObject skill2Swam = Instantiate(skill2, skillPos.position, Quaternion.identity);
        Rigidbody2D rb = skill2Swam.GetComponent<Rigidbody2D>();
        float x = transform.localScale.x;
        skill2Swam.transform.localScale = new Vector3(x, skill2Swam.transform.localScale.y, skill2Swam.transform.localScale.z);
        rb.AddForce((new Vector3(x, 0, 0)) * 20, ForceMode2D.Impulse);
    }
}

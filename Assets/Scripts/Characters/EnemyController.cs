using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyController : MonoBehaviour
{
    private EnemyHealth enemyHealth;
    public GameObject skill1;
    public bool isSkill1Distance = false;
    public float skill1DistanceForce = 20f;
    public Transform skill1Pos;
    public float timeBetweenSkill1 = 1f;
    public float delaySkill1 = 0f;

    private GameObject skill1Swam;
    private float skill1Timer;

    private Animator animator;

    PlayerController playerController;
    public Transform player;

    public int minDamage;
    public int maxDamage;

    private float timeDamagePlayer = 1f;

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (timeDamagePlayer > 0)
            {
                return;
            }
            playerController = collision.gameObject.GetComponent<PlayerController>();
            playerController.TakeDamage(Random.Range(minDamage, maxDamage));
            timeDamagePlayer = 1f;
        }
    }


    private void Awake()
    {
        enemyHealth = GetComponent<EnemyHealth>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    public void TakeDamage(int damage)
    {
        enemyHealth.TakeDamage(damage);
        animator.SetTrigger("takeDamage");
    }
    private void Start()
    {
        animator = GetComponentInChildren<Animator>();
    }

    private void Update()
    {
        skill1Timer -= Time.deltaTime;
        timeDamagePlayer -= Time.deltaTime;
    }

    public void Skill1()
    {
        if (skill1Timer > 0)
        {
            return;
        }
        skill1Timer = timeBetweenSkill1;
        animator.SetTrigger("skill1");

        StartCoroutine(CoroutineHelper.DelaySeconds(() =>
        {
            if (isSkill1Distance)
            {
                skill1Swam = Instantiate(skill1, skill1Pos.position, Quaternion.identity);
                Rigidbody2D rb = skill1Swam.GetComponent<Rigidbody2D>();

                Vector3 direction = player.position - skill1Pos.position;
                direction.Normalize();
                float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
                rb.rotation = angle;
                rb.AddForce(direction * skill1DistanceForce, ForceMode2D.Impulse);
            }
            else
            {
                skill1Swam = Instantiate(skill1, skill1Pos.position, Quaternion.identity);
            }
        }, delaySkill1));
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoveController : MonoBehaviour
{
    private Animator animator;

    public float move;
    public float speed;
    public float jumpForce = 3f;
    public float forwardForce;
    public bool isFacingRight = true;

    public Transform player; 
    public float moveSpeed = 4f;

    // khoang cach voi player
    public float distance;

    EnemyController enemyController;

    private Canvas healthBarCanvas;


    private void Awake()
    {
        animator = GetComponentInChildren<Animator>();

        player = GameObject.FindGameObjectWithTag("Player").transform;
        enemyController = transform.GetComponent<EnemyController>();
    }

    void Start()
    {
        if (player == null)
        {
            Debug.LogError("Không tìm thấy đối tượng có tag Player");
        }

        healthBarCanvas = GetComponentInChildren<Canvas>();
    }

    void Update()
    {
        // quay thanh HP bar
        if (healthBarCanvas != null)
        {
            if (transform.localScale.x < 0)
            {
                healthBarCanvas.transform.localScale = new Vector3(-Mathf.Abs(healthBarCanvas.transform.localScale.x), 1, 1);
            }
            else
            {
                healthBarCanvas.transform.localScale = new Vector3(Mathf.Abs(healthBarCanvas.transform.localScale.x), 1, 1);
            }
        }

        // Kiểm tra nếu player không tồn tại hoặc đã bị hủy
        if (player == null)
        {
            return;
        }

        // Di chuyển Enemy đến gần Player
        if ((Mathf.Abs(transform.position.x - player.position.x) > distance))
        {
            float step = moveSpeed * Time.deltaTime;
            // nếu player quá xa thì di chuyển nhanh hơn
            if (Mathf.Abs(transform.position.x - player.position.x) > 30)
            {
                step = moveSpeed * 5 * Time.deltaTime;
            }

            transform.position = Vector3.MoveTowards(transform.position, new Vector3(player.position.x, 
                transform.position.y, player.position.z), step);
            animator.SetFloat("move", 1);
        }
        else
        {
            if (GameObject.Find(enemyController.skill1.name + "(Clone)") == null)
            {
                enemyController.Skill1();
            }
            else
            {
                animator.SetFloat("move", 0);
            }
        }

        Flip();
        
    }

    public void Flip()
    {
        if (transform.position.x < player.position.x)
        {
            transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, 1);
        }
        else if (transform.position.x > player.position.x)
        {
            transform.localScale = new Vector3(-Mathf.Abs(transform.localScale.x), transform.localScale.y, 1);
        }
    }

    public void Jump()
    {
        GetComponent<Rigidbody2D>().AddForce(new Vector2(transform.localScale.x * forwardForce, jumpForce), ForceMode2D.Impulse);
    }

}

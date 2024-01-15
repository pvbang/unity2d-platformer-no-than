using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveController : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator animator;
    [SerializeField] private DynamicJoystick dynamicJoystick;

    public float move;
    public float speed;
    public float jumpForce;

    public bool isFacingRight = true;
    private bool isJumping;

    public LayerMask ground;
    public Transform groundCheck;
    private bool isGrounded;

    public LayerMask objects;
    public Transform objectCheckLeft;
    public Transform objectCheckRight;
    private bool isObject;

    public float dashBoost;
    public float dashTime;
    private float _dashTime;
    bool isDashing = false;
    public Transform dashEffect;

    private Canvas healthBarCanvas;
    PlayerController playerController;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponentInChildren<Animator>();
        playerController = GetComponent<PlayerController>();

        GameObject canvasObject = GameObject.Find("CanvasHealthBar");
        if (canvasObject != null)
        {
            healthBarCanvas = canvasObject.GetComponent<Canvas>();
        }
    }

    private void Update()
    {
        // check object
        isObject = Physics2D.OverlapCircle(objectCheckLeft.position, 0.15f, objects);
        if (!isObject) isObject = Physics2D.OverlapCircle(objectCheckRight.position, 0.15f, objects);
        if (!isObject) isObject = Physics2D.OverlapCircle(groundCheck.position, 0.15f, objects);

        // double jump pc
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.15f, ground);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            doubleJump();
        }

        // skill1 pc
        if (Input.GetKeyDown(KeyCode.Z))
        {
            if (GameObject.Find("PlayerSkill1(Clone)") == null)
            {
                playerController.Skill1();
            }
            else
            {
                animator.SetFloat("move", 0);
            }
        }

        // skill2 pc
        if (Input.GetKeyDown(KeyCode.X))
        {
            if (GameObject.Find("PlayerSkill2(Clone)") == null)
            {
                playerController.Skill2();
            }
            else
            {
                animator.SetFloat("move", 0);
            }
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            dash();
        }

        // animator
        animator.SetFloat("move", Mathf.Abs(move));

        // move
        move = dynamicJoystick.Horizontal;
        if (move == 0)
        {
            move = Input.GetAxisRaw("Horizontal");
        }

        rb.velocity = new Vector2(move * speed, rb.velocity.y);

        if (move < 0) move = -1;
        else if (move > 0) move = 1;
        else move = 0;

        if (isFacingRight == true && move < 0)
        {
            Flip();
        }
        else if (isFacingRight == false && move > 0)
        {
            Flip();
        }

        // dash
        if ((_dashTime <= 0) && (isDashing == true))
        {
            speed -= dashBoost;
            isDashing = false;
        }
        else
        {
            _dashTime -= Time.deltaTime;
        }


        

    }

    // quay mat
    public void Flip()
    {
        isFacingRight = !isFacingRight;
        transform.localScale = new Vector3(move, 1, 1);
        if (healthBarCanvas != null)
        {
            healthBarCanvas.transform.localScale = new Vector3(transform.localScale.x, 1, 1);
        }
    }

    // nhay 2 lan
    public void doubleJump()
    {
        if (isGrounded | isObject)
        {
            animator.SetTrigger("jump");
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            isJumping = true;
        }
        else if (isJumping)
        {
            animator.SetTrigger("jump");
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            isJumping = false;
        }
    }

    // luot di
    public void dash()
    {
        if ((isDashing == false) && (_dashTime <= 0) && (move != 0))
        {
            speed += dashBoost;
            _dashTime = dashTime;
            isDashing = true;

            Transform _dashEffect = Instantiate(dashEffect, new Vector3(groundCheck.position.x, groundCheck.position.y + 0.15f, groundCheck.position.z), Quaternion.identity);
            if (transform.localScale.x > 0) _dashEffect.localScale = new Vector3(1, 1, 1);
            else _dashEffect.localScale = new Vector3(-1, 1, 1);
        }
    }

}

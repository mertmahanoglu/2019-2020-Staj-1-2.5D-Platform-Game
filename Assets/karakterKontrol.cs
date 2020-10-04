using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class karakterKontrol : MonoBehaviour
{

    public Animator animator;
    public float runSpeed = 40f;
    public static float runKats = 15f;


    SpriteRenderer spriteRenderer; // Karakterin sprite renderer bölümüne ulaşmak için

    Rigidbody2D fizik;
    //Wall Jumping
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;
    public float jumpForce;
    bool isTouchingFront;
    public Transform frontCheck;
    bool wallSliding;
    public float wallSlidingSpeed;
    bool wallJumping;
    public float xWallForce;
    public float yWallForce;
    public float WallJumpTime;

    //******************
    float horizontal = 0f;
    float horizontalMove = 0f;

    Vector3 vec;

    bool jump = true;
    bool jump2 = true;
    public static bool isDead = false;
    bool isGrounded;

    //Score Text Kodları
    public static int coinCount = 0;
    public static int artisMik = 5;
    public GameObject CoinText;




    void Start()
    {
        if (runKats == 0)
        {
            PlayerPrefs.SetFloat("MaxSpeed", 15f);
            runKats = PlayerPrefs.GetFloat("MaxSpeed");
            Debug.Log("runkats");
        }
        else
        {
            runKats = PlayerPrefs.GetFloat("MaxSpeed");
            Debug.Log(runKats);
            artisMik = PlayerPrefs.GetInt("MaxBoost");
            Debug.Log(artisMik);
        }

        spriteRenderer = GetComponent<SpriteRenderer>();
        fizik = GetComponent<Rigidbody2D>();
        if (coinCount == 0)
        {

            PlayerPrefs.SetInt("MaxCoin", 500);
            coinCount = PlayerPrefs.GetInt("MaxCoin");
        }
        coinCount = PlayerPrefs.GetInt("MaxCoin");
        CoinText.GetComponent<TextMeshProUGUI>().text = coinCount.ToString();



    }


    void Update()
    {
        CoinText.GetComponent<TextMeshProUGUI>().text = coinCount.ToString();

        if (isDead == false)
        {

            animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

            horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
            if (horizontalMove > 0)
            {
                transform.localScale = new Vector3(6, 6, 6);
            }
            else
            {
                transform.localScale = new Vector3(-6, 6, 6);
            }





            if (Input.GetKeyDown(KeyCode.Space))

            {

                if (jump && jump2)

                {

                    fizik.AddForce(new Vector2(0, 900));

                    jump = false;

                    animator.SetTrigger("jumpTrigger");
                }

                else if (!jump && jump2)

                {

                    fizik.AddForce(new Vector2(0, 900));

                    jump = false;

                    jump2 = false;
                    animator.SetTrigger("jumpTrigger");
                }

            }
        }
        else
        {
            isDead = true;
        }

        isTouchingFront = Physics2D.OverlapCircle(frontCheck.position, checkRadius, whatIsGround);

        if (isTouchingFront && isGrounded == false)
        {
            wallSliding = true;
        }
        else
        {
            wallSliding = false;
        }
        if (wallSliding)
        {
            fizik.velocity = new Vector2(fizik.velocity.x, Mathf.Clamp(fizik.velocity.y, -wallSlidingSpeed, float.MaxValue));

        }


        if (Input.GetKeyDown(KeyCode.Space) && wallSliding)
        {
            wallJumping = true;
            Invoke("jumpFalse", WallJumpTime);
        }

        if (wallJumping)
        {
            fizik.velocity = new Vector2(xWallForce * -1, yWallForce);
        }



    }

    void jumpFalse()
    {
        wallJumping = false;

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        jump = true;
        jump2 = true;



    }

    void FixedUpdate()
    {

        karakterHareket();

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Coin"))
        {

            coinCount += artisMik;
            PlayerPrefs.SetInt("MaxCoin", coinCount);

        }
    }

    void karakterHareket()
    {

        if (isDead == false)
        {
            horizontal = Input.GetAxisRaw("Horizontal");

            if (horizontal < 0)
            {
                vec = new Vector3(horizontal * runKats, fizik.velocity.y, 0);
                fizik.velocity = vec;
            }
            else
            {
                vec = new Vector3(horizontal * runKats, fizik.velocity.y, 0);
                fizik.velocity = vec;
            }
        }
        else
        {
            isDead = true;
        }

    }



}

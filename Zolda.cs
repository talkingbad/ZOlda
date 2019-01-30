using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;

public class Zolda : MonoBehaviour {

    public float speed;

    private Rigidbody2D rb;

    Gameboard gameBoard;

    SoundManager soundManager;

    Animator animator;

    bool facingRight = false;
    bool facingLeft = false;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        gameBoard = FindObjectOfType(typeof(Gameboard)) as Gameboard;
        soundManager = GameObject.Find("SoundManager").GetComponent<SoundManager>
            ();
        animator = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        float horzMove = Input.GetAxisRaw("Horizontal");
        float vertMove = Input.GetAxisRaw("Vertical");

        if (gameBoard.isValidSpace((float)transform.position.x + horzMove,
            (float)transform.position.y + vertMove, horzMove, vertMove))
        {
            rb.velocity = new Vector2(horzMove * speed, vertMove * speed);


        } else
        {
            rb.velocity = new Vector2(0, 0);
        }

        if (Input.GetKey("s"))
        {
            animator.Play("walkdown");
        }
        if (Input.GetKey("w"))
        {
            animator.Play("walkup");
        }
        if (Input.GetKey("d"))
        {
            animator.Play("walkright");

            if (facingLeft)
            {
                facingRight = true;
                facingLeft = false;
                animator.transform.Rotate(0, 180, 0);
            } else if (!facingLeft)
            {
                facingRight = true;
            }

            if (Input.GetKey("a"))
            {
                animator.Play("walkright");
                
                if (facingRight)
                {
                    facingRight = false;
                    facingLeft = true;
                    animator.transform.Rotate(0, 180, 0);
                }
                else if (!facingRight)
                {
                    facingLeft = true;
                }


            }

            if (Input.GetKeyUp("s"))
            {
                animator.Play("idle");

                float centerX = (float)Math.Round(Convert.ToDouble(transform.position.x));
                float centerY = (float)Math.Round(Convert.ToDouble(transform.position.y));
                transform.position = new Vector2(centerX, centerY);
            }
            }






        }


        // Use this for initialization
        void Start()
        {
            float targetaspect = 16.0f / 9.0f;

            float windowaspect = (float)Screen.width / (float)Screen.height;

            float scaleheight = windowaspect / targetaspect;

            Camera camera = GetComponent<Camera>();

            if (scaleheight < 1.0f)
            {
                Rect rect = camera.rect;

                rect.width = 1.0f;
                rect.height = scaleheight;
                rect.x = 0;
                rect.y = (1.0f - scaleheight) / 2.0f;

                camera.rect = rect;
            }
            else // add pillarbox
            {
                float scalewidth = 1.0f / scaleheight;

                Rect rect = camera.rect;

                rect.width = scalewidth;
                rect.height = 1.0f;
                rect.x = (1.0f - scalewidth) / 2.0f;
                rect.y = 0;

                camera.rect = rect;
            }
        }

        // Update is called once per frame
        void Update() {

        }
    }



using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    float speed;
    float speed_y;
    new Rigidbody2D rigidbody2D;
    Animator animator;


    // Start is called before the firstx  frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        animator.SetFloat("speed_x", x);
        animator.SetFloat("speed_y", y);

        if (x == 0)
        {
            speed = 0;
        }
        else if (x > 0)
        {
            speed = 3;
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if (x < 0)
        {
            speed = -3;
            transform.localScale = new Vector3(-1, 1, 1);
        }

        rigidbody2D.velocity = new Vector2(speed, rigidbody2D.velocity.y);

    }
}

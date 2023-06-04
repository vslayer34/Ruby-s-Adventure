using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed = 4.0f;
    Rigidbody2D rb;

    public bool vertical;

    float timer;
    public float changeDirectionTime = 3.0f;
    int direction = 1;

    Animator animator;
    int moveX, moveY;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        timer = changeDirectionTime;
        
        animator = GetComponent<Animator>();
        moveX = Animator.StringToHash("Move X");
        moveY = Animator.StringToHash("Move Y");
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;

        if (timer < 0)
        {
            direction *= -1;
            timer = changeDirectionTime;
        }
    }


    void FixedUpdate()
    {
        Vector2 position = rb.position;

        if (vertical)
        {
            position.y += speed * Time.deltaTime * direction;
            animator.SetFloat(moveX, 0);
            animator.SetFloat(moveY, direction);
        }
        else
        {
            position.x += speed * Time.deltaTime * direction;
            animator.SetFloat(moveX, direction);
            animator.SetFloat(moveY, 0);
        }

        rb.MovePosition(position);
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        RubyController controller = collision.gameObject.GetComponent<RubyController>();

        controller?.ChangeHealth(-1);
    }
}

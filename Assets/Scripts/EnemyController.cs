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

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        timer = changeDirectionTime;
        Debug.Log("start" + timer);
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        Debug.Log(timer);
        if (timer < 0)
        {
            Debug.Log("Change Direction");
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
        }
        else
        {
            position.x += speed * Time.deltaTime * direction;
        }

        rb.MovePosition(position);
    }
}

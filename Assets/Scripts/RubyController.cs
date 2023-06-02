using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RubyController : MonoBehaviour
{
    float horizontal;
    float vertical;

    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // get user input
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
    }

    void FixedUpdate()
    {
        // calculate the new rigidbody position
        Vector2 position = rb.position;
        position.x += 3.0f * horizontal * Time.fixedDeltaTime;
        position.y += 3.0f * vertical * Time.fixedDeltaTime;

        // apply the new rigidbody position to the gameobject
        rb.MovePosition(position);
    }
}

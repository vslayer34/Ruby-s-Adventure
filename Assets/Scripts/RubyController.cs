using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RubyController : MonoBehaviour
{
    // health stats
    [SerializeField] int maxHealth = 5;
    int currentHealth;

    float horizontal;
    float vertical;

    [SerializeField] float speed = 3.0f;

    Rigidbody2D rb;

    // properties
    public int Health { get => currentHealth; }
    public int MaxHealth { get => maxHealth; }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currentHealth = maxHealth;
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
        position.x += speed * horizontal * Time.fixedDeltaTime;
        position.y += speed * vertical * Time.fixedDeltaTime;

        // apply the new rigidbody position to the gameobject
        rb.MovePosition(position);
    }

    public void ChangeHealth(int amount)
    {
        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
        Debug.Log($"Health: {currentHealth}/{maxHealth}");
    }
}

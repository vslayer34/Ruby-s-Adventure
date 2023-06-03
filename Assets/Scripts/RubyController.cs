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

    bool isInvincible;
    float invinciblityTimer;
    float invincibilityDuration = 2.0f;

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

        if (isInvincible)
        {
            invinciblityTimer -= Time.deltaTime;
            if (invinciblityTimer < 0)
            {
                isInvincible = false;
            }
        }
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
        if (amount < 0)
        {
            if (isInvincible)
                return;

                isInvincible = true;
                invinciblityTimer = invincibilityDuration;
        }

        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
        Debug.Log($"Health: {currentHealth}/{maxHealth}");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RubyController : MonoBehaviour
{
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] ParticleSystem dizzyEffect;

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

    // Animator
    Animator animator;
    Vector2 lookDirection = new Vector2(1, 0);
    int animatorSpeed, lookX, lookY, hit, launch;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currentHealth = maxHealth;

        // get animator parameters id
        animator = GetComponent<Animator>();
        animatorSpeed = Animator.StringToHash("Speed");
        lookX = Animator.StringToHash("Look X");
        lookY = Animator.StringToHash("Look Y");
        hit = Animator.StringToHash("Hit");
        launch = Animator.StringToHash("Launch");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            Launch();
        }
        // get user input
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        Vector2 move = new Vector2(horizontal, vertical);

        if (!Mathf.Approximately(move.x, 0) || !Mathf.Approximately(move.y, 0))
        {
            lookDirection.Set(move.x, move.y);
            lookDirection.Normalize();
        }

        animator.SetFloat(lookX, lookDirection.x);
        animator.SetFloat(lookY, lookDirection.y);
        animator.SetFloat(animatorSpeed, move.magnitude);

        if (isInvincible)
        {
            invinciblityTimer -= Time.deltaTime;
            if (invinciblityTimer < 0)
            {
                isInvincible = false;
            }
        }

        if (Input.GetKeyDown(KeyCode.X))
        {
            RaycastHit2D hit = Physics2D.Raycast(rb.position + Vector2.up * 0.2f, lookDirection, 1.5f, LayerMask.GetMask("NPC"));

            if (hit.collider != null)
            {
                NonPlayerCharacter character = hit.collider.GetComponent<NonPlayerCharacter>();
                
                if (character != null)
                {
                    character.DisplayDialog();
                }
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

            dizzyEffect.Play();
            animator.SetTrigger(hit);
            isInvincible = true;
            invinciblityTimer = invincibilityDuration;
        }

        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
        UIHealthBar.Instance.SetValue(currentHealth / (float)maxHealth);
    }

    void Launch()
    {
        GameObject projectileObject = Instantiate(bulletPrefab, rb.position + Vector2.up * 0.5f, Quaternion.identity);

        Projectile projectileScript = projectileObject.GetComponent<Projectile>();
        projectileScript.Launch(lookDirection, 300.0f);
        animator.SetTrigger(launch);
    }
}

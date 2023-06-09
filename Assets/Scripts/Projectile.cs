using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField] ParticleSystem robotHitEffect;
    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] AudioClip flyingCogAudioClip;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (transform.position.magnitude > 1000)
        {
            Destroy(gameObject);
        }
    }

    public void Launch(Vector2 direction, float force)
    {
        rb.AddForce(direction * force);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        EnemyController enemyController = collision.gameObject.GetComponent<EnemyController>();

        if (enemyController != null)
        {
            robotHitEffect.Play();
            enemyController.Fix();
        }

        rb.velocity = Vector2.zero;
        spriteRenderer.enabled = false;
        Destroy(gameObject, 0.6f);
    }

    public AudioClip GetAudioClip() => flyingCogAudioClip;
}

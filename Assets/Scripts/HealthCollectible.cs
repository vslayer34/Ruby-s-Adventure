using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthCollectible : MonoBehaviour
{
    [SerializeField] AudioClip collectAudioClip;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        RubyController controller = collision.GetComponent<RubyController>();

        if (controller != null && controller.Health < controller.MaxHealth)
        {
            controller.PlaySound(collectAudioClip);
            controller.ChangeHealth(1);
            Debug.Log($"{collision.name} Ruby gained 1 health.");
            Destroy(gameObject);
        }
    }
}

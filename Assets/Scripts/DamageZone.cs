using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageZone : MonoBehaviour
{
    [SerializeField] AudioClip rubyScreamAudio;

    private void OnTriggerStay2D(Collider2D collision)
    {
        RubyController controller = collision.GetComponent<RubyController>();

        controller?.ChangeHealth(-1, rubyScreamAudio);
    }
}

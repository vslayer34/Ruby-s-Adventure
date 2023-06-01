using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RubyController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // get user input
        float horizontal = Input.GetAxis("Horizontal");
        float vetrical = Input.GetAxis("Vertical");

        // calculate the new transform position
        Vector2 position = transform.position;
        position.x += 3.0f * horizontal * Time.deltaTime;
        position.y += 3.0f * vetrical * Time.deltaTime;

        // apply the new transform position to the gameobject
        transform.position = position;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D body;
    Animator anim;
    public GameObject camera;

    float horizontal;
    float vertical;
    float moveLimiter = 0.7f;

    public float runSpeed = 20.0f;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        anim = gameObject.GetComponent<Animator>();
        anim.SetBool("Moving", false);
        anim.SetInteger("Direction", 3);
        camera.SetActive(false);
    }

    void Update()
    {
        // Gives a value between -1 and 1
        horizontal = Input.GetAxisRaw("Horizontal"); // -1 is left
        vertical = Input.GetAxisRaw("Vertical"); // -1 is down

        GetComponent<SpriteRenderer>().sortingOrder = Mathf.RoundToInt(transform.position.y * 100f) * -1;
        

        if (horizontal == -1) {
            anim.SetBool("Moving", true);
            anim.SetInteger("Direction", 2);
        } else if (horizontal == 1) {
            anim.SetBool("Moving", true);
            anim.SetInteger("Direction", 4);
        } else if (vertical == 1) {
            anim.SetBool("Moving", true);
            anim.SetInteger("Direction", 1);
        } else if (vertical == -1) {
            anim.SetBool("Moving", true);
            anim.SetInteger("Direction", 3);
        } else {
            anim.SetBool("Moving", false);
        }

    }

    void FixedUpdate()
    {
        if (horizontal != 0 && vertical != 0) // Check for diagonal movement
        {
            // limit movement speed diagonally, so you move at 70% speed
            horizontal *= moveLimiter;
            vertical *= moveLimiter;
        }

        body.velocity = new Vector2(horizontal * runSpeed, vertical * runSpeed);


        if (Input.GetKeyDown("e") && !camera.activeSelf)
        {
            camera.SetActive(true);
        }
        else if (Input.GetKeyDown("e") && camera.activeSelf)
        {
            camera.SetActive(false);
        }
    }
}

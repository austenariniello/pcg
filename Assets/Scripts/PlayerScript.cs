using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{

    private float horizontal;
    private float vertical;
    private float speed = 10.0f;
    Rigidbody2D rb;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
        GetPlayerInput();
        MovePlayer();

    }

    private void GetPlayerInput() {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
        if (horizontal > 0)
        {
            GetComponent<Animator>().Play("Right");
        } else if (horizontal < 0)
        {
            GetComponent<Animator>().Play("Left");

        } else if (vertical > 0)
        {
            GetComponent<Animator>().Play("Up");
        } else if (vertical < 0)
        {
            GetComponent<Animator>().Play("Down");
        }
    }

    private void MovePlayer() {
        Vector3 directionVector = new Vector3(horizontal, vertical, 0);
        rb.velocity = directionVector.normalized * speed;
    }
}

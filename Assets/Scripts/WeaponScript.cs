using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponScript : MonoBehaviour
{

    private bool swing = false;
    int degree = 0;
    private float weaponY = -0.6f;
    private float weaponX = 0.3f;
    
    Vector3 pos;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        GetComponent<SpriteRenderer>().enabled = false;
        transform.GetChild(0).gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        if (!player) {
            player = GameObject.FindWithTag("Player");
        }

        if (Input.GetKeyDown("x"))
        {
            GetComponent<SpriteRenderer>().enabled = true;
            transform.GetChild(0).gameObject.SetActive(true);
            Attack();
        }
    }

    private void FixedUpdate()
    {
        if (swing)
        {

            if (player.GetComponent<PlayerScript>().turnedLeft) {

                degree += 7;
                if(degree > 65)
                {
                    degree = 0;
                    swing = false;
                    GetComponent<SpriteRenderer>().enabled = false;
                    transform.GetChild(0).gameObject.SetActive(false);
                }
                transform.eulerAngles = Vector3.forward * degree;

            }
            else {

                degree -= 7;
                if(degree < -65)
                {
                    degree = 0;
                    swing = false;
                    GetComponent<SpriteRenderer>().enabled = false;
                    transform.GetChild(0).gameObject.SetActive(false);
                }
                transform.eulerAngles = Vector3.forward * degree;

            }
            
        }
    }

    void Attack()
    {
        if(player.GetComponent<PlayerScript>().turnedLeft)
        {
            transform.localScale = new Vector3(-6f, 6f, 1);
            weaponX = -0.3f;
        }
        else
        {
            transform.localScale = new Vector3(6f, 6f, 1);
            weaponX = 0.3f;
        }

        pos = player.transform.position;
        pos.x += weaponX;
        pos.y += weaponY;
        transform.position = pos;
        swing = true;
    }

}

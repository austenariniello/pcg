using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponColliderScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision) {

        print("collision");

        if (collision.gameObject.CompareTag("Enemy")) {
            print("enemy collision");
            Destroy(collision.gameObject);
        }
    }
}

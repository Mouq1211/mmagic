using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    float speedX, speedY;
    Rigidbody2D rb;
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        speedX = Input.GetAxis("Horizontal") * moveSpeed;
        speedY = Input.GetAxis("Vertical") * moveSpeed;
        rb.velocity = new Vector3(speedX, speedY);
        Punch();
    }
    void Punch()
    {
        if (Input.GetMouseButtonDown(0))
        {
            anim.SetTrigger("soco");
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            GetComponent<HealthComponent>().TakeDamage(1); 
        }
    }


}

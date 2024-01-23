using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobileProjectile : MonoBehaviour
{
    public Rigidbody2D projectileRb;
    public float speed;
    public float projectileLife;
    public float projectileCount;
    public MobileMove playerMovement;
    public bool facingright;
    public bool facingLeft;
    // Start is called before the first frame update
    void Start()
    {
        projectileCount = projectileLife;
        playerMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<MobileMove>();
        //facingright = playerMovement.playerHasHorizontalSpeed;
        facingright = GameObject.FindWithTag("Player").GetComponent<Rigidbody2D>().velocity.x < Mathf.Epsilon;
        facingLeft = GameObject.FindWithTag("Player").GetComponent<Rigidbody2D>().velocity.x > Mathf.Epsilon;
    }

    // Update is called once per frame
    void Update()
    {
        projectileCount -= Time.deltaTime;
        if (projectileCount <= 1)
        {
            Destroy(gameObject);
        }

    }
    private void FixedUpdate()
    {
        //get inputs for A D to put transform rotation and have a sinbgle button
        if (Input.GetKey(KeyCode.A))
        {

            facingLeft = true;
            facingright = false;
            projectileRb.velocity = new Vector2(-speed, projectileRb.velocity.y);
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        
        if (Input.GetKey(KeyCode.D))
        {
            facingright = true;
            facingLeft = false;
            projectileRb.velocity = new Vector2(speed, projectileRb.velocity.y);
            transform.rotation = Quaternion.Euler(0, -180, 0);
        }

        
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "enemy")
        {
            collision.gameObject.GetComponent<EnemyHealth>().TakeDamage(1);
        }
        Destroy(gameObject);
    }
}

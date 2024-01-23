using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField] GameObject prefab;
    [SerializeField] float bulletSpeed = 15;
    [SerializeField] bool mouseShoot;
    float x = 1;
    float y = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float tempX = Input.GetAxisRaw("Horizontal");
        float tempY = Input.GetAxisRaw("Vertical");
        if(mouseShoot)
        {
            Vector3 mousePosition =Input.mousePosition;
            mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
            Vector3 shootDir = mousePosition - transform.position;
            shootDir.z = 0;
            shootDir.Normalize();
            x = shootDir.x;
            y = shootDir.y;
        }
        else
        {
            if (tempX != 0 || tempY != 0)
            {

                x = tempX;
                y = tempY;
            }
            
        }
        if (Input.GetButton("Fire1"))
        {
            GameObject Bullet = Instantiate(prefab, transform.position, Quaternion.identity);
            Bullet.GetComponent<Rigidbody2D>().velocity = new Vector2(x, y) * bulletSpeed;
            Destroy(Bullet, 3);
        }
    }
}

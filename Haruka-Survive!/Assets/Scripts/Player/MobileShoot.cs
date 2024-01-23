using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobileShoot : MonoBehaviour
{
    public GameObject projectilePrefab;
    public Transform launchPoint;
    
    public float shootTime;
    public float shootCounter;
    // Start is called before the first frame update
    void Start()
    {
        shootCounter = 0;
        shootCounter = shootTime;
    }
    // Update is called once per frame
    void Update()
    {
        shootCounter -= Time.deltaTime;
    }
    private void FixedUpdate()
    {
        //get inputs for A D to put transform rotation and have a sinbgle button
        if (Input.GetKey(KeyCode.E))
        {
            if (shootCounter < 0)
            {
                Instantiate(projectilePrefab, launchPoint.position, Quaternion.identity);
                shootCounter = shootTime;
                shootCounter -= Time.deltaTime;
            }

        }

    }
    /*
    void OnLeftprojectile()
    {

        if (shootCounter < 0)
        {
            Instantiate(projectilePrefab, launchPoint.position, Quaternion.identity);
            shootCounter = shootTime;
            shootCounter -= Time.deltaTime;
        }
    }
    void OnRightprojectile()
    {

        if (shootCounter < 0)
        {
            Instantiate(projectilePrefab, launchPoint.position, Quaternion.identity);
            shootCounter = shootTime;
            shootCounter -= Time.deltaTime;
        }
    }
    */
}

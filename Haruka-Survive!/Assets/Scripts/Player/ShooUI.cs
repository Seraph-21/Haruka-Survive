using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShooUI : MonoBehaviour
{
    public float shootTime;
    public float shootCounter;
    [SerializeField] TextMeshProUGUI myText;
    // Start is called before the first frame update
    void Start()
    {
        
        shootCounter = shootTime;
    }

    // Update is called once per frame
    void Update()
    {
        shootCounter -= Time.deltaTime;
        if (shootCounter > 0)
        {
            myText.text = "wait?";
        }
        if (shootCounter <= 0)
        {
            myText.text = "Fire!";
        }

    }
    
    
    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.Q))
        {
           
            
            shootCounter = shootTime;
        }
        if (Input.GetKey(KeyCode.E))
        {
            
            
            shootCounter = shootTime;
        }


    }
}

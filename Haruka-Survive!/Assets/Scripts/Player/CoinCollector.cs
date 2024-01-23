using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class CoinCollector : MonoBehaviour
{
    [SerializeField] int coinCount = 0;
    [SerializeField] TextMeshProUGUI myText;
    
     void OnTriggerEnter2D(Collider2D collision)
     {
        if(collision.gameObject.tag=="Coins")
        {
            Destroy(collision.gameObject);
            coinCount++;
            myText.text = "Coins" + coinCount;
        }    
     } 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

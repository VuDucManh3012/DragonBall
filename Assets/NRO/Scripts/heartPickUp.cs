using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class heartPickUp : MonoBehaviour
{
    public float healthAmount;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Player")
        {
            PlayerHealth thePlayerHealth = other.gameObject.GetComponent<PlayerHealth> ();
            thePlayerHealth.addHealth(healthAmount);
            Destroy (gameObject);
        }    
    }
}

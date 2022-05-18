using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletEnemy : MonoBehaviour
{
    Bullet myPC;
    public GameObject bulletExplosion;

    public float weaponDamage;
    void Awake() 
    {
        myPC = GetComponent<Bullet> ();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            myPC.removeForce();
            Instantiate(bulletExplosion, transform.position, transform.rotation);
            Destroy(gameObject);
            PlayerHealth hurt = other.gameObject.GetComponent<PlayerHealth> ();
            hurt.addDamage (weaponDamage);
        }
    }

    void OnTriggerStay2D(Collider2D other) 
    {
        if(other.gameObject.tag == "Player")
        {
            myPC.removeForce();
            Instantiate(bulletExplosion, transform.position, transform.rotation);
            Destroy(gameObject);
            PlayerHealth hurt = other.gameObject.GetComponent<PlayerHealth> ();
            hurt.addDamage (weaponDamage);
        }
    }
}

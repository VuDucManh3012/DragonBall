using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletHit : MonoBehaviour
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
        if(other.gameObject.tag == "Shotable")
        {
            myPC.removeForce();
            Instantiate(bulletExplosion, transform.position, transform.rotation);
            Destroy(gameObject);
            if(other.gameObject.layer == LayerMask.NameToLayer("Enemy"))
            {
                EnemyHealth hurtEnemy = other.gameObject.GetComponent<EnemyHealth> ();
                hurtEnemy.addDamage (weaponDamage);
            }
        }
    }

    void OnTriggerStay2D(Collider2D other) 
    {
        if(other.gameObject.tag == "Shotable")
        {
            myPC.removeForce();
            Instantiate(bulletExplosion, transform.position, transform.rotation);
            Destroy(gameObject);
            if(other.gameObject.layer == LayerMask.NameToLayer("Enemy"))
            {
                EnemyHealth hurtEnemy = other.gameObject.GetComponent<EnemyHealth> ();
                hurtEnemy.addDamage (weaponDamage);
            }
        }
    }
}

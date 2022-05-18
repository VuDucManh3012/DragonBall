using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovementController : MonoBehaviour
{

    public float enemySpeed;

    Rigidbody2D enemyRB;
    Animator enemyAnim;

    //Init facing
    public GameObject enemyGraphic;
    bool facingRight = true;
    float facingTime = 5f;
    float nextFlip =0f;
    bool canFlip = true;

    //Init Fire
    public Transform gunTipEnemy;
    public GameObject bullet;
    public float fireRate =4f;
    public float nextFire =6f;

    public GameObject bullet2;
    public float fireRate2 =0.1f;
    public float nextFire2 =6f;
    public float FirePowerStart =6f;
    public float FirePowerStop = 21f;
    public float timeFirePower =15f;
    public float timeFirePowerStop =20f;

    void Awake() {
        enemyRB = GetComponent<Rigidbody2D> ();
        enemyAnim = GetComponentInChildren<Animator> ();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time > nextFlip)
        {
            nextFlip = Time.time + facingTime;
            flip ();
            
        }    
        if(Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            fireBullet();
        }
        if(Time.time > FirePowerStart && Time.time < FirePowerStop)
        {
            if(Time.time > nextFire2)
            {
                nextFire2 = Time.time + fireRate2;
                fireBullet2();
            }
        }else if(Time.time > FirePowerStop)
        {
            FirePowerStop = Time.time + timeFirePower + timeFirePowerStop;
            FirePowerStart = Time.time + timeFirePowerStop;
        }
        
        
    }

    void flip()
    {
        if(!canFlip){
            return;
        }
        facingRight = !facingRight;
        Vector3 theScale = enemyGraphic.transform.localScale;
        theScale.x *= -1;
        enemyGraphic.transform.localScale = theScale;
    }

    void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Player")
        {
            if(facingRight && other.transform.position.x < transform.position.x)
            {
                flip();
            }else if(!facingRight && other.transform.position.x > transform.position.x)
            {
                flip();
            }
            canFlip=false;
        }    
    }

    void OnTriggerStay2D(Collider2D other) {
        if(other.tag == "Player")
        {
            if(!facingRight)
            {
                enemyRB.AddForce(new Vector2 (-1,0) * enemySpeed);
            }else
            {
                enemyRB.AddForce(new Vector2 (1,0) *enemySpeed);
            }
        }    
    }

    void OnTriggerExit2D(Collider2D other) {
        if(other.tag == "Player")
        {
            canFlip=true;
            enemyRB.velocity = new Vector2 (0, 0);
        }    
    }
    
    void fireBullet(){
        if(facingRight){
            Instantiate(bullet, gunTipEnemy.position, Quaternion.Euler(new Vector3(0,0,0)));
        }else if(!facingRight)
        {
            Instantiate(bullet, gunTipEnemy.position, Quaternion.Euler(new Vector3(0,0,180)));
        }
    }
    void fireBullet2(){
        if(facingRight){
            Instantiate(bullet2, gunTipEnemy.position, Quaternion.Euler(new Vector3(0,0,0)));
        }else if(!facingRight)
        {
            Instantiate(bullet2, gunTipEnemy.position, Quaternion.Euler(new Vector3(0,0,180)));
        }
    }
}

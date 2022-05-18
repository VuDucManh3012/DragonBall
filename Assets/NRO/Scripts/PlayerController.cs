using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float maxSpeed;
    public float jumpHeight;
    
    private float nowY1;
    private float nowY2;

    bool facingRight;
    bool grounded;
    bool fire;

    //gun
    public Transform gunTip;
    public GameObject bullet;
    float fireRate =0.5f;
    float nextFire =0;

    Rigidbody2D myBody;

    Animator myAnim;

    // Start is called before the first frame update
    void Start()
    {
        myBody= GetComponent<Rigidbody2D> ();
        myAnim = GetComponent<Animator> ();
    
        facingRight = true;

        nowY1=transform.position.y;
        nowY2=transform.position.y;
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float move = Input.GetAxis("Horizontal");
        myBody.velocity = new Vector2(move*maxSpeed , myBody.velocity.y);

        myAnim.SetFloat("speed",Mathf.Abs(move));
        
        fire=false;

        nowY2=transform.position.y;
        if(nowY2>nowY1){
            myAnim.SetBool("jumpup",true);
        }else if(nowY2<=nowY1){
            myAnim.SetBool("jumpup",false);
        }
        nowY1=transform.position.y;


        if(move>0 && !facingRight){
            flip();
        }
        else if(move<0 && facingRight)
        {
            flip();
        }


        if(Input.GetKey(KeyCode.Space))
        {   
                if(grounded){
                    grounded=false;
                    myBody.velocity =new Vector2(myBody.velocity.x, jumpHeight);
                }
        }

        if(grounded){
            myAnim.SetBool("grounded",true);
            myAnim.SetBool("jumpup",false);
        }else{
            myAnim.SetBool("grounded",false);
        }


        //GunFire
        if(Input.GetAxisRaw("Fire1")>0){
            fireBullet();
            myAnim.SetBool("fire",false);
        }
        if (fire)
        {
            myAnim.SetBool("fire",true);
        }


    }
    void flip()
    {
        facingRight=!facingRight;
        Vector3 theScale= transform.localScale;
        theScale.x *=-1;
        transform.localScale = theScale;
    }

    void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag == "Ground"){
            grounded=true;
        }
    }

    void fireBullet(){
        if(Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            fire=true;
            if(facingRight){
                Instantiate(bullet, gunTip.position, Quaternion.Euler(new Vector3(0,0,0)));
            }else if(!facingRight)
            {
                Instantiate(bullet, gunTip.position, Quaternion.Euler(new Vector3(0,0,180)));
            }
        }
    }

}

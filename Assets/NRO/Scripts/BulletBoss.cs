using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBoss : MonoBehaviour
{
    public float bulletSpeed;

    Rigidbody2D myBody;
    float a;
    
    private void Awake() {
        myBody = GetComponent<Rigidbody2D>();
        a=Random.Range(-0.5f,0.5f);
        if(transform.localRotation.z >0){
            myBody.AddForce(new Vector2(-1,a) *bulletSpeed, ForceMode2D.Impulse);
            transform.localRotation = Quaternion.Euler(new Vector3(0,0,180+(-90*a)));
        }else{
            myBody.AddForce(new Vector2(1,a) *bulletSpeed, ForceMode2D.Impulse);
            transform.localRotation = Quaternion.Euler(new Vector3(0,0,90*a));
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

    //StopBullet
    public void removeForce()
    {
        myBody.velocity = new Vector2(0,0);
    }
}

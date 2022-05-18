using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnNotice : MonoBehaviour
{
    public GameObject Notice; 

    // Start is called before the first frame update
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Player")
        {
            Notice.gameObject.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D other) {
        if(other.tag == "Player")
        {
            Notice.gameObject.SetActive(false);
        }
    }

}

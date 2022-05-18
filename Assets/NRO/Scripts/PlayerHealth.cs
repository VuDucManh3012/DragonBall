using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class PlayerHealth : MonoBehaviour
{
    public float maxHealth;
    float currentHealth;

    public GameObject bloodEffect;
    Animator myAnim;
    public GameObject HealthSlider;
    public Slider playerHealthSlider;
    // Start is called before the first frame update
    void Start()
    {
        myAnim = GetComponent<Animator> ();
        currentHealth = maxHealth;    
        playerHealthSlider.maxValue = maxHealth;
        playerHealthSlider.value = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void addDamage(float damage)
    {
        if (damage <=0)
        {
            return;
        }
        currentHealth -= damage;

        playerHealthSlider.value = currentHealth;

        if(currentHealth <=0 )
        {
            makeDead();
        }

    }

    void makeDead()
    {
        Instantiate(bloodEffect , transform.position , transform.rotation);
        gameObject.SetActive(false);
        Destroy(HealthSlider);
        SceneManager.LoadScene(6);
    }

    void makeDead2()
    {
        Instantiate(bloodEffect , transform.position , transform.rotation);
        myAnim.SetBool("died",false);
    }
    
    //Heal
    public void addHealth(float healthAmount)
    {
        currentHealth += healthAmount;
        if(currentHealth > maxHealth){
            currentHealth = maxHealth;
        }
        playerHealthSlider.value = currentHealth;
    }
}

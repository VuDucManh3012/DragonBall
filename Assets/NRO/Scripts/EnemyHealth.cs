using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{

    public float maxHealth;
    float currentHealth;

    //Enemy die
    public GameObject enemyHealthEF;
    //Item When Die
    public bool drop;
    public GameObject Item;

    //Init UI
    public Slider enemyHealthSlider;
    // public Text enemyHealthText;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        enemyHealthSlider.maxValue = maxHealth;
        enemyHealthSlider.value = maxHealth;
        // enemyHealthText.text = maxHealth + " / " + maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void addDamage(float damage){
        enemyHealthSlider.gameObject.SetActive(true);
        currentHealth -= damage;
        enemyHealthSlider.value = currentHealth;
        if(currentHealth <=0){
            makeDead();
        }
        // enemyHealthText.text = currentHealth + " / " + maxHealth;
    }
    public void makeDead(){
        Instantiate(enemyHealthEF  , transform.position , transform.rotation);
        gameObject.SetActive(false);
        if(drop){
            Instantiate(Item , transform.position , transform.rotation);
        }
    }
}

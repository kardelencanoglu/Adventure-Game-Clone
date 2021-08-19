using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyManager : MonoBehaviour
{
    public float health;
    public float damage;
    
    bool colliderBusy = false; // To avoid confusion collider

    public Slider slider;
    // Start is called before the first frame update
    void Start()
    {
     slider.maxValue = health;
     slider.value = health;   
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other) // Second collider identified (Enemy) and player enters the enemy //trigger=tetikleyici
    {
        if (other.tag == "Player")
        {
            colliderBusy = false;
            other.GetComponent<PlayerManager>().GetDamage(damage); //Call the damage loop
        }
        else if (other.tag == "Bullet")
        {
            GetDamage(other.GetComponent<BulletManager>().bulletDamage);
            Destroy(other.gameObject);
        }
    }  


    private void OnTriggerExit2D(Collider2D other) // To avoid immortality
    {
        if (other.tag == "Player")
        {
            colliderBusy = false; 
        }
    }
    
         public void GetDamage(float damage) //The damage part
    {
        if ((health - damage) >= 0)
        {
            health -= damage;
        }
        else
        {
            health = 0;
        }
        slider.value = health;

        AmIDead();
        
    }


    void AmIDead()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    public float health, bulletSpeed;

    bool dead = false;

    Transform muzzle;

    public Transform bullet, floatingText;

    public Slider slider;

    // Start is called before the first frame update
    void Start()
    {
      muzzle =  transform.GetChild(1);
      slider.maxValue = health;
      slider.value = health;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ShootBullet();
        }
    }

    public void GetDamage(float damage) //The damage part
    {
        Instantiate(floatingText, transform.position, Quaternion.identity).GetComponent<TextMesh>().text =damage.ToString();
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
        if (health <=0)
        {
            dead = true;
        }
    }

    void ShootBullet()
    {
        Transform tempBullet;
        tempBullet = Instantiate(bullet, muzzle.position, Quaternion.identity);
        tempBullet.GetComponent<Rigidbody2D>().AddForce(muzzle.forward * bulletSpeed);
    }
}

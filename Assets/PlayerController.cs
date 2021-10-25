// handles collision and firing magic

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private PlayerHealth hp;

    [SerializeField]
    private Rigidbody magicBullet;

    [SerializeField]
    private Transform hand;

    void Start()
    {
        if(hp == null)
        {
            hp = this.GetComponent<PlayerHealth>();
        }
    }

    void Update()
    {
        //this should go into an input manager
        if(Input.GetKeyDown(KeyCode.Mouse0) && hp.mana >= 10)
        {
            Fire();
            hp.mana -= 10;
        }
    }

    void Fire()
    {
        Rigidbody copy = Instantiate(magicBullet, hand.position, hand.rotation);
        copy.AddRelativeForce(Vector3.forward * 50, ForceMode.Impulse); //shot bullet forward
        //copy.GetComponent<BulletController>().owner = hp;
    }


    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Enemy"))
        {
            hp.ChangeHealth(-10);
        }

        if(other.gameObject.CompareTag("HealthPotion"))
        {
            hp.ChangeHealth(25);
            Destroy(other.gameObject);
            if(hp.health >= 100)
            {
                hp.health = 100;
            }
        }

        if(other.gameObject.CompareTag("ManaPotion"))
        {
            hp.mana += 25;
            Destroy(other.gameObject);
            if(hp.mana >= 100)
            {
                hp.mana = 100;
            }
        }
    }


}
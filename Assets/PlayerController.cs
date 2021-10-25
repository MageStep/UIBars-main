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
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            Fire();
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
    }
}
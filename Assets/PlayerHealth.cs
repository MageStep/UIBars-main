using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{

    [SerializeField]
    private UIController ui;

    public int health = 100, mana = 100, xp = 0;

    // Start is called before the first frame update
    void Start()
    {
        ui.SetHealthSlider(health);
        ui.SetManaSlider(mana);
        ui.SetXPSlider(xp);
    }

    // Update is called once per frame
    void Update()
    {     
        ui.SetManaSlider(mana);
    }

    public void ChangeHealth(int byAmount)
    {
        health += byAmount;
        if(health <= 0)
        {
            SceneManager.LoadScene("gameOver");
        }

        if(health > 100)
        {
            health = 100;
        }
        ui.SetHealthSlider(health);
    }

    public void ChangeXP(int byAmount)
    {
        xp = byAmount;
        ui.SetXPSlider(xp);
    }

}
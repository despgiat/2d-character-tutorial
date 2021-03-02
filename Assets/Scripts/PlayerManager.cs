using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour //The game manager script will keep track of 
    //player attributes, like how much gold they have, how much health, stamina etc.
{
    public int coins;
    public int health;
    public float stamina;
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        coins = 0;
        health = 50;
        stamina = 20f;

        anim = GetComponent<Animator>();
        anim.SetBool("Alive", true);
    }

    void Update()
    {
        if(health <= 0)
        {
            anim.SetBool("Alive", false);
        }
       
    }

}

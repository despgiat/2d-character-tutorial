﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    public PlayerMovement player;
  //  public ParticleSystem dirt;

    // Start is called before the first frame update
    void Start()
    {
        player = gameObject.transform.parent.gameObject.GetComponent<PlayerMovement>(); //we fetch the PlayerMovement script from the player object
    //    dirt = GetComponent<ParticleSystem>();
    }

    private void OnCollisionEnter2D(Collision2D collision) //Executed for one frame upon collision
    {
        if (collision.collider.tag == "Ground")
        {
            player.grounded = true;
            player.anim.SetBool("Grounded", player.grounded);
      //      dirt.Play();
        }

        if (collision.collider.tag == "EnemyDamageArea")
        {
            player.grounded = true;
            player.anim.SetBool("Grounded", player.grounded);
            player.Jump();
        }

    }

    private void OnCollisionExit2D(Collision2D collision) //Executed for one frame when the two objects stop colliding
    {
        if(collision.collider.tag == "Ground" || collision.collider.tag == "EnemyDamageArea")
        {
            player.grounded = false;
            player.anim.SetBool("Grounded", player.grounded);
        //    dirt.Stop();
        }
    }

}

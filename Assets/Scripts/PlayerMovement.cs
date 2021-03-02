using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb2d; //Physics Component
    public bool grounded; //true if the player is on the ground and not mid-air
    public Animator anim; //The player's Animator Component
    public float moveHorizontal; //float that indicates the character's speed relative to the right direction
    public SpriteRenderer sprite;
    private PlayerManager manager;

    //side scroller characters only move horizontally and jump vertically

    public float speed = 20f;

    // Start is called before the first frame update. Declarations are being made here.
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>(); //We use GetComponent to access components and their properties from the same or other game objects
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        manager = GetComponent<PlayerManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Jump") && grounded && manager.health > 0)
        {
            Jump();
        }

        if(moveHorizontal < 0) //if moveHorizontal < 0, that means the character is moving to the left, so we need to update the character's sprite to "look" to the left
        {
            sprite.flipX = enabled;
        }
        else if (moveHorizontal > 0)
        {
            sprite.flipX = !enabled;
        }

    }

    void FixedUpdate() //It's called a fixed amount of times per second
    {
        if(manager.health > 0)
        {
            moveHorizontal = Input.GetAxis("Horizontal") * speed; //calculates the horizontal movement's speed when we press the horizontal arrow keys or "a" and "d"      
        
            rb2d.AddForce(new Vector2(moveHorizontal, 0f), ForceMode2D.Force); //"throws" the player object to the horizontal axis by the moveHorizontal speed

            anim.SetFloat("Speed", Mathf.Abs(moveHorizontal)); //Updates the Animator parameters that control which animation state the character is in
   
        }
    }

    public void Jump()
    {
        rb2d.AddForce(new Vector2(0f, speed/2), ForceMode2D.Impulse); //"throws" the player object upwards (vertical axis) with an instant force
    }
}

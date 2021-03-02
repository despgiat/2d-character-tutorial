using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public int health;
    public Animator anim;
    public float sightDistance; //The distance the enemy can see
    public bool canSeePlayer;
    public GameObject missile;
    public float attackCooldown;
    private float cooldown;
    public bool canAttack;
    private Collider2D col;

    // Start is called before the first frame update
    void Start()
    {
        health = 100;
        anim = GetComponent<Animator>();
        col = GetComponent<Collider2D>();
        anim.SetBool("Alive", true);
        sightDistance = 20f; //The length of the Raycast Ray
        canAttack = true;
        cooldown = attackCooldown;
    }

    // Update is called once per frame
    void Update()
    {
        float cooldown = attackCooldown;

        if (health <= 0)
        {
            Debug.Log("Enemy Dead");
            anim.SetBool("Alive", false);
            canAttack = false;

            col.enabled = false;
            Collider2D[] children = GetComponentsInChildren<Collider2D>();
            foreach(Collider2D coll in children)
            {
                coll.enabled = false;
            }


        }

    }

    void FixedUpdate()
    {
        if(health > 0)
        {
            //Calculating enemy line of sight if the enemy is alive
            Vector3 offset = new Vector3(1f, 0f, 0f);
            int layerMask = LayerMask.GetMask("Default");
            RaycastHit2D hit2D = Physics2D.Raycast(transform.position + offset, Vector2.right, sightDistance, layerMask, 0);


            //If the collider of the object hit is not NUll
            if (hit2D.collider != null)
            {
                Debug.Log("Hitting: " + hit2D.collider.tag);
                if (hit2D.collider.tag == "Player")
                {
                    Debug.Log("I see you player and now I'm mad!");

                    if (canAttack)
                    {
                        Attack();
                        canAttack = false;
                    }
                    else
                    {
                        cooldown -= Time.deltaTime;
                        if (cooldown <= 0)
                        {
                            cooldown = attackCooldown;
                            canAttack = true;
                        }
                    }


                }
            }

            //Method to draw the ray in scene for debug purpose
            Debug.DrawRay(transform.position, Vector2.right * sightDistance, Color.red);
        }

        
    }

    private void Attack()
    {
        GameObject bullet = Instantiate(missile, transform.position, transform.rotation) as GameObject;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //Lets us use the SceneManager in order to load scenes

public class DeathZone : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            SceneManager.LoadScene("SampleScene"); //Loads the scene with that particular name - could be any scene
        }

        Destroy(collision.gameObject);
        
    }
}

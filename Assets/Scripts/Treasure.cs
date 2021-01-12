using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //We add this so we can have access to the Text component to display the message above the treasure

public class Treasure : MonoBehaviour
{
    public Text text;
    private PlayerManager manager;
    public bool treasureTaken;
    public bool inArea;

    private void Start()
    {
        text = GameObject.Find("TreasureText").GetComponent<Text>();
        text.enabled = false; //The text should not be enabled at the start of the game
        manager = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerManager>(); //We access the PlayerManager script from the "Player" object
        treasureTaken = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player") //When the "Player" enter the trigger area, the text is displayed (enabled)
        {
            inArea = true;
            if(!treasureTaken)
            {
                text.enabled = true;
                text.text = "Press E to get the treasure!";
            }
            
        }

        

    }
    private void OnTriggerExit2D(Collider2D collision) //When the "Player" exits the trigger area, the text disabled
    {
        if (collision.tag == "Player")
        {
            text.enabled = false;
        }
        inArea = false;
    }

    private void Update()
    {
        if(inArea)
        {
            if(Input.GetKeyDown(KeyCode.E))
            {
                if(!treasureTaken)
                {
                    treasureTaken = true;
                    text.enabled = false; //When we actually get the treasure by pressing the E key, we want the text to disappear
                    manager.coins += 10;
                }
            
            }
        }
        
    }
}

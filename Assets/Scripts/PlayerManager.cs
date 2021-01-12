using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour //The game manager script will keep track of 
    //player attributes, like how much gold they have, how much health, stamina etc.
{
    public int coins;

    // Start is called before the first frame update
    void Start()
    {
        coins = 0;
    }

}

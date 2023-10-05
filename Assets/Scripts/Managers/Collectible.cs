using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Collectible : MonoBehaviour
{
int score;
    private void OnCollisionEnter(Collision collision)
    {
        //if touching player object destroy self and call coinCounter
        if(collision.gameObject.tag == "Player")
        {
        //coinCounter();
        score += 1;
        Debug.Log("Score:"+score);
        Destroy(gameObject);
        }
    }
}

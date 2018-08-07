using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour

{
    private AudioSource collectCoinSound;

    private void Start()
    {
        collectCoinSound = this.GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Block")
        {
            ShapeMovement shapeMove = collision.gameObject.GetComponent<ShapeMovement>();
            if (shapeMove.canBeControlled == false)
            {
                collectCoinSound.Play();
                CollectCoin();
                if (GameData.canCollectCoin == true) //for tutorial
                {
                    GameData.firstCoin = true;
                }
            }
        }
         
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Block")
        {
            ShapeMovement shapeMove = other.gameObject.GetComponent<ShapeMovement>();
            if (shapeMove.canBeControlled == false)
            {
                collectCoinSound.Play();
                CollectCoin();
            }


        }
    }

    void CollectCoin()
    {
        GameObject.Destroy(this.gameObject);
        if(GameData.currentTeamNumber == 1){
            GameData.team1coins++;
        } 
        else if (GameData.currentTeamNumber == 2)
        {
            GameData.team2coins++;
        }
    }

    #region debugCheckFunctions

    #endregion
}

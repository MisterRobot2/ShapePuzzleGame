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
    }

    #region debugCheckFunctions

    #endregion
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Block")
        {
            ShapeMovement shapeMove = collision.gameObject.GetComponent<ShapeMovement>();
            if (shapeMove.canBeControlled == false)
            {
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

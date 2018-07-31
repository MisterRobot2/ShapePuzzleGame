using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

public class SlidePlatform : MonoBehaviour
{
    [SerializeField]
    private float timeTilNoFreeze;
    private bool canFreezeBlocks = true;

    private void Start()
    {
        StartCoroutine(MakePlatformInactive());
    }

    //Blocks freeze when collided 
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Block" && canFreezeBlocks == true)
        {
            ShapeMovement shapeMovementScript = other.gameObject.GetComponent<ShapeMovement>();

            shapeMovementScript.rb.constraints = RigidbodyConstraints2D.FreezeAll;
            shapeMovementScript.isFrozen = true;
        }
    }

    //makes the platform not able to freeze blocks 
    IEnumerator MakePlatformInactive()
    {
        yield return new WaitForSeconds(timeTilNoFreeze);
        canFreezeBlocks = false;
    }
}

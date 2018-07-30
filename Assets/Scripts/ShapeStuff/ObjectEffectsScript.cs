using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectEffectsScript : MonoBehaviour {

    public bool doOnCollisionEnter;
    [Tooltip("Should the object play a particle when hitting a block?")]
    public bool doPlayParticle;
    [Tooltip("Sprites to change to when colliding")]
    public Sprite[] sprites;
    [Tooltip("Animator you want to play animation from")]
    public Animator animator;
    [Tooltip("Names of triggers you want to play in order")]
    public string[] AnimationTriggerNames;
    
    [Tooltip("Delay for particle to enable/disable")]
    public int timeToBeEnabled;
    [Tooltip("Higher Means more rare")]
    public int rarityOfChangingAnimation;
    [Tooltip("Higher Means more rare")]
    public int rarityOfChangingSprite;

    public GameObject objectToBeActivated;

    private int currentAnimationNumber = 0;
    private int currentSpriteNumber = 0;

    IEnumerator timer()
    {
        if(doPlayParticle)
        {
            objectToBeActivated.GetComponent<ParticleSystem>().Play();
        }else
        {
            objectToBeActivated.SetActive(true);
        }
            
        yield return new WaitForSeconds(timeToBeEnabled);
        if (doPlayParticle)
        {
            objectToBeActivated.GetComponent<ParticleSystem>().Stop();
        }else
        {
            objectToBeActivated.SetActive(false);
        }
            
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Block")
        {
            //if you want the block to swap sprites when hitting a block
            if (sprites.Length != 0)
            {
                if (currentAnimationNumber >= AnimationTriggerNames.Length)
                {
                    return;
                }
                else
                {
                    if (Random.Range(0, rarityOfChangingSprite) == 0)
                    {
                        this.gameObject.GetComponent<SpriteRenderer>().sprite = sprites[currentSpriteNumber];
                        currentSpriteNumber++;
                    }
                }
            }
            //if you want the block to play animations when hitting a block
            if (AnimationTriggerNames.Length != 0)
            { 
                if (currentAnimationNumber >= AnimationTriggerNames.Length)
                {
                    return;
                } else
                {
                    if(Random.Range(0,rarityOfChangingAnimation) == 0)
                    {
                        animator.SetBool(AnimationTriggerNames[currentAnimationNumber], true);
                        currentAnimationNumber++;
                    }
                }
            }

            StartCoroutine(timer());
        }
           
    }

    // Use this for initialization
    void Start ()
    {
	    if(doPlayParticle)
        {
            objectToBeActivated.GetComponent<ParticleSystem>().Pause();
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

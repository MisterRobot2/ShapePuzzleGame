using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinGenerator : MonoBehaviour
{
    [SerializeField]
    private float coinSpawnXMin;
    [SerializeField]
    private float coinSpawnXMax;
    [SerializeField]
    private float coinSpawnTimeMin;
    [SerializeField]
    private float coinSpawnTimeMax;
    [SerializeField]
    private float speed;
    [SerializeField]
    private float heightOffset;
   
    [SerializeField]
    private GameObject coin;
    private GameObject goalLine;

    private bool isMakeingCoins;

    // Update is called once per frame
    void Update ()
    {
        TestToSpawnMore();
	}

    private void Start()
    {
        DebugCheck();
        StartCoroutine(SpawnCoins());
    }

    void TestToSpawnMore()
    {
        if (this.transform.position.y <= goalLine.transform.position.y + heightOffset)
        {
            if (isMakeingCoins == false)
            {
                StartCoroutine(SpawnCoins());
            }

            transform.Translate(Vector3.up * speed);
        }
        else
        {
            
        }
    }

    IEnumerator SpawnCoins()
    {
        isMakeingCoins = true;
        
        //makes coins
        Instantiate(coin,new Vector3(this.transform.position.x + Random.Range(coinSpawnXMin,coinSpawnXMax),this.transform.position.y,this.transform.position.z),Quaternion.identity);

        yield return new WaitForSeconds(Random.Range(coinSpawnTimeMin, coinSpawnTimeMax));
        isMakeingCoins = false;
    }

    #region debugCheckFunctions
    void DebugCheck()
    {
        goalLine = GameObject.Find("GoalLine");
     
        if (goalLine == null)
        {
            Debug.LogWarning(this.gameObject.name + " Cant find refrence Of: 'GoalLine' in scene, Please Make sure you name it correctly or change the name in the script.");
        }
    }
    #endregion
}

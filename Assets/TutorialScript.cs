using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialScript : MonoBehaviour {

    public GameObject MovementText;
    public GameObject GoalLineText;
    public GameObject NextShapeText;
    public GameObject SkipText;
    public GameObject SkipsLeftText;
    public GameObject CoinsText;
    public GameObject SlowDownText;
    public GameObject ReadyText;

    public GameObject backToMainMenuButton;

    private bool step1 = false;
    private bool step2 = false;
    private bool step3 = false;
    private bool step4 = false;
    void Start () {
        DataBase.selectedMode = GameMode.SinglePlayer;

        DataBase.isTutorial = true;
        DataBase.firstDrop = false;
        DataBase.firstGoalLine = false;
        DataBase.firstSkip = false;
        DataBase.canCollectCoin = false;
        DataBase.firstCoin = false;
        DataBase.firstSlowDown = false;

        MovementText.SetActive(true);
    }
	
	void Update () {
		if(DataBase.firstDrop == true)
        {
            if (step1 == false)
            {
                MovementText.SetActive(false);
                GoalLineText.SetActive(true);
                step1 = true;
            }
            
            if(DataBase.firstGoalLine == true)
            {
                if (step2 == false)
                {
                    GoalLineText.SetActive(false);
                    StartCoroutine(NextShapeAndSkip());
                    step2 = true;
                }

                if(DataBase.firstSkip == true)
                {
                    if(step3 == false)
                    {
                        SkipText.SetActive(false);
                        StartCoroutine(SkipsLeftAndCoins());
                        step3 = true;
                    }
                    if(DataBase.firstCoin == true)
                    {
                        if (step4 == false)
                        {
                            CoinsText.SetActive(false);
                            SlowDownText.SetActive(true);
                            step4 = true;
                        }

                        if (DataBase.firstSlowDown == true)
                        {
                            SlowDownText.SetActive(false);
                            ReadyText.SetActive(true);
                            backToMainMenuButton.SetActive(true);
                        }
                    }
                }
            }
        }
	}

    IEnumerator NextShapeAndSkip()
    {
        NextShapeText.SetActive(true);
        yield return new WaitForSeconds(5);
        NextShapeText.SetActive(false);

        SkipText.SetActive(true);
    }

    IEnumerator SkipsLeftAndCoins()
    {
        SkipsLeftText.SetActive(true);
        yield return new WaitForSeconds(5);
        SkipsLeftText.SetActive(false);

        CoinsText.SetActive(true);
        DataBase.canCollectCoin = true;
    }
}

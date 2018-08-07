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
        GameData.selectedMode = GameMode.SinglePlayer;

        GameData.isTutorial = true;
        GameData.firstDrop = false;
        GameData.firstGoalLine = false;
        GameData.firstSkip = false;
        GameData.firstSlowDown = false;

        MovementText.SetActive(true);
    }
	
	void Update () {
		if(GameData.firstDrop == true)
        {
            if (step1 == false)
            {
                MovementText.SetActive(false);
                GoalLineText.SetActive(true);
                step1 = true;
            }

            if (GameData.firstGoalLine == true)
            {
                if (step2 == false)
                {
                    GoalLineText.SetActive(false);
                    StartCoroutine(NextShapeAndSkip());
                    step2 = true;
                }
            }

            if (GameData.firstSkip == true)
            {
                if (step3 == false)
                {
                    SkipText.SetActive(false);
                    StartCoroutine(SkipsLeftAndCoins());
                    step3 = true;
                }
            }
            if (GameData.firstCoin == true)
            {
                if (step4 == false)
                {
                    CoinsText.SetActive(false);
                    SlowDownText.SetActive(true);
                    step4 = true;
                }
            }

            if(GameData.firstSlowDown == true)
            {
                SlowDownText.SetActive(false);
                ReadyText.SetActive(true);
                backToMainMenuButton.SetActive(true);
                GameData.isTutorial = false;
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
        GameData.canCollectCoin = true;
    }
}

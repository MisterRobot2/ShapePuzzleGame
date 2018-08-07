using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialScript : MonoBehaviour {

    public GameObject MovementText;
    public GameObject GoalLineText;
    public GameObject NextShapeText;
    public GameObject SkipText;
    public GameObject SlowDownText;
    public GameObject ReadyText;

    public GameObject GoalLineArrow;
    public GameObject NextShapeArrow;
    public GameObject SkipArrow;

    public GameObject backToMainMenuButton;

    private bool step1 = false;
    private bool step2 = false;
    private bool step3 = false;

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
                GoalLineArrow.SetActive(true);
                step1 = true;
            }

            if(GameData.firstGoalLine == true)
            {
                if (step2 == false)
                {
                    GoalLineText.SetActive(false);
                    GoalLineArrow.SetActive(false);
                    StartCoroutine(ShowMessage());
                    step2 = true;
                }

                if(GameData.firstSkip == true)
                {
                    if(step3 == false)
                    {
                        SkipText.SetActive(false);
                        SkipArrow.SetActive(false);
                        SlowDownText.SetActive(true);
                        step3 = true;
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
        }
	}

    IEnumerator ShowMessage()
    {
        NextShapeText.SetActive(true);
        NextShapeArrow.SetActive(true);
        yield return new WaitForSeconds(5);
        NextShapeText.SetActive(false);
        NextShapeArrow.SetActive(false);

        SkipText.SetActive(true);
        SkipArrow.SetActive(true);
    }
}

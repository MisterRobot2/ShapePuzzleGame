using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScript : MonoBehaviour {

    private Color currentColor;
    private float duration = 5;
    private float progress = 0;

    public GameObject starsGameObject;
    ParticleSystem stars;

    public GameObject cloudsGameObject;
    ParticleSystem clouds;

    public GameObject heightText;
    public GameObject goalLineText;
    public GameObject cameraGoalLineText;

    void Start()
    {
        gameObject.GetComponent<Renderer>().material.color = new Color32(0, 252, 255, 255);
        currentColor = gameObject.GetComponent<Renderer>().material.color = new Color32(0, 252, 255, 255);
        stars = starsGameObject.GetComponent<ParticleSystem>();
        clouds = cloudsGameObject.GetComponent<ParticleSystem>();
    }
	
	void Update () {

        if (GameData.currentHeight >= 40)
        {
            gameObject.GetComponent<Renderer>().material.color = Color.Lerp(currentColor, Color.black, progress);
            clouds.Stop();
            cloudsGameObject.SetActive(false);

            if (progress < 1)
            {
                progress += Time.deltaTime / duration;
            }
            else if(progress >= 1)
            {
                starsGameObject.SetActive(true);
                stars.Play();

                heightText.GetComponent<TextMesh>().color = Color.white;
                goalLineText.GetComponent<TextMesh>().color = Color.white;
                cameraGoalLineText.GetComponent<TextMesh>().color = Color.white;
            }
        }
        else if(GameData.currentHeight < 40)
        {
            stars.Stop();
            starsGameObject.SetActive(false);
        }
}
    }

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Store : MonoBehaviour {

    private Button iceBlockBtn;
    private Button phoneBtn;
    private Button waterGunBtn;
 
    private Toggle iceBlockToggle;
    private Toggle phoneToggle;
    private Toggle waterGunToggle;

    private Text totalCoinsText;


	// Use this for initialization
	void Start () {

        iceBlockBtn = GameObject.Find("Buy Button (Ice Block)").gameObject.GetComponent<Button>();
        phoneBtn = GameObject.Find("Buy Button (Phone)").gameObject.GetComponent<Button>();
        waterGunBtn = GameObject.Find("Buy Button (Water Gun)").gameObject.GetComponent<Button>();

        iceBlockToggle = GameObject.Find("Include Toggle (Ice Block)").gameObject.GetComponent<Toggle>();
        phoneToggle = GameObject.Find("Include Toggle (Phone)").gameObject.GetComponent<Toggle>();
        waterGunToggle = GameObject.Find("Include Toggle (Water Gun)").gameObject.GetComponent<Toggle>();

        totalCoinsText = GameObject.Find("Total Coins Text").gameObject.GetComponent<Text>();


        //set up
        iceBlockBtn.gameObject.SetActive(true);
        phoneBtn.gameObject.SetActive(true);
        waterGunBtn.gameObject.SetActive(true);

        iceBlockToggle.enabled = false;
        phoneToggle.enabled = false;
        waterGunToggle.enabled = false;

        totalCoinsText.text = DataBase.totalCoins.ToString();

	}
	
	// Update is called once per frame
	void Update () {
		
	}


    public void iceBlockBtnClick(){
        iceBlockBtn.gameObject.GetComponentInChildren<Text>().text = "Purchased";
        iceBlockBtn.transform.Find("Image").GetComponent<Image>().enabled = false;
        iceBlockBtn.GetComponent<Image>().enabled = false;
        iceBlockToggle.enabled = true;
        iceBlockToggle.isOn = true;

        DataBase.totalCoins -= 10;
        totalCoinsText.text = DataBase.totalCoins.ToString();
    }

    public void phoneBtnClick()
    {
        phoneBtn.gameObject.GetComponentInChildren<Text>().text = "Purchased";
        phoneBtn.transform.Find("Image").GetComponent<Image>().enabled = false;
        phoneBtn.GetComponent<Image>().enabled = false;
        phoneToggle.enabled = true;
        phoneToggle.isOn = true;

        DataBase.totalCoins -= 10;
        totalCoinsText.text = DataBase.totalCoins.ToString();
    }

    public void waterGunBtnClick()
    {
        waterGunBtn.gameObject.GetComponentInChildren<Text>().text = "Purchased";
        waterGunBtn.transform.Find("Image").GetComponent<Image>().enabled = false;
        waterGunBtn.GetComponent<Image>().enabled = false;
        waterGunToggle.enabled = true;
        waterGunToggle.isOn = true;

        DataBase.totalCoins -= 10;
        totalCoinsText.text = DataBase.totalCoins.ToString();
    }




}

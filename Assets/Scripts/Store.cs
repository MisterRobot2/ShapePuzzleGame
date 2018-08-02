using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class Store : MonoBehaviour {

    private Button iceBlockBtn;
    private Button phoneBtn;
    private Button waterGunBtn;
    private Button orbBtn;
    private Button tableBtn;
 
    private Toggle iceBlockToggle;
    private Toggle phoneToggle;
    private Toggle waterGunToggle;
    private Toggle orbToggle;
    private Toggle tableToggle;


    private Text totalCoinsText;


	// Use this for initialization
	void Start () {

        iceBlockBtn = GameObject.Find("Buy Button (Ice Block)").gameObject.GetComponent<Button>();
        phoneBtn = GameObject.Find("Buy Button (Phone)").gameObject.GetComponent<Button>();
        waterGunBtn = GameObject.Find("Buy Button (Water Gun)").gameObject.GetComponent<Button>();
        orbBtn = GameObject.Find("Buy Button (Orb)").gameObject.GetComponent<Button>();
        tableBtn = GameObject.Find("Buy Button (Table)").gameObject.GetComponent<Button>();



        iceBlockToggle = GameObject.Find("Include Toggle (Ice Block)").gameObject.GetComponent<Toggle>();
        phoneToggle = GameObject.Find("Include Toggle (Phone)").gameObject.GetComponent<Toggle>();
        waterGunToggle = GameObject.Find("Include Toggle (Water Gun)").gameObject.GetComponent<Toggle>();
        orbToggle = GameObject.Find("Include Toggle (Orb)").gameObject.GetComponent<Toggle>();
        tableToggle = GameObject.Find("Include Toggle (Table)").gameObject.GetComponent<Toggle>();


        totalCoinsText = GameObject.Find("Total Coins Text").gameObject.GetComponent<Text>();


        //set up
        iceBlockBtn.enabled = false;
        phoneBtn.enabled = false;
        waterGunBtn.enabled = false;
        orbBtn.enabled = false;
        tableBtn.enabled = false;

        iceBlockToggle.enabled = false;
        phoneToggle.enabled = false;
        waterGunToggle.enabled = false;
        orbToggle.enabled = false;
        tableToggle.enabled = false;


        totalCoinsText.text = DataBase.totalCoins.ToString();

	}
	
	// Update is called once per frame
	void Update () {
        if(DataBase.totalCoins >= 10){
            iceBlockBtn.enabled = true;
            phoneBtn.enabled = true;
            waterGunBtn.enabled = true;
            orbBtn.enabled = true;
            tableBtn.enabled = true;
        } else{
            iceBlockBtn.enabled = false;
            phoneBtn.enabled = false;
            waterGunBtn.enabled = false;
            orbBtn.enabled = false;
            tableBtn.enabled = false;
        }

        if(iceBlockToggle.isOn == true){
            DataBase.iceBlockToggleIsOn = true;
        } else{
            DataBase.iceBlockToggleIsOn = false;
        }

        if (phoneToggle.isOn == true)
        {
            DataBase.phoneToggleIsOn = true;
        }
        else
        {
            DataBase.phoneToggleIsOn = false;
        }

        if (waterGunToggle.isOn == true)
        {
            DataBase.waterGunToggleIsOn = true;
        }
        else
        {
            DataBase.waterGunToggleIsOn = false;
        }

        if (orbToggle.isOn == true)
        {
            DataBase.orbToggleIsOn = true;
        }
        else
        {
            DataBase.orbToggleIsOn = false;
        }

        if (tableToggle.isOn == true)
        {
            DataBase.tableToggleIsOn = true;
        }
        else
        {
            DataBase.tableToggleIsOn = false;
        }

	}


    public void updateCoins(){
        DataBase.totalCoins -= 10;
        totalCoinsText.text = DataBase.totalCoins.ToString();  
    }

    public void iceBlockBtnClick(){
        iceBlockBtn.gameObject.GetComponentInChildren<Text>().text = "Purchased";
        iceBlockBtn.transform.Find("Image").GetComponent<Image>().enabled = false;
        iceBlockBtn.GetComponent<Image>().enabled = false;
        iceBlockToggle.enabled = true;
        iceBlockToggle.isOn = true;

        updateCoins();
    }

    public void phoneBtnClick()
    {
        phoneBtn.gameObject.GetComponentInChildren<Text>().text = "Purchased";
        phoneBtn.transform.Find("Image").GetComponent<Image>().enabled = false;
        phoneBtn.GetComponent<Image>().enabled = false;
        phoneToggle.enabled = true;
        phoneToggle.isOn = true;

        updateCoins();
    }

    public void waterGunBtnClick()
    {
        waterGunBtn.gameObject.GetComponentInChildren<Text>().text = "Purchased";
        waterGunBtn.transform.Find("Image").GetComponent<Image>().enabled = false;
        waterGunBtn.GetComponent<Image>().enabled = false;
        waterGunToggle.enabled = true;
        waterGunToggle.isOn = true;

        updateCoins();
    }

    public void orbBtnClick()
    {
        orbBtn.gameObject.GetComponentInChildren<Text>().text = "Purchased";
        orbBtn.transform.Find("Image").GetComponent<Image>().enabled = false;
        orbBtn.GetComponent<Image>().enabled = false;
        orbToggle.enabled = true;
        orbToggle.isOn = true;

        updateCoins();
    }

    public void tableBtnClick()
    {
        tableBtn.gameObject.GetComponentInChildren<Text>().text = "Purchased";
        tableBtn.transform.Find("Image").GetComponent<Image>().enabled = false;
        tableBtn.GetComponent<Image>().enabled = false;
        tableToggle.enabled = true;
        tableToggle.isOn = true;

        updateCoins();
    }
}

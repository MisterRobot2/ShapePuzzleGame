using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public enum ItemType {Orb,Phone,Table,IceCube,Book,Bookshelf,WaterGun}

public class Store : MonoBehaviour {

    public ItemType item;
    public int cost;
    private Text totalCoinsText;


    void Start()
    {
        this.gameObject.transform.parent.transform.GetChild(4).GetComponent<Toggle>().isOn = false;
        this.gameObject.transform.parent.transform.GetChild(4).GetComponent<Toggle>().interactable = false;

        totalCoinsText = GameObject.Find("Total Coins Text").gameObject.GetComponent<Text>();
        totalCoinsText.text = DataBase.totalCoins.ToString();
        
        this.gameObject.transform.Find("Text").GetComponent<Text>().text = "<color=#af6f01>$"+cost+"</color>";
        this.gameObject.transform.parent.transform.GetChild(4).GetComponent<Toggle>().onValueChanged.AddListener(delegate { toggleChange(); });
        this.gameObject.GetComponent<Button>().onClick.AddListener(delegate { buttonClick(); });

        syncSettings();
    }

    private void syncSettings()
    {

        switch (item)
        {
            case ItemType.Phone:
                if (DataBase.phoneBought)
                {
                    this.gameObject.transform.Find("Text").GetComponent<Text>().text = "<color=#4b9b00>Purchased</color>";
                    this.gameObject.GetComponent<Image>().enabled = false;
                    this.gameObject.transform.Find("Image").GetComponent<Image>().enabled = false;
                    this.gameObject.transform.parent.transform.GetChild(4).GetComponent<Toggle>().interactable = true;
                    if (DataBase.phoneToggleIsOn)
                    {
                        this.gameObject.transform.parent.transform.GetChild(4).GetComponent<Toggle>().isOn = true;
                    }else
                    {
                        this.gameObject.transform.parent.transform.GetChild(4).GetComponent<Toggle>().isOn = false;
                    }
                }
                break;
            case ItemType.IceCube:
                if (DataBase.iceBlockBought)
                {
                    this.gameObject.transform.Find("Text").GetComponent<Text>().text = "<color=#4b9b00>Purchased</color>";
                    this.gameObject.GetComponent<Image>().enabled = false;
                    this.gameObject.transform.Find("Image").GetComponent<Image>().enabled = false;
                    this.gameObject.transform.parent.transform.GetChild(4).GetComponent<Toggle>().interactable = true;
                    if (DataBase.iceBlockToggleIsOn)
                    {
                        this.gameObject.transform.parent.transform.GetChild(4).GetComponent<Toggle>().isOn = true;
                    }else
                    {
                        this.gameObject.transform.parent.transform.GetChild(4).GetComponent<Toggle>().isOn = false;
                    }
                }
                break;
            case ItemType.Book:
                if (DataBase.bookBought)
                {
                    this.gameObject.transform.Find("Text").GetComponent<Text>().text = "<color=#4b9b00>Purchased</color>";
                    this.gameObject.GetComponent<Image>().enabled = false;
                    this.gameObject.transform.Find("Image").GetComponent<Image>().enabled = false;
                    this.gameObject.transform.parent.transform.GetChild(4).GetComponent<Toggle>().interactable = true;
                    if (DataBase.bookToggleIsOn)
                    {
                        this.gameObject.transform.parent.transform.GetChild(4).GetComponent<Toggle>().isOn = true;
                    }else
                    {
                        this.gameObject.transform.parent.transform.GetChild(4).GetComponent<Toggle>().isOn = false;
                    }
                }
                break;
            case ItemType.Bookshelf:
                if (DataBase.bookShelfBought)
                {
                    this.gameObject.transform.Find("Text").GetComponent<Text>().text = "<color=#4b9b00>Purchased</color>";
                    this.gameObject.GetComponent<Image>().enabled = false;
                    this.gameObject.transform.Find("Image").GetComponent<Image>().enabled = false;
                    this.gameObject.transform.parent.transform.GetChild(4).GetComponent<Toggle>().interactable = true;
                    if (DataBase.bookShelfToggleIsOn)
                    {
                        this.gameObject.transform.parent.transform.GetChild(4).GetComponent<Toggle>().isOn = true;
                    }else
                    {
                        this.gameObject.transform.parent.transform.GetChild(4).GetComponent<Toggle>().isOn = false;
                    }
                }

                break;
            case ItemType.WaterGun:
                if (DataBase.waterGunBought)
                {
                    this.gameObject.transform.Find("Text").GetComponent<Text>().text = "<color=#4b9b00>Purchased</color>";
                    this.gameObject.GetComponent<Image>().enabled = false;
                    this.gameObject.transform.Find("Image").GetComponent<Image>().enabled = false;
                    this.gameObject.transform.parent.transform.GetChild(4).GetComponent<Toggle>().interactable = true;
                    if (DataBase.waterGunToggleIsOn)
                    {
                        this.gameObject.transform.parent.transform.GetChild(4).GetComponent<Toggle>().isOn = true;
                    }else
                    {
                        this.gameObject.transform.parent.transform.GetChild(4).GetComponent<Toggle>().isOn = false;
                    }
                }
                break;
            case ItemType.Orb:
                if (DataBase.orbBought)
                {
                    this.gameObject.transform.Find("Text").GetComponent<Text>().text = "<color=#4b9b00>Purchased</color>";
                    this.gameObject.GetComponent<Image>().enabled = false;
                    this.gameObject.transform.Find("Image").GetComponent<Image>().enabled = false;
                    this.gameObject.transform.parent.transform.GetChild(4).GetComponent<Toggle>().interactable = true;
                    if (DataBase.orbToggleIsOn)
                    {
                        this.gameObject.transform.parent.transform.GetChild(4).GetComponent<Toggle>().isOn = true;
                    }else
                    {
                        this.gameObject.transform.parent.transform.GetChild(4).GetComponent<Toggle>().isOn = false;
                    }
                }
                break;
            case ItemType.Table:
                if (DataBase.tableBought)
                {
                    this.gameObject.transform.Find("Text").GetComponent<Text>().text = "<color=#4b9b00>Purchased</color>";
                    this.gameObject.GetComponent<Image>().enabled = false;
                    this.gameObject.transform.Find("Image").GetComponent<Image>().enabled = false;
                    this.gameObject.transform.parent.transform.GetChild(4).GetComponent<Toggle>().interactable = true;
                    if (DataBase.tableToggleIsOn)
                    {
                        this.gameObject.transform.parent.transform.GetChild(4).GetComponent<Toggle>().isOn = true;
                    }else
                    {
                        this.gameObject.transform.parent.transform.GetChild(4).GetComponent<Toggle>().isOn = false;
                    }
                }
                break;

            default:
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (DataBase.totalCoins >= cost)
        {
            this.gameObject.GetComponent<Button>().enabled = true;
        }
        else
        {
            this.gameObject.GetComponent<Button>().enabled = false;
        }
    }

    public void buttonClick()
    {
        switch (item)
        {
            case ItemType.Phone:
                DataBase.phoneBought = true;
                buyItem();
                DataBase.phoneToggleIsOn = true;
                break;
            case ItemType.IceCube:
                DataBase.iceBlockBought = true;
                buyItem();
                DataBase.iceBlockToggleIsOn = true;
                break;
            case ItemType.Book:
                DataBase.bookBought = true;
                buyItem();
                DataBase.bookToggleIsOn = true;
                break;
            case ItemType.Bookshelf:
                DataBase.bookShelfBought = true;
                buyItem();
                DataBase.bookShelfToggleIsOn = true;

                break;
            case ItemType.WaterGun:
                DataBase.waterGunBought = true;
                buyItem();
                DataBase.waterGunToggleIsOn = true;
                break;
            case ItemType.Orb:
                DataBase.orbBought = true;
                buyItem();
                DataBase.orbToggleIsOn = true;
                break;
            case ItemType.Table:
                DataBase.tableBought = true;
                buyItem();
                DataBase.tableToggleIsOn = true;
                break;

            default:
                break;
        }
    }

    public void updateCoins(){
        DataBase.totalCoins -= cost;
        totalCoinsText.text = DataBase.totalCoins.ToString();  
    }

    void toggleChange()
    {
        switch (item)
        {
            case ItemType.Phone:
                if(gameObject.transform.parent.transform.GetChild(4).GetComponent<Toggle>().isOn)
                {
                    DataBase.phoneToggleIsOn = true;
                }else
                {
                    DataBase.phoneToggleIsOn = false;
                }
                
                break;
            case ItemType.IceCube:
                if (gameObject.transform.parent.transform.GetChild(4).GetComponent<Toggle>().isOn)
                {
                    DataBase.iceBlockToggleIsOn = true;
                }
                else
                {
                    DataBase.iceBlockToggleIsOn = false;
                }
                break;
            case ItemType.Book:
                if (gameObject.transform.parent.transform.GetChild(4).GetComponent<Toggle>().isOn)
                {
                    DataBase.bookToggleIsOn = true;
                }
                else
                {
                    DataBase.bookToggleIsOn = false;
                }
                break;
            case ItemType.Bookshelf:
                if (gameObject.transform.parent.transform.GetChild(4).GetComponent<Toggle>().isOn)
                {
                    DataBase.bookShelfToggleIsOn = true;
                }
                else
                {
                    DataBase.bookShelfToggleIsOn = false;
                }

                break;
            case ItemType.WaterGun:
                if (gameObject.transform.parent.transform.GetChild(4).GetComponent<Toggle>().isOn)
                {
                    DataBase.waterGunToggleIsOn = true;
                }
                else
                {
                    DataBase.waterGunToggleIsOn = false;
                }
                break;
            case ItemType.Orb:
                if (gameObject.transform.parent.transform.GetChild(4).GetComponent<Toggle>().isOn)
                {
                    DataBase.orbToggleIsOn = true;
                }
                else
                {
                    DataBase.orbToggleIsOn = false;
                }
                break;
            case ItemType.Table:
                if (gameObject.transform.parent.transform.GetChild(4).GetComponent<Toggle>().isOn)
                {
                    DataBase.tableToggleIsOn = true;
                }
                else
                {
                    DataBase.tableToggleIsOn = false;
                }
                break;

            default:
                break;
        }
    }

   void buyItem()
    {
        this.gameObject.transform.Find("Text").GetComponentInChildren<Text>().text = "<color=#4b9b00>Purchased</color>";
        this.gameObject.GetComponent<Image>().enabled = false;
        this.gameObject.transform.Find("Image").GetComponent<Image>().enabled = false;
        this.gameObject.transform.parent.transform.GetChild(4).GetComponent<Toggle>().interactable = true;
        this.gameObject.transform.parent.transform.GetChild(4).GetComponent<Toggle>().isOn = true;
        updateCoins();
    }
}

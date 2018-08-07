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
        totalCoinsText.text = CurrentData.gameData.totalCoins.ToString();
        
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
                if (CurrentData.gameData.phoneBought)
                {
                    this.gameObject.transform.Find("Text").GetComponent<Text>().text = "<color=#4b9b00>Purchased</color>";
                    this.gameObject.GetComponent<Image>().enabled = false;
                    this.gameObject.transform.Find("Image").GetComponent<Image>().enabled = false;
                    this.gameObject.transform.parent.transform.GetChild(4).GetComponent<Toggle>().interactable = true;
                    if (CurrentData.gameData.phoneToggleIsOn)
                    {
                        this.gameObject.transform.parent.transform.GetChild(4).GetComponent<Toggle>().isOn = true;
                    }else
                    {
                        this.gameObject.transform.parent.transform.GetChild(4).GetComponent<Toggle>().isOn = false;
                    }
                }
                break;
            case ItemType.IceCube:
                if (CurrentData.gameData.iceBlockBought)
                {
                    this.gameObject.transform.Find("Text").GetComponent<Text>().text = "<color=#4b9b00>Purchased</color>";
                    this.gameObject.GetComponent<Image>().enabled = false;
                    this.gameObject.transform.Find("Image").GetComponent<Image>().enabled = false;
                    this.gameObject.transform.parent.transform.GetChild(4).GetComponent<Toggle>().interactable = true;
                    if (CurrentData.gameData.iceBlockToggleIsOn)
                    {
                        this.gameObject.transform.parent.transform.GetChild(4).GetComponent<Toggle>().isOn = true;
                    }else
                    {
                        this.gameObject.transform.parent.transform.GetChild(4).GetComponent<Toggle>().isOn = false;
                    }
                }
                break;
            case ItemType.Book:
                if (CurrentData.gameData.bookBought)
                {
                    this.gameObject.transform.Find("Text").GetComponent<Text>().text = "<color=#4b9b00>Purchased</color>";
                    this.gameObject.GetComponent<Image>().enabled = false;
                    this.gameObject.transform.Find("Image").GetComponent<Image>().enabled = false;
                    this.gameObject.transform.parent.transform.GetChild(4).GetComponent<Toggle>().interactable = true;
                    if (CurrentData.gameData.bookToggleIsOn)
                    {
                        this.gameObject.transform.parent.transform.GetChild(4).GetComponent<Toggle>().isOn = true;
                    }else
                    {
                        this.gameObject.transform.parent.transform.GetChild(4).GetComponent<Toggle>().isOn = false;
                    }
                }
                break;
            case ItemType.Bookshelf:
                if (CurrentData.gameData.bookShelfBought)
                {
                    this.gameObject.transform.Find("Text").GetComponent<Text>().text = "<color=#4b9b00>Purchased</color>";
                    this.gameObject.GetComponent<Image>().enabled = false;
                    this.gameObject.transform.Find("Image").GetComponent<Image>().enabled = false;
                    this.gameObject.transform.parent.transform.GetChild(4).GetComponent<Toggle>().interactable = true;
                    if (CurrentData.gameData.bookShelfToggleIsOn)
                    {
                        this.gameObject.transform.parent.transform.GetChild(4).GetComponent<Toggle>().isOn = true;
                    }else
                    {
                        this.gameObject.transform.parent.transform.GetChild(4).GetComponent<Toggle>().isOn = false;
                    }
                }

                break;
            case ItemType.WaterGun:
                if (CurrentData.gameData.waterGunBought)
                {
                    this.gameObject.transform.Find("Text").GetComponent<Text>().text = "<color=#4b9b00>Purchased</color>";
                    this.gameObject.GetComponent<Image>().enabled = false;
                    this.gameObject.transform.Find("Image").GetComponent<Image>().enabled = false;
                    this.gameObject.transform.parent.transform.GetChild(4).GetComponent<Toggle>().interactable = true;
                    if (CurrentData.gameData.waterGunToggleIsOn)
                    {
                        this.gameObject.transform.parent.transform.GetChild(4).GetComponent<Toggle>().isOn = true;
                    }else
                    {
                        this.gameObject.transform.parent.transform.GetChild(4).GetComponent<Toggle>().isOn = false;
                    }
                }
                break;
            case ItemType.Orb:
                if (CurrentData.gameData.orbBought)
                {
                    this.gameObject.transform.Find("Text").GetComponent<Text>().text = "<color=#4b9b00>Purchased</color>";
                    this.gameObject.GetComponent<Image>().enabled = false;
                    this.gameObject.transform.Find("Image").GetComponent<Image>().enabled = false;
                    this.gameObject.transform.parent.transform.GetChild(4).GetComponent<Toggle>().interactable = true;
                    if (CurrentData.gameData.orbToggleIsOn)
                    {
                        this.gameObject.transform.parent.transform.GetChild(4).GetComponent<Toggle>().isOn = true;
                    }else
                    {
                        this.gameObject.transform.parent.transform.GetChild(4).GetComponent<Toggle>().isOn = false;
                    }
                }
                break;
            case ItemType.Table:
                if (CurrentData.gameData.tableBought)
                {
                    this.gameObject.transform.Find("Text").GetComponent<Text>().text = "<color=#4b9b00>Purchased</color>";
                    this.gameObject.GetComponent<Image>().enabled = false;
                    this.gameObject.transform.Find("Image").GetComponent<Image>().enabled = false;
                    this.gameObject.transform.parent.transform.GetChild(4).GetComponent<Toggle>().interactable = true;
                    if (CurrentData.gameData.tableToggleIsOn)
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
        if (CurrentData.gameData.totalCoins >= cost)
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
                CurrentData.gameData.phoneBought = true;
                buyItem();
                CurrentData.gameData.phoneToggleIsOn = true;
                break;
            case ItemType.IceCube:
                CurrentData.gameData.iceBlockBought = true;
                buyItem();
                CurrentData.gameData.iceBlockToggleIsOn = true;
                break;
            case ItemType.Book:
                CurrentData.gameData.bookBought = true;
                buyItem();
                CurrentData.gameData.bookToggleIsOn = true;
                break;
            case ItemType.Bookshelf:
                CurrentData.gameData.bookShelfBought = true;
                buyItem();
                CurrentData.gameData.bookShelfToggleIsOn = true;

                break;
            case ItemType.WaterGun:
                CurrentData.gameData.waterGunBought = true;
                buyItem();
                CurrentData.gameData.waterGunToggleIsOn = true;
                break;
            case ItemType.Orb:
                CurrentData.gameData.orbBought = true;
                buyItem();
                CurrentData.gameData.orbToggleIsOn = true;
                break;
            case ItemType.Table:
                CurrentData.gameData.tableBought = true;
                buyItem();
                CurrentData.gameData.tableToggleIsOn = true;
                break;

            default:
                break;
        }
    }

    public void updateCoins(){
        CurrentData.gameData.totalCoins -= cost;
        totalCoinsText.text = CurrentData.gameData.totalCoins.ToString();  
    }

    void toggleChange()
    {
        switch (item)
        {
            case ItemType.Phone:
                if(gameObject.transform.parent.transform.GetChild(4).GetComponent<Toggle>().isOn)
                {
                    CurrentData.gameData.phoneToggleIsOn = true;
                }else
                {
                    CurrentData.gameData.phoneToggleIsOn = false;
                }
                
                break;
            case ItemType.IceCube:
                if (gameObject.transform.parent.transform.GetChild(4).GetComponent<Toggle>().isOn)
                {
                    CurrentData.gameData.iceBlockToggleIsOn = true;
                }
                else
                {
                    CurrentData.gameData.iceBlockToggleIsOn = false;
                }
                break;
            case ItemType.Book:
                if (gameObject.transform.parent.transform.GetChild(4).GetComponent<Toggle>().isOn)
                {
                    CurrentData.gameData.bookToggleIsOn = true;
                }
                else
                {
                    CurrentData.gameData.bookToggleIsOn = false;
                }
                break;
            case ItemType.Bookshelf:
                if (gameObject.transform.parent.transform.GetChild(4).GetComponent<Toggle>().isOn)
                {
                    CurrentData.gameData.bookShelfToggleIsOn = true;
                }
                else
                {
                    CurrentData.gameData.bookShelfToggleIsOn = false;
                }

                break;
            case ItemType.WaterGun:
                if (gameObject.transform.parent.transform.GetChild(4).GetComponent<Toggle>().isOn)
                {
                    CurrentData.gameData.waterGunToggleIsOn = true;
                }
                else
                {
                    CurrentData.gameData.waterGunToggleIsOn = false;
                }
                break;
            case ItemType.Orb:
                if (gameObject.transform.parent.transform.GetChild(4).GetComponent<Toggle>().isOn)
                {
                    CurrentData.gameData.orbToggleIsOn = true;
                }
                else
                {
                    CurrentData.gameData.orbToggleIsOn = false;
                }
                break;
            case ItemType.Table:
                if (gameObject.transform.parent.transform.GetChild(4).GetComponent<Toggle>().isOn)
                {
                    CurrentData.gameData.tableToggleIsOn = true;
                }
                else
                {
                    CurrentData.gameData.tableToggleIsOn = false;
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

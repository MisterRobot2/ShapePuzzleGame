using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum ItemType {Orb,Phone,Table,IceCube,Book,Bookshelf,WaterGun}

public class Store : MonoBehaviour {

    public ItemType item;
    public int cost;
    private Text totalCoinsText;

    void Start()
    {
        totalCoinsText = GameObject.Find("Total Coins Text").gameObject.GetComponent<Text>();
        totalCoinsText.text = DataBase.totalCoins.ToString();
        
        this.gameObject.transform.Find("Text").GetComponent<Text>().text = "<color=#af6f01>$"+cost+"</color>";
        this.gameObject.transform.parent.transform.GetChild(4).GetComponent<Toggle>().onValueChanged.AddListener(delegate { toggleChange(); });
        this.gameObject.GetComponent<Button>().onClick.AddListener(delegate { buttonClick(); });
    }

    private void Awake()
    {
        this.gameObject.transform.parent.transform.GetChild(4).GetComponent<Toggle>().isOn = false;
        this.gameObject.transform.parent.transform.GetChild(4).GetComponent<Toggle>().interactable = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (DataBase.totalCoins >= 10)
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
                buyItem();
                DataBase.phoneToggleIsOn = true;
                break;
            case ItemType.IceCube:
                buyItem();
                DataBase.iceBlockToggleIsOn = true;
                break;
            case ItemType.Book:
                buyItem();
                DataBase.bookToggleIsOn = true;
                break;
            case ItemType.Bookshelf:
                buyItem();
                DataBase.bookShelfToggleIsOn = true;

                break;
            case ItemType.WaterGun:
                buyItem();
                DataBase.waterGunToggleIsOn = true;
                break;
            case ItemType.Orb:
                buyItem();
                DataBase.orbToggleIsOn = true;
                break;
            case ItemType.Table:
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
                    DataBase.phoneToggleIsOn = true;
                }
                else
                {
                    DataBase.phoneToggleIsOn = false;
                }
                break;
            case ItemType.Book:
                if (gameObject.transform.parent.transform.GetChild(4).GetComponent<Toggle>().isOn)
                {
                    DataBase.phoneToggleIsOn = true;
                }
                else
                {
                    DataBase.phoneToggleIsOn = false;
                }
                break;
            case ItemType.Bookshelf:
                if (gameObject.transform.parent.transform.GetChild(4).GetComponent<Toggle>().isOn)
                {
                    DataBase.phoneToggleIsOn = true;
                }
                else
                {
                    DataBase.phoneToggleIsOn = false;
                }

                break;
            case ItemType.WaterGun:
                if (gameObject.transform.parent.transform.GetChild(4).GetComponent<Toggle>().isOn)
                {
                    DataBase.phoneToggleIsOn = true;
                }
                else
                {
                    DataBase.phoneToggleIsOn = false;
                }
                break;
            case ItemType.Orb:
                if (gameObject.transform.parent.transform.GetChild(4).GetComponent<Toggle>().isOn)
                {
                    DataBase.phoneToggleIsOn = true;
                }
                else
                {
                    DataBase.phoneToggleIsOn = false;
                }
                break;
            case ItemType.Table:
                if (gameObject.transform.parent.transform.GetChild(4).GetComponent<Toggle>().isOn)
                {
                    DataBase.phoneToggleIsOn = true;
                }
                else
                {
                    DataBase.phoneToggleIsOn = false;
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

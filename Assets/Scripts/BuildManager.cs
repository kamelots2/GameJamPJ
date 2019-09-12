using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildManager : MonoBehaviour
{
    public int timer= 0;
    public ItemsData appleData;
    public ItemsData orangeData;
    private PlayerData playerData;
    private PlayerData dadData;
    private PlayerData momData;
    private PlayerData sisterData;
    private PlayerData dogData;

    public Text appleText;
    public Text orangeText;
    public Text playerHpText;
    public Text monHpText;
    public Text dadHpText;
    public Text sisterHpText;
    public Text dogHpText;
    public Text playerSpText;
    public Text dadSpText;
    public Text monSpText;
    public Text sisterSpText;
    public Text dogSpText;

    public int playeriFood=100;
    public int dadriFood=100;
    public int momiFood=100;
    public int sisteriFood=100;
    public int dogiFood=100;

    public int appleConst;
    public int orangeConst;

    private void Update()
    {

        if (timer==180)
        {
            playeriFood--;
            dadriFood--;
            momiFood--;
            sisteriFood--;
            dogiFood--;
            playerSpText.text = " " + playeriFood;
            dadSpText.text = " " + dadriFood;
            monSpText.text = " " + momiFood;
            sisterSpText.text = " " + sisteriFood;
            dogSpText.text = " " + dogiFood;
            timer = 0;
        }
        timer++;
    }

    public void ItemUpdate()
    {
        appleText.text = ""+ appleConst;
        orangeText.text = "" + orangeConst;
    }



    public void HpChange(int data1)
    {
         data1++;
        Debug.Log("jiaxue");
    }

    public void SpChange(int data2)
    {
        data2++;
        Debug.Log(data2);
    }

    //表示当前选择的道具
    private ItemsData selectedItemsData;

    public void OnAppleSelected(bool isOn)
    {
        selectedItemsData = appleData;
    }
    public void OnOrangeSelected(bool isOn)
    {
        selectedItemsData = orangeData;
    }

    public void OnPlayer()
    {
        if (selectedItemsData == appleData && appleConst > 0)
        {
            //    HpChange(playerData);
            GameObject.Find("Player3").GetComponent<PlayerData>().iHP++;
            appleConst--;
            appleText.text= " "+ appleConst;
            playerHpText.text = " " + GameObject.Find("Player3").GetComponent<PlayerData>().iHP;
        }
        else if(selectedItemsData == orangeData && orangeConst > 0)
        {           
            playeriFood++;
            orangeConst--;
            orangeText.text = " " + orangeConst;
            playerSpText.text = " " + playeriFood;
        }
    }

    public void OnDad()
    {
        if (selectedItemsData == appleData && appleConst > 0)
        {
            //   HpChange(dadData);
            GameObject.Find("Player1").GetComponent<PlayerData>().iHP++;
            appleConst--;
            appleText.text = " " + appleConst;
            dadHpText.text = " " + GameObject.Find("Player1").GetComponent<PlayerData>().iHP;
        }
        else if (selectedItemsData == orangeData&& orangeConst>0)
        {
            dadriFood++;
            orangeConst--;
            orangeText.text = " " + orangeConst;
            dadSpText.text = " " + dadriFood;
        }
    }

    public void OnMon()
    {
        if (selectedItemsData == appleData && appleConst > 0)
        {
            //  HpChange(momData);
            GameObject.Find("Player2").GetComponent<PlayerData>().iHP++;
            appleConst--;
            appleText.text = " " + appleConst;
            monHpText.text = " " + GameObject.Find("Player2").GetComponent<PlayerData>().iHP;
        }
        else if (selectedItemsData == orangeData && orangeConst > 0)
        {
            momiFood++;
            orangeConst--;
            orangeText.text = " " + orangeConst;
            monSpText.text = " " + momiFood;
        }
    }

    public void OnSister()
    {
        if (selectedItemsData == appleData && appleConst > 0)
        {
            //   HpChange(sisterData);
            GameObject.Find("Player4").GetComponent<PlayerData>().iHP++;
            appleConst--;
            appleText.text = " " + appleConst;
            sisterHpText.text = " " + GameObject.Find("Player4").GetComponent<PlayerData>().iHP;
        }
        else if (selectedItemsData == orangeData && orangeConst > 0)
        {
           sisteriFood++;
            orangeConst--;
            orangeText.text = " " + orangeConst;
            sisterSpText.text = " " + sisteriFood;
        }
    }

    public void OnDog()
    {
        if (selectedItemsData == appleData && appleConst > 0)
        {
            //   HpChange(dogData);
            GameObject.Find("Player5").GetComponent<PlayerData>().iHP++;
            appleConst--;
            appleText.text = " " + appleConst;
            dogHpText.text = " " + GameObject.Find("Player5").GetComponent<PlayerData>().iHP;
        }
        else if (selectedItemsData == orangeData && orangeConst > 0)
        {
           dogiFood++;
            orangeConst--;
            orangeText.text = " " + orangeConst;
            dogSpText.text = " " + dogiFood;
        }
    }

}

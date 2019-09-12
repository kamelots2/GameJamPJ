using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Event : MonoBehaviour
{
   
    public GameObject EventText;
    public GameObject PlayerExit;
    public GameObject EventCollider;
    public GameObject BattleSucces;
    public GameObject BattleLose;
    public GameObject ReturnBatton;
    
    public int random; 


    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            random = Random.Range(1,3);
            EventText.SetActive(true);
            Time.timeScale = 0;
        }
    }
    public void BattleEventEntery()
    {
        if (random == 1)
        {
            ReturnBatton.SetActive(true);
            EventText.SetActive(false);
            BattleSucces.SetActive(true);
        }
        else
        {
            Destroy(PlayerExit);
            ReturnBatton.SetActive(true);
            EventText.SetActive(false);
            BattleLose.SetActive(true);
        }
    }

    public void Close()
    {
        Time.timeScale = 1;
        EventCollider.SetActive(false);
        EventText.SetActive(false);
    }
}

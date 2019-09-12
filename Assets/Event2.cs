using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event2 : MonoBehaviour
{
    public GameObject EventText2;
    public GameObject PlayerExit2;
    public GameObject EventCollider2;

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            EventText2.SetActive(true);
            PlayerExit2.SetActive(false);
        }
    }

    public void PlayerEntery()
    {
        PlayerExit2.SetActive(true);
        EventText2.SetActive(false);
        EventCollider2.SetActive(false);

    }
}

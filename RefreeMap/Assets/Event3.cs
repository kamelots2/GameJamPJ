using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event3 : MonoBehaviour
{
    public GameObject EventText3;
    public GameObject PlayerExit3;
    public GameObject EventCollider3;

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            EventText3.SetActive(true);
            PlayerExit3.SetActive(false);
        }
    }

    public void PlayerEntery()
    {
        PlayerExit3.SetActive(true);
        EventText3.SetActive(false);
        EventCollider3.SetActive(false);

    }
}

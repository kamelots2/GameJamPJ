using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerData : MonoBehaviour
{
    // Start is called before the first frame update
    public int iHP;
    public int iFood;
    private bool bIsSafe = false;
    public GameObject UIobj;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Hurt(int i)
    {
        if (bIsSafe)
        {
           return;
        }
        iHP -= i;
        if (iHP <= 0)
        {
           iHP = 0;
            UIobj.SetActive(false);
           if (!gameObject.GetComponent<Controller>().bIsAI)
            {
              GameObject.Find("Manager").GetComponent<OBJManager>().ChangeCharactor();
            }else
            {
              gameObject.GetComponent<NavMeshAgent>().isStopped = true;
              gameObject.name = name + 1;
              Destroy(gameObject);
              
              //change name 
              //dead
            } 
        }
    }

    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Build"))
        {
            bIsSafe = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Build"))
        {
            bIsSafe = false;
        }
    }

    public bool IsSafe()
    {
        return bIsSafe;
    }
}

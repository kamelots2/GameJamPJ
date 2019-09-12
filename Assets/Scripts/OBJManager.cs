using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OBJManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject gOBj_AB;
    public Canvas can;
    public float fTime;
    public int iMaxTime;
    public int iMinTime;
    public int iPointNum;
    void Start()
    {
        //Airborne();
        fTime = 10;
    }

    // Update is called once per frame
    void Update()
    {
        fTime -= Time.deltaTime;
        if(fTime < 0)
        {
            Airborne();
            //ChangeCharactor();
            fTime = Random.Range(iMinTime, iMaxTime);
        }
    }

    void Airborne()
    {
        int x = Random.Range(0, iPointNum);
        GameObject point = GameObject.Find("ABPoint" + x);
        if (!point)
            return;
        GameObject obj = Instantiate(gOBj_AB);
        obj.transform.position = new Vector3(point.transform.position.x, 0.01f, point.transform.position.z);
        //obj.transform.position = new Vector3(0, 0.01f, 0);
    }

    void Dead()
    {
      can.gameObject.SetActive(true);
      Time.timeScale = 0;
    }

    public void ChangeCharactor()
    {
        for (int i = 1; i < 6; i++)
        {
            GameObject obj = GameObject.Find("Player" + i);
            if (obj)
            {
                if(!obj.GetComponent<Controller>().bIsAI)
                {
                    //obj.GetComponent<Controller>().IsNav = false;
                    //obj.GetComponent<Controller>().bIsAI = true;
                    obj.name = "DEAD" + i;
                    Destroy(obj);
                }    
                break;
            }
        }
        for (int i=2;i<6;i++)
        {
            GameObject obj = GameObject.Find("Player" + i);
            if(obj)
            {
                obj.GetComponent<Controller>().ChangeToController();
                return;
            }
        }
        Dead();
    }

}

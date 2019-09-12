using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Airborne : MonoBehaviour
{
    // Start is called before the first frame update
    private int iDamage;
    private float fDamageTime;
    //public GameObject gObj;
    private SphereCollider spCol;
    private float fTime = 20;
    public int iMaxTime;
    public int iMinTime;
    private int iScale;
    public int iMaxScale;
    public int iMinScale;
    List<GameObject> lObj = new List<GameObject>();
    void Start()
    {
        iDamage = 100;
        fDamageTime = 5;
        fTime = Random.Range(iMinTime, iMaxTime);
        spCol = GetComponent<SphereCollider>();
        iScale = Random.Range(iMinScale, iMaxScale)*2+1;
        transform.parent.gameObject.transform.localScale *= iScale;
    }
    // Update is called once per frame
    void Update()
    {
        fDamageTime -= Time.deltaTime;
        fTime -= Time.deltaTime;
        if(fTime <= 0)
        {
            Destroy(transform.parent.gameObject);
            return;
        }
        if(fDamageTime <= 0)
        {
            //hurt;
            fDamageTime = 5;
            //Physics.OverlapSphere(transform.position, )
            foreach (GameObject gObj in lObj)
            {
                if(gObj)
                {
                   gObj.GetComponent<PlayerData>().Hurt(iDamage);
                }
                
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            lObj.Add(other.gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            lObj.Remove(other.gameObject);
        }   
    }

    //public void Init(float time, int type, int damage, float fDamageTime)
    //{
    //    fTime = time;
    //    iDamage = damage;
    //    this.fDamageTime = fDamageTime;
    //}
}

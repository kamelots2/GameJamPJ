using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nomimono : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        GameObject.Find("GameManager").GetComponent<BuildManager>().orangeConst++;
        GameObject.Find("GameManager").GetComponent<BuildManager>().ItemUpdate();
        Destroy(gameObject);
    }
}

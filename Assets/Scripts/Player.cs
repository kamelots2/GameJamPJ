using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
        GameObject.Find("Main Camera");
    }

    public float m_speed = 2.0f;
    // Update is called once per frame
    void Update()
    {
        
        float horizontal = Input.GetAxis("Horizontal"); //获取垂直轴
        float vertical = Input.GetAxis("Vertical");    //获取水平轴 

        transform.Translate(Vector3.forward * vertical * m_speed * Time.deltaTime);//W S
        transform.Translate(Vector3.right * horizontal * m_speed * Time.deltaTime);// A D 

        //this.transform.LookAt(Camera.main.transform.position);
        //this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(Camera.main.transform.position - this.transform.position), 0);


    }
    void Animating(float horizontal, float vertical)
    {
        if(vertical != 0 || vertical != 0)//是否处于行走状态
        animator.SetBool("walk", true);
        else{
        animator.SetBool("walk", false);           
        }

    }

}

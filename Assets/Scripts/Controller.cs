using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Controller : MonoBehaviour
{
    public float fSpeed = 100;
    private Animator anim;
    private Rigidbody rgd;
    private bool bRIght = true;
    public GameObject cameraObj;
    private Quaternion rRotation;
    public bool bIsAI = false;

    public GameObject target;
    private NavMeshAgent navMeshAgent;
    public bool IsNav = true;
    public float fDistance = 5;

    private void Start()
    {
        anim = GetComponent<Animator>();
        rgd = GetComponent<Rigidbody>();
        rRotation = Quaternion.Euler(new Vector3(0, 0, 0));
        navMeshAgent = GetComponent<NavMeshAgent>();
        if (navMeshAgent == null)
        {
            navMeshAgent = gameObject.AddComponent<NavMeshAgent>();
        }
    }

    void Update()
    {
        if(bIsAI)
        {
            if (!IsNav)
            {
                return;
            }
            float distance = (transform.position - target.transform.position).magnitude;

            if (distance < fDistance)
            {
                navMeshAgent.isStopped = true;
            }
            else if (navMeshAgent.isStopped)
            {
                navMeshAgent.isStopped = false;
                navMeshAgent.SetDestination(target.transform.position);
            }
            else
            {
                navMeshAgent.SetDestination(target.transform.position);
            }
            anim.SetFloat("speed", Mathf.Abs(navMeshAgent.velocity.x));
            if (navMeshAgent.velocity.x > 0.01 && !bRIght)
            {
                bRIght = true;
                rRotation = Quaternion.Euler(new Vector3(0, 0, 0));
            }
            else if (navMeshAgent.velocity.x < -0.01 && bRIght)
            {
                bRIght = false;
                rRotation = Quaternion.Euler(new Vector3(0, 180, 0));
            }
            transform.rotation = rRotation * Quaternion.Euler(new Vector3(0, cameraObj.GetComponent<CameraMove>().eulerAngles_x, 0));
        }
        else
        {
            float hMove = Input.GetAxis("Horizontal") * fSpeed;
            float vMove = Input.GetAxis("Vertical") * fSpeed;
            float speed = Mathf.Abs(hMove) > Mathf.Abs(vMove) ? hMove : vMove;
            anim.SetFloat("speed", Mathf.Abs(speed));
        
        
            if (hMove > 0.01 && !bRIght)
            {
                bRIght = true;
                rRotation = Quaternion.Euler(new Vector3(0, 0, 0));
            }
            else if (hMove < -0.01 && bRIght)
            {
                bRIght = false;
                rRotation = Quaternion.Euler(new Vector3(0, 180, 0));
            }
            transform.rotation = rRotation * Quaternion.Euler(new Vector3(0, cameraObj.GetComponent<CameraMove>().eulerAngles_x, 0));
            Vector3 translation = new Vector3(hMove, 1, vMove) * Time.deltaTime;
            rgd.velocity = translation;
        }
    }
    
    public void ChangeToController()
    {
        navMeshAgent.isStopped = true;
        bIsAI = false;
        GameObject.Find("Main Camera").GetComponent<CameraMove>().target = gameObject.transform;
        GameObject.Find("Main Camera").GetComponent<CameraMove>().player = gameObject;
    }
}
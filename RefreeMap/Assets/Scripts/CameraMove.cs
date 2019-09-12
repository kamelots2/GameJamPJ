using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public Transform target;//主相机要围绕其旋转的物体
    public GameObject player;
    private GameObject last_obj;
    public float distance = 3;//主相机与目标物体之间的距离
    //  [HideInInspector]
    public float eulerAngles_x;
    public float eulerAngles_y;
    // [HideInInspector]
    //水平滚动相关
    public float distanceMax = 5;//主相机与目标物体之间的最大距离
    public float distanceMin = 2;//主相机与目标物体之间的最小距离

    public float xSpeed = 70.0f;//主相机水平方向旋转速度

    Vector3 Teme;
    float XX;

    Vector3 screenPoint, offset, OldPoint;

    //滚轮相关
    public float MouseScrollWheelSensitivity = 1.0f;//鼠标滚轮灵敏度（备注：鼠标滚轮滚动后将调整相机与目标物体之间的间隔）

    public LayerMask CollisionLayerMask;

    void Start()
    {
        Vector3 eulerAngles = this.transform.eulerAngles;//当前物体的欧拉角
        this.eulerAngles_x = eulerAngles.y;
    }
    void Update()
    {
        if (Time.timeScale < 0.5)   
            return;
        if(Input.GetMouseButtonDown(1))
        {
            XX = Input.mousePosition.x;
        }
        if (Input.GetMouseButton(1))
        {
            this.eulerAngles_x += (Input.mousePosition.x - XX) * Time.deltaTime * this.xSpeed;
            if(this.eulerAngles_x > 45)
            {
                this.eulerAngles_x = 45;
            }
            else if(this.eulerAngles_x < -45)
            {
                this.eulerAngles_x = -45;
            }
                XX = Input.mousePosition.x;
        }

        this.distance = Mathf.Clamp(this.distance - (Input.GetAxis("Mouse ScrollWheel") * MouseScrollWheelSensitivity), (float)this.distanceMin, (float)this.distanceMax);

        Quaternion quaternion = Quaternion.Euler(eulerAngles_y, this.eulerAngles_x, (float)0);

        RaycastHit hit;
        //if (!transform || !player)
        //    return;
        if (Physics.Linecast(transform.position, player.transform.position, out hit , 1<< LayerMask.NameToLayer("Building")))
        {
            if (!last_obj)
            {
                last_obj = hit.collider.gameObject;

                string name_tag = last_obj.transform.parent.gameObject.tag;

                //判断
                if (name_tag == "Build")
                {
                    Color obj_color = last_obj.GetComponent<SpriteRenderer>().color;
                    obj_color.a = 0.5f;
                    last_obj.GetComponent<SpriteRenderer>().color = obj_color;
                }else
                {
                    last_obj = null;
                }
            }
        }
        else if (last_obj != null)
        {

            Color obj_color = last_obj.GetComponent<SpriteRenderer>().color;
            obj_color.a = 1.0f;
            last_obj.GetComponent<SpriteRenderer>().color = obj_color;
            last_obj = null;

        }

        Vector3 vector = ((Vector3)(quaternion * new Vector3(0, 0, -this.distance))) + this.target.position;

        //更改主相机的旋转角度和位置
        this.transform.rotation = quaternion;
        this.transform.position = vector;
    }
}









using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class viewcontroller : MonoBehaviour
{

    public Transform target;//主相机要围绕其旋转的物体
    public float distance = 7.0f;//主相机与目标物体之间的距离
    //  [HideInInspector]
    public float eulerAngles_x;
    // [HideInInspector]
    //水平滚动相关
    public float distanceMax = 10;//主相机与目标物体之间的最大距离
    public float distanceMin = 3;//主相机与目标物体之间的最小距离

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

        //中键目标左右移动
        if (Input.GetKeyDown(KeyCode.Mouse2))
        {
            OldPoint = Input.mousePosition;

        }
        else if (Input.GetKey(KeyCode.Mouse2))
        {
            Vector3 Tagetpos = target.transform.localPosition;
            Vector3 MousPOS = Input.mousePosition;

            if (Input.mousePosition == OldPoint) return;

            Vector3 curPosition = (OldPoint - MousPOS) + Camera.main.WorldToScreenPoint(target.transform.localPosition);
            Vector3 pos = Camera.main.ScreenToWorldPoint(curPosition);
            target.transform.localPosition = new Vector3(Mathf.Clamp(pos.x, 0.4f, 2.3f), Mathf.Clamp(pos.y, 0.6f, 1.84f), Mathf.Clamp(pos.z, -2f, 0));
            // target.transform.position = pos;
            OldPoint = Input.mousePosition;
        }
        else if (Input.GetKeyUp(KeyCode.Mouse2))
        {
            Cursor.SetCursor(Resources.Load<Texture2D>("Mouse/shouzhi"), Vector2.zero, CursorMode.ForceSoftware);
        }
        //右键目标旋转
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            XX = Input.mousePosition.x;
        }
        else if (Input.GetKey(KeyCode.Mouse1))
        {
            this.eulerAngles_x += (Input.mousePosition.x - XX) * Time.deltaTime * this.xSpeed;
            XX = Input.mousePosition.x;
        }

        this.distance = Mathf.Clamp(this.distance - (Input.GetAxis("Mouse ScrollWheel") * MouseScrollWheelSensitivity), (float)this.distanceMin, (float)this.distanceMax);

        Quaternion quaternion = Quaternion.Euler((float)0, this.eulerAngles_x, (float)0);

        //从目标物体处，到当前脚本所依附的对象（主相机）发射一个射线，如果中间有物体阻隔，则更改this.distance（这样做的目的是为了不被挡住）

        RaycastHit hitInfo = new RaycastHit();

        if (Physics.Linecast(this.target.position, this.transform.position, out hitInfo, this.CollisionLayerMask))
        {
            this.distance = hitInfo.distance - 0.05f;
        }

        Vector3 vector = ((Vector3)(quaternion * new Vector3(0, 0, -this.distance))) + this.target.position;

        //更改主相机的旋转角度和位置
        this.transform.rotation = quaternion;
        this.transform.position = vector;
    }

    //把角度限制到给定范围内
    public float ClampAngle(float angle, float min, float max)

    {
        while (angle < -360)
        {
            angle += 360;
        }
        while (angle > 360)
        {
            angle -= 360;
        }
        return Mathf.Clamp(angle, min, max);
    }

}





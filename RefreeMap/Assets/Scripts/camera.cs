using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//public class camera : MonoBehaviour
//{
    //    // 滚轮实现镜头缩进和拉远

        //    //鼠标右键实现视角转动，类似第一人称视角
        //    if (Input.GetMouseButton(1))
        //    {
        //        float rotationX = Input.GetAxis("Mouse X") * sensitivityX;
        //        float rotationY = Input.GetAxis("Mouse Y") * sensitivityY;
        //        transform.Rotate(-rotationY, rotationX, 0);
        //    }

        //}
 
    //    //观察目标
    //    public Transform Target;
    //    //观察距离
    //    public float Distance = 5F;
    //    //旋转速度
    //    private float SpeedX = 240;
    //    private float SpeedY = 120;
    //    //角度限制
    //    private float MinLimitY = 5;
    //    private float MaxLimitY = 180;

    //    //旋转角度
    //    private float mX = 0.0F;
    //    private float mY = 0.0F;

    //    //鼠标缩放距离最值
    //    private float MaxDistance = 10;
    //    private float MinDistance = 1.5F;
    //    //鼠标缩放速率
    //    private float ZoomSpeed = 2F;

    //    //是否启用差值
    //    public bool isNeedDamping = true;
    //    //速度
    //    public float Damping = 10F;

    //    private Quaternion mRotation;

    //    void Start()
    //    {
    //        //初始化旋转角度
    //        mX = transform.eulerAngles.x;
    //        mY = transform.eulerAngles.y;
    //    }

    //    void LateUpdate()
    //    {
    //        //鼠标右键旋转
    //        if (Target != null && Input.GetMouseButton(1))
    //        {
    //            //获取鼠标输入
    //            mX += Input.GetAxis("Mouse X") * SpeedX * 0.02F;
    //            mY -= Input.GetAxis("Mouse Y") * SpeedY * 0.02F;
    //            //范围限制
    //            mY = ClampAngle(mY, MinLimitY, MaxLimitY);
    //            //计算旋转
    //            //我们可以通过Quaternion.Euler()方法将一个Vector3类型的值转化为一个四元数
    //            //，进而通过修改Transform.Rotation来实现相同的目的
    //            mRotation = Quaternion.Euler(mY, mX, 0);
    //            //根据是否插值采取不同的角度计算方式
    //            if (isNeedDamping)
    //            {
    //                transform.rotation = Quaternion.Lerp(transform.rotation, mRotation, Time.deltaTime * Damping);
    //            }
    //            else
    //            {
    //                transform.rotation = mRotation;
    //            }
    //            //处理同时按下鼠标右键和方向控制键
    //            /* if (Target.GetComponent<NoLockiVew_Player>().State == NoLockiVew_Player.PlayerState.Walk)
    //             {
    //                 Target.rotation = Quaternion.Euler(new Vector3(0, mX, 0));
    //             }*/
    //        }

    //        //鼠标滚轮缩放
    //        Distance -= Input.GetAxis("Mouse ScrollWheel") * ZoomSpeed;
    //        Distance = Mathf.Clamp(Distance, MinDistance, MaxDistance);

    //        //重新计算位置
    //        Vector3 mPosition = mRotation * new Vector3(0.0F, 0.0F, -Distance) + Target.position;

    //        //设置相机的角度和位置
    //        if (isNeedDamping)
    //        {
    //            transform.position = Vector3.Lerp(transform.position, mPosition, Time.deltaTime * Damping);
    //        }
    //        else
    //        {
    //            transform.position = mPosition;
    //        }

    //    }


    //    //角度限制
    //    private float ClampAngle(float angle, float min, float max)
    //    {
    //        if (angle < -180) angle += 180;
    //        if (angle > 180) angle -= 180;
    //        return Mathf.Clamp(angle, min, max);
    //    }
    //}



[ExecuteInEditMode, DisallowMultipleComponent]
public class camera : MonoBehaviour
{


    public GameObject target; // an object to follow
    public Vector3 offset; // offset form the target object

    [SerializeField] private float distance = 4.0f; // distance from following object
    [SerializeField] private float polarAngle = 45.0f; // angle with y-axis
    [SerializeField] private float azimuthalAngle = 45.0f; // angle with x-axis

    [SerializeField] private float minDistance = 1.0f;
    [SerializeField] private float maxDistance = 7.0f;
    [SerializeField] private float minPolarAngle = 5.0f;
    [SerializeField] private float maxPolarAngle = 75.0f;
    [SerializeField] private float mouseXSensitivity = 5.0f;
    [SerializeField] private float mouseYSensitivity = 5.0f;
    [SerializeField] private float scrollSensitivity = 5.0f;

    void LateUpdate()
    {
        if (Input.GetMouseButton(1))
        {
            updateAngle(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
        }
        updateDistance(Input.GetAxis("Mouse ScrollWheel"));

        var lookAtPos = target.transform.position + offset;
        updatePosition(lookAtPos);
        transform.LookAt(lookAtPos);
    }

    void updateAngle(float x, float y)
    {
        x = azimuthalAngle - x * mouseXSensitivity;
        azimuthalAngle = Mathf.Repeat(x, 360);

        y = polarAngle + y * mouseYSensitivity;
        polarAngle = Mathf.Clamp(y, minPolarAngle, maxPolarAngle);
    }

    void updateDistance(float scroll)
    {
        scroll = distance - scroll * scrollSensitivity;
        distance = Mathf.Clamp(scroll, minDistance, maxDistance);
    }

    void updatePosition(Vector3 lookAtPos)
    {
        var da = azimuthalAngle * Mathf.Deg2Rad;
        var dp = polarAngle * Mathf.Deg2Rad;
        transform.position = new Vector3(
            lookAtPos.x + distance * Mathf.Sin(dp) * Mathf.Cos(da),
            lookAtPos.y + distance * Mathf.Cos(dp),
            lookAtPos.z + distance * Mathf.Sin(dp) * Mathf.Sin(da));
    }
}




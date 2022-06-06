using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject followTarget; // 要跟随的对象
    public float moveSpeed; // 相机移动速度
    Vector3 targetPos; // 要移动至的位置

    private void Update()
    {
        targetPos = new Vector3(
            followTarget.transform.position.x,
            followTarget.transform.position.y,
            transform.position.z);

        // 移动自己
        if ((targetPos - transform.position).magnitude < 0.01f) transform.position = targetPos;
        else
            transform.position = Vector3.Lerp(
                transform.position,
                targetPos,
                moveSpeed * Time.deltaTime);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActorMoveCtrl : MonoBehaviour
{
    public float speed = 2.0F;
    private Vector3 moveDirection = Vector3.zero;
    private Transform mTransform;
    private float h;
    private float v;

    // Start is called before the first frame update
    void Start()
    {
        mTransform = transform;
    }

    void Update()
    {
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");
        moveDirection = new Vector3(h, 0, v);
        mTransform.LookAt(transform.position + moveDirection); //角色朝向
        mTransform.Translate(moveDirection * speed * Time.deltaTime, Space.World); //移动
    }

    void test()
    {
        Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0)); //射线
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit)) //发射射线(射线，射线碰撞信息，射线长度，射线会检测的层级)
        {
            transform.position = new Vector3(hit.point.x, transform.position.y, hit.point.z);
        }
    }
}
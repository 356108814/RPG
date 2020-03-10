using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * 
 */
public class SmoothFollow : MonoBehaviour
{
    // 跟随
    public Transform target;
    // 相机在目标上方多高
    public float distanceX = -10.0f;
    public float distanceY = 20.0f;
    //相机在目录Z上的距离
    public float distanceZ = -10f;

    private Transform cTransform;
    private Vector3 targetPos;
    
    void Start()
    {
        cTransform = gameObject.transform;
    }

    void Update()
    {
        if (!target)
        {
            return;
        }
        targetPos = target.position;
        //相机位置不随玩家位置高度，高度60固定
        cTransform.position = new Vector3(targetPos.x + this.distanceX, targetPos.y + distanceY, targetPos.z + distanceZ);
    }
    
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothFollow : MonoBehaviour
{
    // The target we are following
    public Transform target;
    public Transform mTransform = null;
    public float distance = 10.0f;
    // the height we want the camera to be above the target
    public float height = 5.0f;
    public float heightDamping = 2.0f;
    public float rotationDamping = 3.0f;

    private Camera _mainCamera;
    
    
    // Start is called before the first frame update
    void Start()
    {
    }
    
    public Transform GetTransform()
    {
        if (mTransform == null)
        {
            mTransform = gameObject.transform;
        }
        return mTransform;
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null)
        {
            return;
        }
        //相机位置不随玩家位置高度，高度60固定
        Vector3 targetPos = new Vector3(target.position.x, 65, target.position.z - 5);
        // Calculate the current rotation angles
        float wantedRotationAngle = target.eulerAngles.y;
        float wantedHeight = targetPos.y + height;

        float currentRotationAngle = transform.eulerAngles.y;
        float currentHeight = transform.position.y;

        // Damp the rotation around the y-axis
        currentRotationAngle = Mathf.LerpAngle(currentRotationAngle, wantedRotationAngle, rotationDamping * Time.deltaTime);

        // Damp the height
        currentHeight = Mathf.Lerp(currentHeight, wantedHeight, heightDamping * Time.deltaTime);
        
        Quaternion wantRotation = Quaternion.Euler(0, currentRotationAngle, 0);
        Vector3 wantPos = targetPos - wantRotation * Vector3.forward * distance;
        wantPos.y = currentHeight;
        GetTransform().position = wantPos;
        Vector3 dir = targetPos - GetTransform().position;
        dir.Normalize();
        GetTransform().rotation = Quaternion.LookRotation(dir);
    }
}

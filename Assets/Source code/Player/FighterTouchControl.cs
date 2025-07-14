using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FighterTouchControl : MonoBehaviour
{
    public float speed = 10f;
    public float yOffset = 2f;
    private Camera mainCam;
    void Start()
    {
        mainCam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
#if UNITY_EDITOR
        // Debug trên PC bằng chuột
        if (Input.GetMouseButton(0))
        {
            Vector3 target = mainCam.ScreenToWorldPoint(Input.mousePosition);
            MoveToTarget(target);
        }
#else
        // Trên điện thoại
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Moved || touch.phase == TouchPhase.Stationary)
            {
                Vector3 target = mainCam.ScreenToWorldPoint(touch.position);
                MoveToTarget(target);
            }
        }
#endif
    }

    void MoveToTarget(Vector3 target)
    {
        target.z = 0f;
        target.y += yOffset; // Máy bay phía trên ngón tay

        transform.position = Vector3.Lerp(transform.position, target, speed * Time.deltaTime);
    }
}


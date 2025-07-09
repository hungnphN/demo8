using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //var worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //worldPoint.z = 0;
        //transform.position = worldPoint;
        //Mở rộng cho player giới hạn khung hình
        Vector3 mouseViewport = Camera.main.ScreenToViewportPoint(Input.mousePosition);
        mouseViewport.x = Mathf.Clamp(mouseViewport.x, 0.05f, 1f);
        mouseViewport.y = Mathf.Clamp(mouseViewport.y, 0.05f, 1f);
        Vector3 worldPoint = Camera.main.ViewportToWorldPoint(mouseViewport);
        worldPoint.z = 0;
        transform.position = worldPoint;
    }
}

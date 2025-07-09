using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthbarFollow : MonoBehaviour
{
    public Transform target;
    public Vector3 offset = new Vector3(0, 1.5f, 0);
    // Start is called before the first frame update
    void LateUpdate()
    {
        if (target == null) return;

        Vector3 screenPos = Camera.main.WorldToScreenPoint(target.position + offset);
        transform.position = screenPos;
    }
}

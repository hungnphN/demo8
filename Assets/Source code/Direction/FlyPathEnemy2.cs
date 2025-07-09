using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyPathEnemy2 : MonoBehaviour
{
    public FlyPath flyPath;
    public float flySpeed;
    public int nextIndex = 1;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = flyPath[0];
        transform.rotation = Quaternion.Euler(0, 0, 180);
    }

    // Update is called once per frame
    void Update()
    {
        if (flyPath == null) return;
        if (nextIndex >= flyPath.waypoints.Length) return;
        if (transform.position != flyPath[nextIndex])
        {
            FlyToNextWaypoint();
            lookAt(flyPath[nextIndex]);
        }
        else
        {
            nextIndex++;
        }
    }
    private void FlyToNextWaypoint()
    {
        transform.position = Vector3.MoveTowards(transform.position, flyPath[nextIndex], flySpeed * Time.deltaTime);
    }
    private void lookAt(Vector2 destination)
    {
        Vector2 position = transform.position;
        var lookDirection = destination - position;
        if (lookDirection.magnitude < 0.01f) return;
        float angle = Vector2.SignedAngle(Vector2.up, lookDirection);
        transform.rotation = Quaternion.Euler(0, 0, angle + 180f);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCamera : MonoBehaviour
{
    private Transform target;
    private float trackSpeed = 10;

    public void SetTarget(Transform t)
    {
        target = t;
    }

    void LateUpdate()
    {
        if(target)
        {
            float x = IncrementTowards(transform.position.x, target.position.x, trackSpeed);
            float y = IncrementTowards(transform.position.y, target.position.y, trackSpeed);
            transform.position = new Vector3(x, y, transform.position.z);
        }
    }

    //increase n towards target speed
    private float IncrementTowards(float n, float target, float a)
    {
        if (n == target)
        {
            return n;
        }
        else
        {
            float dir = Mathf.Sign(target - n); // must be increased or decreased to get closer to target
            n += a * Time.deltaTime * dir;
            return (dir == Mathf.Sign(target - n)) ? n : target; // if n has now passed target then return target, otherwise return n

        }
    }
}

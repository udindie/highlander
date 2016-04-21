using UnityEngine;
using System.Collections;

public class RotatePlatform : MonoBehaviour {

    public KeyCode actionHold;
    public Transform target;
    public bool stopTime = false;
    public float duration = 2.5f;
    public float rotateDuration = 100f;
    public float cooldown = 1f;
    public bool active = true;
    bool rotate = false;
    public float startAngle;
    public float rotationAngle = 180f;
    float lasttime;
    float time;

    // Update is called once per frame
    void Update()
    {
        if (active && Input.GetKey(actionHold))
        {
            lasttime = time;
            time = Time.time;
            active = false;
            rotate = true;
            if (stopTime)
            {
                Configuration.Instance.UpdateTimescale(0f, null);
            }
            Invoke("EndPower", duration);
        }
        if (rotate)
        {
            Rotate();
        }
    }

    void EndPower()
    {
        rotate = false;
        startAngle = (startAngle + rotationAngle) % 360;

        for (int i = 0; i < target.childCount; i++)
        {
            target.GetChild(i).rotation = Quaternion.AngleAxis(startAngle, Vector3.forward);
        }
 
        if (stopTime)
        {
            Configuration.Instance.UpdateTimescale(1f, null);
        }
        Invoke("ActivatePower", cooldown);
    }

    void ActivatePower()
    {
        active = true;
    }

    void Rotate()
    {
        lasttime = time;
        time = Time.time;
        float finalAngle = startAngle + rotationAngle;

        float speed = rotationAngle / rotateDuration;

        Quaternion newRotation = Quaternion.AngleAxis(finalAngle, Vector3.forward);

        for (int i = 0; i < target.childCount; i++)
        {
            target.GetChild(i).rotation = Quaternion.Slerp(target.GetChild(i).rotation, newRotation, speed * (time - lasttime));
        }
    }
}
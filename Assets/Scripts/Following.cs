using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Following : MonoBehaviour
{
    public GameObject Target;
    public float smooth = 2f;
    public float angle = 0;
    Vector3 distance;
    // Start is called before the first frame update
    void Awake()
    {
        distance = transform.position - Target.transform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (Target == null)
            return;
        RotateAround(Target.transform.position, Vector3.up, angle);
        transform.LookAt(Target.transform.position);
	}

    void RotateAround(Vector3 center, Vector3 axis, float angle)
    {
        Quaternion rotation = Quaternion.AngleAxis(angle, axis);
        Vector3 beforeVector = Vector3.Lerp(Target.transform.position + distance, transform.position, Time.deltaTime * smooth) - center;
        Vector3 afterVector = rotation * beforeVector;
        transform.position = afterVector + center;

        transform.LookAt(Target.transform.position);
    }
}

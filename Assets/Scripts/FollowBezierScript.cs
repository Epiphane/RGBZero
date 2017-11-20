using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowBezierScript : MonoBehaviour {

    public BezierPath path = null;
    public float speed = 1;
    public bool byDist = false;

    private float t = 0;

    void Start() {
    }

    void Update() {
        float vertical = Input.GetAxis("Vertical");

        t += vertical * speed * Time.deltaTime;
        transform.position = path.GetPositionByT(t);

        Vector3 ahead = path.GetPositionByT(t + 0.1f);
        transform.rotation = Quaternion.FromToRotation(Vector3.forward, ahead - transform.position) * Quaternion.AngleAxis(path.GetTrackAngleByT(t), Vector3.back);
    }
}

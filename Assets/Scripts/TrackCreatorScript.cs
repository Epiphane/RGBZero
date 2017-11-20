using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackCreatorScript : MonoBehaviour {

    public GameObject trackSectionModel;
    public GameObject trackGateModel;

    public List<GameObject> trackPieces;

    public void CreateTrack() {
        BezierPath skeleton = GetComponent<BezierPath>();

        foreach (GameObject piece in trackPieces) {
            GameObject.DestroyImmediate(piece);
        }

        trackPieces.Clear();

        for (int i = 0; i < skeleton.points.Count; i++) {
            BezierPath.PathPoint point = skeleton.points[i];
            for (float t = 0; t < 1; t += 0.05f) {

                GameObject trackPiece = GameObject.Instantiate(trackSectionModel);
                trackPieces.Add(trackPiece);

                trackPiece.transform.parent = transform;
                trackPiece.transform.position = point.p1;

                trackPiece.transform.position = skeleton.GetPositionByT(i + t);

                Vector3 ahead = skeleton.GetPositionByT(i + t + 0.1f);
                trackPiece.transform.rotation = Quaternion.FromToRotation(Vector3.forward, ahead - trackPiece.transform.position) * Quaternion.AngleAxis(skeleton.GetTrackAngleByT(i + t), Vector3.back);
            }
        }
    }
}

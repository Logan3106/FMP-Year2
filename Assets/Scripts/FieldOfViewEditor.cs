using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(EnemyScript))]
public class FieldOfViewEditor : Editor
{
    private void OnSceneGUI()
    {
        EnemyScript fieldOfView = (EnemyScript)target;
        Handles.color = Color.white;
        Handles.DrawWireArc(fieldOfView.transform.position, Vector3.up, Vector3.forward, 360, fieldOfView.fov);

        Vector3 viewAngle01 = DirectionFromAngle(fieldOfView.transform.eulerAngles.y, -fieldOfView.angle / 2);
        Vector3 viewAngle02 = DirectionFromAngle(fieldOfView.transform.eulerAngles.y, fieldOfView.angle / 2);

        Handles.color = Color.yellow;
        Handles.DrawLine(fieldOfView.transform.position, fieldOfView.transform.position + viewAngle01 * fieldOfView.fov);
        Handles.DrawLine(fieldOfView.transform.position, fieldOfView.transform.position + viewAngle02 * fieldOfView.fov);

        if (fieldOfView.isPlayerInFov)
        {
            Handles.color = Color.green;
            Handles.DrawLine(fieldOfView.transform.position, fieldOfView.playerRef.transform.position);
        }
    }

    private Vector3 DirectionFromAngle(float eulerY, float angleInDegrees)
    {
        angleInDegrees += eulerY;

        return new Vector3(Mathf.Sin(angleInDegrees * Mathf.Deg2Rad), 0, Mathf.Cos(angleInDegrees * Mathf.Deg2Rad));
    }
}

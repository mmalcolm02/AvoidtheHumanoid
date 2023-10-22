using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(FieldOfView))]
public class FOVEditor : Editor
{
    private void OnSceneGUI()
    {
        FieldOfView fov = (FieldOfView)target;

        //drawing the radius of detection
        Handles.color = Color.white;
        Handles.DrawWireArc(fov.transform.position, Vector3.up, Vector3.forward, 360, fov.radius);

        //determining boundaries of line of sight arc
        Vector3 viewAngle01 = DirectionFromAngle(fov.transform.eulerAngles.y, -fov.angle / 2);
        Vector3 viewAngle02 = DirectionFromAngle(fov.transform.eulerAngles.y, fov.angle / 2);

        //drawing lines for arc of sight
        Handles.color = Color.yellow;
        Handles.DrawLine(fov.transform.position, fov.transform.position + viewAngle01 * fov.radius);
        Handles.DrawLine(fov.transform.position, fov.transform.position + viewAngle02 * fov.radius);

        //if player seen draw a line between enemy and player
        if (fov.canSeePlayer)
        {
            Handles.color = Color.red;
            Handles.DrawLine(fov.transform.position, fov.playerRef.transform.position);
        }
    }

    //method to calculate euluer angles
    private Vector3 DirectionFromAngle(float eulerY, float angleInDegrees)
    {
        angleInDegrees += eulerY;
        return new Vector3(Mathf.Sin(angleInDegrees * Mathf.Deg2Rad), 0, Mathf.Cos(angleInDegrees * Mathf.Deg2Rad));


    }
}

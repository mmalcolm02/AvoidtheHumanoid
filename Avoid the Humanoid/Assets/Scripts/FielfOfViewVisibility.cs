using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FielfOfViewVisibility : MonoBehaviour
{

    




    // Start is called before the first frame update
    private void Start()
    {

        float fovAngle = 90.0f;
        Vector3 origin = Vector3.zero;
        float viewRadius = 20.0f;
        int rayCount = 50;
        float angleIncrease = fovAngle / rayCount;
        float angle = 0f;




    //meshrenderer
    Mesh mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;

        Vector3[] vertices = new Vector3[rayCount+1+1];
        Vector2[] uv = new Vector2[vertices.Length];
        int[] triangles = new int[rayCount * 3];

        vertices[0] = origin;

        int vertexIndex = 1;
        int triangleIndex = 0;
        for (int i = 0; i <= rayCount; i++)
        {
            Vector3 vertex; 
            RaycastHit2D raycastHit2D = Physics2D.Raycast(origin, GetVectorFromAngle(angle), viewRadius);
            if (raycastHit2D.collider == null)
            {
                //no obstruction
                vertex = origin + GetVectorFromAngle(angle) * viewRadius;
            }
            else
                //obstruction
                vertex = raycastHit2D.point;

            vertices[vertexIndex] = vertex;

            if (i > 0)
            {
                triangles[triangleIndex + 0] = 0;
                triangles[triangleIndex + 1] = vertexIndex - 1;
                triangles[triangleIndex + 2] = vertexIndex;
                triangleIndex += 3;
            }

            vertexIndex++;
            angle -= angleIncrease;
        }

        mesh.vertices = vertices;
        mesh.uv = uv;
        mesh.triangles = triangles;


    }

    // Update is called once per frame
    void Update()
    {

        //determine position
        //draw vertices of the mesh
        //raycast to check for obstacles



    }



    //Generate random normalised direction
    public static Vector3 GetVectorFromAngle(float angle)
    {
        //angle = 0 -> 360
        float angleRad = angle * (Mathf.PI / 180f);
        return new Vector3(Mathf.Cos(angleRad), Mathf.Sin(angleRad));


    }

}

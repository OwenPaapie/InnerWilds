using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spotter : MonoBehaviour
{
    public int distance; //spotting distance
    public Transform player; //player
    public float height; //spotting height from ground
    public float angle; // spotting angle
    public Transform Interaction; // gets object of the thing to interact with

    private int count;
    private Collider[] colliders = new Collider[50];
    private Mesh mesh; //sensor mesh

    // Update is called once per frame
    void Update()
    {
        Scan();
    }

    // it scans the area, checks if the player is there and allows them to interact
    private void Scan()
    {
        count = Physics.OverlapSphereNonAlloc(transform.position, distance, colliders); //https://docs.unity3d.com/ScriptReference/Physics.OverlapSphereNonAlloc.html desc in there
        bool hasSpotted = false; // checks if player has been spotted
        for (int i = 0; i < count; i++){
            Transform obj = colliders[i].transform; // gets all the colliders in the area
            if (GameObject.ReferenceEquals(obj, player)) // checks if player is there
            {
                try{
                    Interaction.GetComponent<InteractiveScript>().spotted = true; // goes to report that the player is in the area
                    hasSpotted = true; // player has been spotted and saves
                } catch {
                    Debug.Log("Missing interactivescript component"); // if linked the wrong object
                }
            }
        }
        if (!hasSpotted) {
            Interaction.GetComponent<InteractiveScript>().spotted = false; // player hasn't been spotted and updates that information
        }
    }

    // it creates the sensor that detects what objects are in the area specified
    Mesh CreateSensorMesh()
    {
        Mesh mesh = new Mesh();

        //setting up triangles of the sensor
        int segment = 10;
        int numTriangles = (segment * 4) + 4;
        int numVerticles = numTriangles * 3;

        Vector3[] arrverticle = new Vector3[numVerticles];
        int[] arrtriangle = new int[numVerticles];

        // setting up viewsight sensor

        Vector3 bottomCenter = Vector3.zero;
        Vector3 bottomLeft = Quaternion.Euler(0, -angle, 0) * Vector3.forward * distance;
        Vector3 bottomRight = Quaternion.Euler(0, angle, 0) * Vector3.forward * distance;

        Vector3 topCenter = bottomCenter + Vector3.up * height;
        Vector3 topRight = bottomRight + Vector3.up * height;
        Vector3 topLeft = bottomLeft + Vector3.up * height;

        int vert = 0;
        //left side of the sensor
        arrverticle[vert++] = bottomCenter;
        arrverticle[vert++] = bottomLeft;
        arrverticle[vert++] = topLeft;

        arrverticle[vert++] = topLeft;
        arrverticle[vert++] = topCenter;
        arrverticle[vert++] = bottomCenter;

        //right side of the sensor
        arrverticle[vert++] = bottomCenter;
        arrverticle[vert++] = topCenter;
        arrverticle[vert++] = topRight;

        arrverticle[vert++] = topRight;
        arrverticle[vert++] = bottomRight;
        arrverticle[vert++] = bottomCenter;

        float currentangle = -angle;
        float deltaAngle = (angle * 2) / segment;

        //in a loop to make the sensor more circular
        for (int i = 0; i < segment; i++)
        {
            currentangle += deltaAngle;
            bottomLeft = Quaternion.Euler(0, currentangle, 0) * Vector3.forward * distance;
            bottomRight = Quaternion.Euler(0, currentangle + deltaAngle, 0) * Vector3.forward * distance;

            topRight = bottomRight + Vector3.up * height;
            topLeft = bottomLeft + Vector3.up * height;

            //front side of the sensor

            arrverticle[vert++] = bottomLeft;
            arrverticle[vert++] = bottomRight;
            arrverticle[vert++] = topRight;

            arrverticle[vert++] = topRight;
            arrverticle[vert++] = topLeft;
            arrverticle[vert++] = bottomLeft;

            //top side of the sensor
            arrverticle[vert++] = topCenter;
            arrverticle[vert++] = topLeft;
            arrverticle[vert++] = topRight;

            //bottom side of the sensor
            arrverticle[vert++] = bottomCenter;
            arrverticle[vert++] = bottomLeft;
            arrverticle[vert++] = bottomRight;
        }

        // creates the mesh of the sensor

        for (int i = 0; i < numVerticles; i++)
        {
            arrtriangle[i] = i;
        }

        mesh.vertices = arrverticle;
        mesh.triangles = arrtriangle;
        mesh.RecalculateNormals();
        return mesh;
    }

    private void OnValidate()
    {
        mesh = CreateSensorMesh();
    }

    // it creates the tools to see the sensor in the scene (not in the game)
    private void OnDrawGizmos()
    {
        if (mesh)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawMesh(mesh, transform.position, transform.rotation);
        }

        Gizmos.DrawWireSphere(transform.position, distance);
        for (int i = 0; i < count; i++)
        {
            Gizmos.DrawSphere(colliders[i].transform.position, 0.2f);
        }
    }
}

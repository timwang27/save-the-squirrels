using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class AcornSpawner : MonoBehaviour
{
    public PlaneSurfaceManager PlaneSurfaceManager;
    public GameObject PackagePrefab;

    public static Vector3 RandomInTriangle(Vector3 v1, Vector3 v2)
    {
        float u = Random.Range(0.0f, 1.0f);
        float v = Random.Range(0.0f, 1.0f);
        if (v + u > 1)
        {
            v = 1 - v;
            u = 1 - u;
        }

        return (v1 * u) + (v2 * v);
    }

    public static Vector3 FindRandomLocation(ARPlane plane)
    {
        // Select random triangle in Mesh
        var mesh = plane.GetComponent<ARPlaneMeshVisualizer>().mesh;
        var triangles = mesh.triangles;
        var triangle = triangles[(int)Random.Range(0, triangles.Length - 1)] / 3 * 3;
        var vertices = mesh.vertices;
        var randomInTriangle = RandomInTriangle(vertices[triangle], vertices[triangle + 1]);
        var randomPoint = plane.transform.TransformPoint(randomInTriangle);

        return randomPoint;
    }

    public void Spawn(ARPlane plane)
    {
        var acornClone = GameObject.Instantiate(PackagePrefab);
        acornClone.transform.position = FindRandomLocation(plane);
    }


    private void Start()
    {
        InvokeRepeating("SpawnAcorn", 2, 1);
    }

    public void SpawnAcorn()
    {
        var lockedPlane = PlaneSurfaceManager.LockedPlane;
        if (lockedPlane != null)
        {
            Spawn(lockedPlane);
        }
    }
}

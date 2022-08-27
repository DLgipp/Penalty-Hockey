using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trajectory : MonoBehaviour
{
    private LineRenderer lr;
    // Start is called before the first frame update
    void Start()
    {
        lr = GetComponent<LineRenderer>(); 
    }

    // Update is called once per frame
    public void ShowTrajectory(Vector3 start, Vector3 speed)
    {
        Vector3[] points = new Vector3[10];
        lr.positionCount = points.Length;
        
        for (int i = 0; i < points.Length; i++)
        {
            float time = i * 0.1f;

            points[i] = start + speed * time;
        }
        lr.SetPositions(points);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TetrisGrid : MonoBehaviour
{
    [SerializeField] int width = 10;
    [SerializeField] int height = 20;

    public Transform[,] grid;

    void Awake()
    {
        grid = new Transform[width, height];
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.grey;
        Vector3 origin = transform.position + new Vector3(-0.5f, -0.5f, 0f);

        for (int x = 0; x <= width; x++)
        {
            Vector3 start = origin + new Vector3(x, 0, 0);
            Vector3 end = origin + new Vector3(x, height, 0);
            Gizmos.DrawLine(start, end);
        }

        for (int y = 0; y <= height; y++)
        {
            Vector3 start = origin + new Vector3(0, y, 0);
            Vector3 end = origin + new Vector3(width, y, 0);
            Gizmos.DrawLine(start, end);
        }
    }
}

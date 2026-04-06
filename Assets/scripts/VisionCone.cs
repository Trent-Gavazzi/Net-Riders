using UnityEngine;

[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
public class VisionCone: MonoBehaviour
{
    [Header("Vision Settings")]
    public float viewAngle = 45f;
    public float viewDistance = 8f;
    public int rayCount = 40;
    public LayerMask obstacleMask;
    public float updateInterval = 0.05f;

    Mesh mesh;
    Vector3[] vertices;
    int[] triangles;

    float lastUpdateTime;
    Vector3 lastPos;
    Quaternion lastRot;

    void Start()
    {
        mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;

        vertices = new Vector3[rayCount + 2];
        triangles = new int[rayCount * 3];
    }

    void LateUpdate()
    {
        if (Time.time - lastUpdateTime < updateInterval &&
            transform.position == lastPos &&
            transform.rotation == lastRot)
            return;

        lastUpdateTime = Time.time;
        lastPos = transform.position;
        lastRot = transform.rotation;

        GenerateCone();
    }

    void GenerateCone()
    {
        vertices[0] = Vector3.zero;

        float angleStep = viewAngle / rayCount;
        float startAngle = -viewAngle / 2f;

        for (int i = 0; i <= rayCount; i++)
        {
            float angle = startAngle + angleStep * i;
            Vector3 dir = DirFromAngle(angle);

            if (Physics.Raycast(transform.position, transform.TransformDirection(dir),
                                out RaycastHit hit, viewDistance, obstacleMask))
            {
                vertices[i + 1] = transform.InverseTransformPoint(hit.point);
            }
            else
            {
                vertices[i + 1] = dir * viewDistance;
            }
        }

        int triIndex = 0;
        for (int i = 0; i < rayCount; i++)
        {
            triangles[triIndex++] = 0;
            triangles[triIndex++] = i + 1;
            triangles[triIndex++] = i + 2;
        }

        mesh.Clear();
        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.RecalculateNormals();
    }

    Vector3 DirFromAngle(float angle)
    {
        float rad = angle * Mathf.Deg2Rad;
        return new Vector3(Mathf.Sin(rad), 0, Mathf.Cos(rad));
    }
}
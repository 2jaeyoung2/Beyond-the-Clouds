using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGeneratorManager : MonoBehaviour
{
    [Header("Map Settings"), Space(10)]
    public int width = 20;

    public int height = 20;

    public float cellSize = 2f;

    [Header("Obstacle Settings"), Space(10)]
    public GameObject obstaclePrefab;

    public int obstacleCount = 30;

    public int seed;

    [Header("Variation Settings"), Space(10)]
    public Vector2 scaleRange = new Vector2(0.8f, 1.2f);

    private HashSet<Vector2Int> occupied = new HashSet<Vector2Int>();

    void Start()
    {
        seed = Random.Range(00000, 99999);

        GenerateMap();
    }

    void GenerateMap()
    {
        Random.InitState(seed);

        for (int i = 0; i < obstacleCount; i++)
        {
            // 1��и� ������ ���� ����
            int x = Random.Range(0, width / 2);
            int z = Random.Range(0, height / 2);
            Vector2Int originalPos = new Vector2Int(x, z);

            if (occupied.Contains(originalPos)) continue;

            // ���� ȸ�� & ������
            Quaternion randomRotation = Quaternion.Euler(0, Random.Range(0f, 360f), 0);
            float randomScale = Random.Range(scaleRange.x, scaleRange.y);

            // ��Ī ��ǥ �迭 (���� ����)
            Vector2Int[] points = new Vector2Int[]
            {
                originalPos,                // 1��и�
                new Vector2Int(-x, z),      // 2��и� (X�� ��Ī)
                new Vector2Int(x, -z),      // 4��и� (Z�� ��Ī)
                new Vector2Int(-x, -z)      // 3��и� (X+Z ��Ī)
            };

            foreach (var p in points)
            {
                CreateObstacle(p, randomRotation, randomScale);
            }
        }
    }

    void CreateObstacle(Vector2Int pos, Quaternion rotation, float scale)
    {
        if (occupied.Contains(pos)) return;

        Vector3 worldPos = new Vector3(pos.x * cellSize, 0, pos.y * cellSize);
        GameObject obj = Instantiate(obstaclePrefab, worldPos, rotation, transform);
        obj.transform.localScale *= scale;

        occupied.Add(pos);
    }
}

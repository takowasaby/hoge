using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockManager : MonoBehaviour
{
    [SerializeField]
    private GameObject block;

    private List<Vector2Int> gridMap = new List<Vector2Int>()
    {
        new Vector2Int(1, 2),
        new Vector2Int(1, 3),
        new Vector2Int(3, 2),
        new Vector2Int(2, 2),
        new Vector2Int(3, 3),
        new Vector2Int(0, 3),
        new Vector2Int(-1, 2),
        new Vector2Int(-2, 3),
    };

    private List<float> gridRotations = new List<float>()
    {
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        90,
    };

    void Start()
    {
        for(int i = 0; i < gridMap.Count; i++)
        {
            Instantiate(block, GridManager.GridIndexToPosition(gridMap[i].x, gridMap[i].y), Quaternion.Euler(0, 0, gridRotations[i]), transform);
        }
    }
}

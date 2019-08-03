using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    static float gridInterval = 0.5f;
    static Vector2 leftUp = new Vector2(-1.75f, 2.25f);

    static public Vector2 GridIndexToPosition(int x, int y)
    {
        return leftUp + gridInterval * new Vector2(x, -y);
    }
}

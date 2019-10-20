using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class EditorSnap : MonoBehaviour
{
    [Range(1,20)] [SerializeField] float gridSize = 10;

    // Update is called once per frame
    void Update()
    {
        Vector3 snapPos;
        snapPos.x = Mathf.RoundToInt(transform.position.x / gridSize) * gridSize;
        snapPos.y = 0;
        snapPos.z = Mathf.RoundToInt(transform.position.z / gridSize) * gridSize;

        transform.position = snapPos;
    }
}

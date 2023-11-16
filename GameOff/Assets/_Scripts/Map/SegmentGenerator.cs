using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SegmentGenerator : MonoBehaviour
{
    public GameObject mapSegmentPrefab;
    public Vector2 offSet;
    public Vector2 initialShift;
    public Sprite[] mapSprites;
    private const int length = 7;
    private const int width = 7;
    // Start is called before the first frame update
    void Start()
    {
        GenerateMapSegments();
    }

    // Update is called once per frame
    private void GenerateMapSegments(){
        for(int i = 0; i < length; i++){
            for(int j = 0; j < width; j++){
                var Segment = Instantiate(mapSegmentPrefab, new Vector3(i*offSet.x + initialShift.x, j*offSet.y + initialShift.y, 0), Quaternion.identity, transform);
                Segment.name = "segment: " + i + "-" + j;
            }
        }
    }
}

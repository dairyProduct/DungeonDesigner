using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapCompiler : MonoBehaviour
{
    private List<GameObject> map = new List<GameObject>();


    /// <summary>
    /// returns array of map segments in order. 
    /// can be used to generate map/check map properties
    /// </summary>
    /// <param name="segmentHolder"></param>
    /// <returns></returns>
    private List<GameObject> CompileMapArray(Transform segmentHolder){
        
        for(int i = 0; i < segmentHolder.childCount; i++){
            GameObject segment = segmentHolder.GetChild(i).gameObject;
            map.Add(segment);
        }
        return map;
    }
}

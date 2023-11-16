using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IconSwapper : MonoBehaviour
{
    
    public SpriteRenderer targetRenderer;
    public SegmentHover segmentHover;
    public GameObject iconSelectedEffect;
    private Sprite mySprite;

    private void Start(){
        mySprite = GetComponent<SpriteRenderer>().sprite;
    }
    private void OnMouseDown(){
        if(Input.GetMouseButtonDown(0)){
            targetRenderer.sprite = mySprite;
            segmentHover.EndSelection();
            Instantiate(iconSelectedEffect, targetRenderer.transform);
        }
        else if(Input.GetMouseButtonDown(1)){
            targetRenderer.sprite = null;
            segmentHover.EndSelection();
            Instantiate(iconSelectedEffect, targetRenderer.transform);
        }
    }
}

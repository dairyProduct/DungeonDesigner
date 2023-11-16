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
        
        targetRenderer.sprite = mySprite;
        segmentHover.EndSelection();
        GameObject effect = Instantiate(iconSelectedEffect, targetRenderer.transform);
        //segmentHover.gameObject.GetComponent<SpriteRenderer>().enabled = false;
    }
}

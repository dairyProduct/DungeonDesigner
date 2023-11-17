using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class IconSwapper : MonoBehaviour
{
    
    public SpriteRenderer targetRenderer;
    public SegmentHover segmentHover;
    public GameObject iconSelectedEffect;
    private Sprite mySprite;
    private Light2D iconLight;
    private Animator iconAnimator;
    private SpriteRenderer myRenderer;
    private Animator mapAnimator;

    private void Start(){
        iconLight = GetComponent<Light2D>();
        myRenderer = GetComponent<SpriteRenderer>();
        mySprite = myRenderer.sprite;
        iconAnimator = GetComponent<Animator>();
        mapAnimator = GameObject.Find("Map").GetComponent<Animator>();
    }
    private void OnMouseOver(){
        iconLight.enabled = true;
        iconAnimator.SetBool("IsHovering", true);
        myRenderer.sortingOrder = 7;
    }
    private void OnMouseExit(){
        iconLight.enabled = false;
        iconAnimator.SetBool("IsHovering", false);
        myRenderer.sortingOrder = 6;
    }
    private void OnMouseDown(){
        if(Input.GetMouseButtonDown(0)){
            targetRenderer.sprite = mySprite;
            segmentHover.EndSelection();
            Instantiate(iconSelectedEffect, targetRenderer.transform);
            mapAnimator.SetTrigger("ItemPlaced");
        }
        else if(Input.GetMouseButtonDown(1)){
            targetRenderer.sprite = null;
            segmentHover.EndSelection();
            Instantiate(iconSelectedEffect, targetRenderer.transform);
            
        }
    }
}

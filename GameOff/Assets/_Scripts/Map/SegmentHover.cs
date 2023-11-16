using System.Collections;
using System.Collections.Generic;
using MoreMountains.Feedbacks;
using MoreMountains.Tools;
using UnityEngine;
public class SegmentHover : MonoBehaviour
{
    
    public Sprite lockedInSprite, hoverSprite;
    public Animator iconAnimator;


    private SpriteRenderer mySpriteRenderer;
    private GameObject myLight;
    private Transform segmentsHolder;
    private float flashTimer = 0.5f;
    private bool isHovering = false;


    private void Start(){
        segmentsHolder = transform.parent.parent;
        mySpriteRenderer = GetComponent<SpriteRenderer>();
        myLight = transform.GetChild(0).gameObject;
    }


    private void OnMouseOver(){
        if(isHovering) return;
        mySpriteRenderer.enabled = true;
        myLight.SetActive(true);
    }

    private void OnMouseExit(){
        if(isHovering) return;
        mySpriteRenderer.enabled = false;
        myLight.SetActive(false);
    }



    private void OnMouseDown(){
        if(Input.GetMouseButtonDown(0)){
            isHovering = mySpriteRenderer.sprite == hoverSprite;
            if(isHovering){
                StartSelection();
            }
            else{
                EndSelection();
            }
            
        }
    }

    public void StartSelection(){
        isHovering = mySpriteRenderer.sprite == hoverSprite;
        mySpriteRenderer.sprite = lockedInSprite;
        //selectIcon.GetComponent<MMFeedbacks>().enabled = false;
        mySpriteRenderer.enabled = true;
        iconAnimator.SetBool("ShowingIcons", true);

        for(int i = 0; i < segmentsHolder.childCount; i++){

            GameObject segment = segmentsHolder.GetChild(i).GetChild(0).gameObject;
            if(segment == gameObject) continue;
            segment.SetActive(false);

        }
    }
    public void EndSelection(){
        isHovering = mySpriteRenderer.sprite == hoverSprite;
        mySpriteRenderer.sprite = hoverSprite;
        //selectIcon.GetComponent<MMFeedbacks>().enabled = true;
        //mySpriteRenderer.enabled = true;
        iconAnimator.SetBool("ShowingIcons", false);

        for(int i = 0; i < segmentsHolder.childCount; i++){

            GameObject segment = segmentsHolder.GetChild(i).GetChild(0).gameObject;
            if(segment == gameObject) continue;
            segment.SetActive(true);

        }
        myLight.SetActive(false);
        mySpriteRenderer.enabled = false;
    }
    
}

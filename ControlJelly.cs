using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlJelly : MonoBehaviour
{
    [Range(0,1)][SerializeField] private float jellyValue;
    private float mZCoord;
    private Vector3 mOffset;
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
    }

    void OnMouseDown()
    {
        mZCoord = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
        // Store offset = gameobject world pos - mouse world pos
        mOffset = gameObject.transform.position - GetMouseAsWorldPoint();
    }
    
    public float scale(float OldMin, float OldMax, float NewMin, float NewMax, float OldValue){
 
        float OldRange = (OldMax - OldMin);
        float NewRange = (NewMax - NewMin);
        float NewValue = (((OldValue - OldMin) * NewRange) / OldRange) + NewMin;
 
        return(NewValue);
    }
    
    private Vector3 GetMouseAsWorldPoint()
    {
        // Pixel coordinates of mouse (x,y)
        Vector3 mousePoint = Input.mousePosition;
        // z coordinate of game object on screen
        mousePoint.z = mZCoord;
        // Convert it to world points
        return Camera.main.ScreenToWorldPoint(mousePoint);
    }
    
    void OnMouseDrag()
    {
        // max size is 5 now
        float distance = Vector3.Distance(GetMouseAsWorldPoint(), transform.position);
        float mapDistance = scale(0, 0.137f, 0, 1, distance);
        _animator.SetFloat("Jelly", mapDistance);
    }
    
}

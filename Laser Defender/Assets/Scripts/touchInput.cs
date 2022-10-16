using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class touchInput : MonoBehaviour
{
    [SerializeField] float moveSpeed= 5f;
    Vector2 maxBounds;
    [SerializeField] float paddingLeft;
    [SerializeField] float paddingRight;
    [SerializeField] float paddingTop;
    [SerializeField] float paddingBottom;
    public Joystick joystick;
    Vector2 minBounds;
    

   
    void Update()
    {
        Move();
    }
    void Move()
    {
        float deltax = joystick.Horizontal * moveSpeed * Time.deltaTime;
        Vector2 newPos = new Vector2();
        newPos.x = Mathf.Clamp(transform.position.x+deltax,minBounds.x + paddingLeft,maxBounds.x - paddingRight);
        // newPos.y = Mathf.Clamp(transform.position.y + deltax,minBounds.y + paddingBottom,maxBounds.y - paddingTop);
        transform.position = newPos;
    }
}

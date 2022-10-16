using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class Player : MonoBehaviour
{
    Vector2 rawInput ;
    [SerializeField] float moveSpeed= 5f;
    Vector2 minBounds;
    Vector2 maxBounds;
    [SerializeField] float paddingLeft;
    [SerializeField] float paddingRight;
    [SerializeField] float paddingTop;
    [SerializeField] float paddingBottom;
    private LaserDefender playerInput;
    float deltaX,deltaY;
    Rigidbody2D rb;
    
    Shooter shooter;

    void Awake() 
    {
        shooter = GetComponent<Shooter>(); 
        playerInput = new LaserDefender();
        rb = GetComponent<Rigidbody2D>();   
    }
    void OnEnable()
    {
        playerInput.Enable();
    }
    void OnDisable()
    {
        playerInput.Disable();
    }

    void Start() 
    {
        InitBounds();   
    }
   
    void Update()
    {
        Move();
        Fire();
        

    }
    void InitBounds()
    {
        Camera mainCamera = Camera.main;
        minBounds = mainCamera.ViewportToWorldPoint(new Vector2(0,0));
        maxBounds = mainCamera.ViewportToWorldPoint(new Vector2(1,1));
    }

    void Move()
    {
        // Vector2 delta = playerInput.Player.Move.ReadValue<Vector2>() * moveSpeed * Time.deltaTime;
        // // Vector2 delta = rawInput * moveSpeed * Time.deltaTime;
        
        // transform.position = newPos;
        if(Input.touchCount>0)
        {
            Touch touch = Input.GetTouch(0);
            Vector2 touchPos = Camera.main.ScreenToWorldPoint(touch.position);
            
            switch(touch.phase)
            {
                case UnityEngine.TouchPhase.Began:
                    deltaX=touchPos.x-transform.position.x;
                    deltaY=touchPos.y-transform.position.y;
                    Fire();
                    break;
                case UnityEngine.TouchPhase.Moved:
                    Vector2 newPos = new Vector2();
                     newPos.x = Mathf.Clamp(touchPos.x-deltaX,minBounds.x + paddingLeft,maxBounds.x - paddingRight);
                    newPos.y = Mathf.Clamp(touchPos.y-deltaY,minBounds.y + paddingBottom,maxBounds.y - paddingTop);
                    rb.MovePosition(new(newPos.x,newPos.y));
                    Fire();
                    
                    break;
                case UnityEngine.TouchPhase.Ended:
                    rb.velocity=Vector2.zero;
                    break;
            }
        }
    }

    void OnMove(InputValue value)
    {
        rawInput = value.Get<Vector2>();
        
    }
    
    void Fire()
    {
        if(shooter != null)
        {
            shooter.isFiring = playerInput.Player.Shoot.IsPressed();
        }
        
    }
}

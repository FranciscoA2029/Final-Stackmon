using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;


public class FTA_CardBaseScript : MonoBehaviour
{
    private static FTA_CardBaseScript currentlyDraggedCard = null;
    private Rigidbody2D myBody;
    private BoxCollider2D myBox;
    
    private string identity;
    private Vector2 dragOffset;
    
    public enum CardType {
        Stackmon,
        Berry,
        Station, 
    }

    int layer;

    InputAction holdCard;

    Vector2 mouseWorldPos;
    Vector2 mouseScreenPos;
    
        
    protected virtual void Start()
    {
        UpdateMousePosition();
        holdCard = InputSystem.actions.FindAction("Hold");
        myBody = this.GetComponent<Rigidbody2D>();
        myBox = this.GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        UpdateMousePosition();

        CheckCardMovement();
    }

    void UpdateMousePosition()
    {
        //mouseScreenPosition = Input.mousePosition;
        mouseScreenPos = Mouse.current.position.ReadValue(); // Raw PC screen pixels (e.g., 960, 540)
        mouseWorldPos = Camera.main.ScreenToWorldPoint(mouseScreenPos); // Converted to game world units (e.g., 0, 0)
        //mouseWorldPos.z = 0;
        
        
    }
    void MoveWithCard()
    {
        GetComponent<Rigidbody2D>().transform.position = mouseWorldPos;
        
    }

    void CheckCardMovement()
    {
        // if (mouseWorldPos.x - myBody.transform.position.x <= 50
        //     && mouseWorldPos.y - myBody.transform.position.y <= 50
        //     && holdCard.IsPressed())
        // {
        //     MoveWithCard();
        // }
        //
        // if (holdCard.WasReleasedThisFrame())
        // {
        //     Debug.Log("Tried to stack!");
        // }
        
        
        // 1. On Click: Only claim the drag if NO card is currently dragged AND the click hit THIS specific card's collider
        if (Mouse.current.leftButton.wasPressedThisFrame && currentlyDraggedCard == null)
        {
            Collider2D hitCollider = Physics2D.OverlapPoint(mouseWorldPos);

            // Strict check: ensures this exact card's BoxCollider2D was the one hit
            if (hitCollider != null && hitCollider == myBox)
            {
                currentlyDraggedCard = this;
                dragOffset = (Vector2)transform.position - mouseWorldPos;
            }
        }

        // 2. On Hold: ONLY move if THIS exact instance is the currentlyDraggedCard
        if (Mouse.current.leftButton.isPressed && currentlyDraggedCard == this)
        {
            transform.position = mouseWorldPos + dragOffset;
            myBody.simulated = false;
        }

        // 3. On Release: Clear the active card slot
        if (Mouse.current.leftButton.wasReleasedThisFrame && currentlyDraggedCard == this)
        {
            currentlyDraggedCard = null;
            myBody.simulated = true;
        }
    }
}

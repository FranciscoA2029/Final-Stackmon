using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections.Generic;
using UnityEngine.SceneManagement;


public class FTA_CardBaseScript : MonoBehaviour
{
    private static FTA_CardBaseScript currentlyDraggedCard = null;
    //private Rigidbody2D myBody;
    private BoxCollider2D myBox;

    private List<Collider2D> hitResults = new List<Collider2D>();
    
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
        string identity = null;
        UpdateMousePosition();
        holdCard = InputSystem.actions.FindAction("Hold");
        //myBody = this.GetComponent<Rigidbody2D>();
        myBox = this.GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        UpdateMousePosition();

        CheckCardMovement();
        
        checkSelfCollision();
    }

    void UpdateMousePosition()
    {
        mouseScreenPos = Mouse.current.position.ReadValue(); // Raw PC screen pixels (e.g., 960, 540)
        mouseWorldPos = Camera.main.ScreenToWorldPoint(mouseScreenPos); // Converted to game world units (e.g., 0, 0)
        //mouseWorldPos.z = 0;
    }
    void MoveWithCard()
    {
        this.transform.position = mouseWorldPos;
        
    }

    void CheckCardMovement()
    {

        if (Mouse.current.leftButton.wasPressedThisFrame && currentlyDraggedCard == null)
        {
            Collider2D hitCollider = Physics2D.OverlapPoint(mouseWorldPos);

           // Makes sure that it's this card's collier that was hit.
            if (hitCollider != null && hitCollider == myBox)
            {
                currentlyDraggedCard = this;
                dragOffset = (Vector2)transform.position - mouseWorldPos;
            }
        }

        if (Mouse.current.leftButton.isPressed && currentlyDraggedCard == this)
        {
            transform.position = mouseWorldPos + dragOffset;
            //myBody.simulated = false;
        }

        if (Mouse.current.leftButton.wasReleasedThisFrame && currentlyDraggedCard == this)
        {
            currentlyDraggedCard = null;
            //myBody.simulated = true;
        }
        
        checkOtherCards();
    }

    void checkOtherCards()
    {
        if (currentlyDraggedCard == this)
        {
            int hitCount = myBox.Overlap(ContactFilter2D.noFilter, hitResults);
            for (int i = 0; i < hitCount; i++)
            {
                if (hitResults[i].TryGetComponent(out FTA_CardBaseScript otherCard))
                {
                    //Debug.Log("Overlapped other cards");
                    //comment: use checkAlly and change Class in Filter to stackmon script in order 
                    //to determine if other card is ally or foe
                    otherCard.GetComponent<SpriteRenderer>().color = Color.darkRed;
                }
            }
        }
    }

    void checkSelfCollision()
    {
        int hitCount = myBox.Overlap(ContactFilter2D.noFilter, hitResults);
        if (hitCount == 0)
        {
            GetComponent<SpriteRenderer>().color = Color.white;
        }
    }
}

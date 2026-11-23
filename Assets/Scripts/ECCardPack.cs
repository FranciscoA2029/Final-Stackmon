using UnityEngine;
using UnityEngine.InputSystem;

public class CardPack : MonoBehaviour
{
    Vector2 WorldMousePos;
    Vector2 ScreenMousePos;

    [SerializeField] int NumOfCards;
    [SerializeField] GameObject Card;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        WorldMousePos = Mouse.current.position.ReadValue();
        ScreenMousePos = Camera.main.ScreenToWorldPoint(WorldMousePos);

        if (Mouse.current.rightButton.wasPressedThisFrame)
        {
            Debug.Log("Pressed Right Click");
            Collider2D hitCollider = Physics2D.OverlapPoint(ScreenMousePos);
            if (hitCollider != null)
            {
                Debug.Log("open cardpack");
                for (int i = 0; i < NumOfCards; i++)
                {
                    spawnCard();
                }
                Destroy(this.gameObject);
            }
        }
        
    }

    void spawnCard()
    {
        Instantiate(Card, new Vector3(Random.Range(transform.position.x-2, transform.position.x+2),
            Random.Range(transform.position.y-2, transform.position.y+2),0), Quaternion.identity);
    }
    
    
}

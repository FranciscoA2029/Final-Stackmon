using UnityEngine;
using UnityEngine.InputSystem;

public class CardPack : MonoBehaviour
{
    Vector2 WorldMousePos;
    Vector2 ScreenMousePos;

    [SerializeField] int NumOfCards;
    [SerializeField] FTA_CardBaseScript Card;
    [SerializeField] FTA_CardBaseScript AllyCard;
    [SerializeField] FTA_CardBaseScript EnemyCard;
    
    private GameManager gameManager;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameManager = FindFirstObjectByType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        WorldMousePos = Mouse.current.position.ReadValue();
        ScreenMousePos = Camera.main.ScreenToWorldPoint(WorldMousePos);

        if (Mouse.current.rightButton.wasPressedThisFrame)
        {
            //Debug.Log("Pressed Right Click");
            Collider2D hitCollider = Physics2D.OverlapPoint(ScreenMousePos);
            if (hitCollider != null && hitCollider == this.GetComponent<BoxCollider2D>())
            {
                //Debug.Log(hitCollider.name);
                {
                    //Debug.Log("open cardpack");
                    // for (int i = 0; i < NumOfCards; i++)
                    // {
                    //     this.spawnCard();
                    // }
                    spawnCard();
                    Destroy(this.gameObject);
                }
            }
        }
        
    }



    void spawnCard()
    {
        // gameManager.AddCard(Instantiate(Card, new Vector3(Random.Range(transform.position.x-2, transform.position.x+2),
        //     Random.Range(transform.position.y-2, transform.position.y+2),0), Quaternion.identity));

        Instantiate(AllyCard, new Vector3(Random.Range(transform.position.x - 2, transform.position.x + 2),
            Random.Range(transform.position.y - 2, transform.position.y + 2), 0), Quaternion.identity);
        Instantiate(AllyCard, new Vector3(Random.Range(transform.position.x - 2, transform.position.x + 2),
            Random.Range(transform.position.y - 2, transform.position.y + 2), 0), Quaternion.identity);
        Instantiate(EnemyCard, new Vector3(Random.Range(transform.position.x - 2, transform.position.x + 2),
            Random.Range(transform.position.y - 2, transform.position.y + 2), 0), Quaternion.identity);

    }
    
    
}

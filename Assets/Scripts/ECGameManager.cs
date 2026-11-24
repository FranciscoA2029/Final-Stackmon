using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using System.Collections.Generic;


public class GameManager : MonoBehaviour
{
    private PlayerInput _playerInput;
    Vector2 WorldMousePos;
    Vector2 ScreenMousePos;
    [SerializeField] CardPack _cardPack;
    private List<CardPack> _cardPacks;
    private List<FTA_CardBaseScript> _cards;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _playerInput = GetComponent<PlayerInput>();
        _cardPacks = new  List<CardPack>();
        _cards = new List<FTA_CardBaseScript>();

    }

    // Update is called once per frame
    void Update()
    {
        WorldMousePos = Mouse.current.position.ReadValue();
        ScreenMousePos = Camera.main.ScreenToWorldPoint(WorldMousePos);
        
        if (_playerInput.actions["Restart"].triggered)
        {
            Debug.Log("restarting");
            RestartLevel();
        }

        if (_playerInput.actions["Spawn"].triggered)
        {
            //Debug.Log("X: " + ScreenMousePos.x + ", Y: " + ScreenMousePos.y);
            SpawnCardPack();
        }

        // if (Keyboard.current.rKey.wasPressedThisFrame)
        // {
        //     
        // }
    }

    void SpawnCardPack()
    {
        _cardPacks.Add(Instantiate(_cardPack, new Vector3(ScreenMousePos.x, ScreenMousePos.y, 0), Quaternion.identity));
        Debug.Log(_cardPacks.Count);
    }

    public void AddCard(FTA_CardBaseScript card)
    {
        _cards.Add(card);
        Debug.Log(_cards.Count);
    }

    void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    
    
}

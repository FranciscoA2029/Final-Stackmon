using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public PlayerInput _playerInput;
    Vector2 WorldMousePos;
    Vector2 ScreenMousePos;
    [SerializeField] GameObject CardPack;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _playerInput = GetComponent<PlayerInput>();
        
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
        Instantiate(CardPack, new Vector3(ScreenMousePos.x, ScreenMousePos.y, 0), Quaternion.identity);
    }

    void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}

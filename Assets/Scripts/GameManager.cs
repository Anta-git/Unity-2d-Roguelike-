using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Singleton instance of GameManager 
    // This allows other classes to access the GameManager instance
    // without needing to find it in the scene
    public static GameManager Instance { get; private set; }

    public BoardManager boardManager;
    public PlayerController playerController;
    public TurnManager turnManager { get; private set; }

    private void Awake()
    {
        // Check if an instance of GameManager already exists
        if (Instance == null)
        {
            Instance = this; // Set the instance to this GameManager
            DontDestroyOnLoad(gameObject); // Prevent this GameManager from being destroyed when loading new scenes
        }
        else
        {
            Destroy(gameObject); // Destroy this GameManager if another one already exists
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        turnManager = new TurnManager();
        boardManager.Initialize();
        playerController.Spawn(boardManager, new Vector2Int(1, 1));

    }
}

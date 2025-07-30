using UnityEngine;
using UnityEngine.Events;

public class GameEvent : MonoBehaviour
{
    public UnityAction<float> EventTimeUpdate;
    public static GameEvent _instance;
    public static GameEvent Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindAnyObjectByType<GameEvent>();
            }
            return _instance;
        }
    }

    private void Awake()
    {
        if (_instance != null)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }
}


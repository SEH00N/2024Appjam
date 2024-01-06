using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance = null;
    public static GameManager Instance {
        get {
            if(instance == null)
                instance = FindObjectOfType<GameManager>();
            return instance;
        }
    }

    public AudioSource Aud;

    private void Awake()
    {
        if(instance != null)
        {
            DestroyImmediate(gameObject);
            return;
        }

        Aud = GetComponent<AudioSource>();

        DontDestroyOnLoad(gameObject);
        instance = this;

        SceneLoader.Instance = new SceneLoader();
    }
}

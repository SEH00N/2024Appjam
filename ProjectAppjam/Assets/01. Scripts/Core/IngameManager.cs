using Unity.VisualScripting;
using UnityEngine;

public class IngameManager : MonoBehaviour
{
	private static IngameManager instance;
    public static IngameManager Instance {
        get {
            if(instance == null)
                instance = FindObjectOfType<IngameManager>();
            return instance;
        }
    }

    private PlayerStat playerStat = null;
    public PlayerStat PlayerStat {
        get {
            if(playerStat == null)
                playerStat = GameObject.Find("Player").GetComponent<PlayerStat>();
            return playerStat;
        }
    }
}

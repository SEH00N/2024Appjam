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

    private Player player = null;
    public Player Player {
        get {
            if(player == null)
                player = GameObject.Find("Player").GetComponent<Player>();
            return player;
        }
    }

    private PlayerStat playerStat = null;
    public PlayerStat PlayerStat {
        get {
            if(playerStat == null)
                playerStat = Player.GetComponent<PlayerStat>();
            return playerStat;
        }
    }

    private PlayerSkill playerSkill = null;
    public PlayerSkill PlayerSkill {
        get {
            if(playerSkill == null)
                playerSkill = Player.GetComponent<PlayerSkill>();
            return playerSkill;
        }
    }

    private PlayerHealth playerHealth = null;
    public PlayerHealth PlayerHealth {
        get {
            if(playerHealth == null)
                playerHealth = Player.GetComponent<PlayerHealth>();
            return playerHealth;
        }
    }
}

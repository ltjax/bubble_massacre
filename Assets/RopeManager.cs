using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeManager : MonoBehaviour
{
    public GameObject ropePrefab;
    LevelScript levelScript;

    Dictionary<PlayerScript, List<GameObject>> ropesByPlayers = new Dictionary<PlayerScript, List<GameObject>>();

    // Start is called before the first frame update
    void Start()
    {
        levelScript = GameObject.Find("Level").GetComponent<LevelScript>();    
    }

    // Update is called once per frame
    void Update()
    {
        CheckRopes();
    }

    public void ShootRope(PlayerScript player)
    {
        if (!ropesByPlayers.ContainsKey(player))
        {
            ropesByPlayers[player] = new List<GameObject>();
        }

        var playerRopes = ropesByPlayers[player];
        if (playerRopes.Count < player.maxRopes)
        {
            var rope = Instantiate(ropePrefab, player.transform.position, Quaternion.identity);
            playerRopes.Add(rope);
        }
    }

    private void CheckRopes()
    {
        foreach (var ropes in ropesByPlayers.Values) 
        {
            ropes.RemoveAll(rope =>
            {
                var ropeScript = rope.GetComponent<RopeScript>();
                if (levelScript.DoesRopeCollide(rope.transform.position, ropeScript.GetCurrentLength()))
                {
                    Destroy(rope);
                    return true;
                }
                return false;
            });

        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HighScoreManager : MonoBehaviour
{
    [SerializeField] GameObject inputField;
    List<Rank> rankings = new List<Rank>(); 
    private int places = 10;
    private string playerName;
    private int playerScore;

    void Start() {
        InitialiseRankings();
    }

    public bool CheckScore(int score) {
        playerScore = score;
        var ranks = false;
        /* if score is higher than any of the playerpref values... */
        foreach (Rank r in rankings) {
            if (score > r.score) {
                ranks = true;
            }
        }
        return ranks;
    }

    public void AddPlayerToRanks() {
        playerName = inputField.GetComponent<TMP_InputField>().text;
        Rank newRank = new Rank(playerName, playerScore);

        /* Now we need to add this player to the ranks
         * Sort the ranks list
         * Get the index of the player in the list
         * PlayerPrefs.SetString("ranks " + index, name) 
         * PlayerPrefs.SetInt("ranks " + index, score)
         * Pop last (11th) time item off the end of the list
         */
    } 

    private void InitialiseRankings() {
        /* Fill Rank array with playerpref values */
        for (int i = 0; i < places; i++) {
            var rankname = "rank" + i.ToString();
            rankings.Add(new Rank(PlayerPrefs.GetString(rankname, "----"),
                PlayerPrefs.GetInt(rankname, 0)));
        }
    }
}

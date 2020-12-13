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
        if (playerName=="") {
            Debug.LogWarning("Text box empty!");
            return;
        }
        Rank newRank = new Rank(playerName, playerScore);
        /* Add new rank to list */
        rankings.Add(newRank);
        /* Sort based on score */
        rankings.Sort(SortRanks);
        /* Remove 11th item from list */
        rankings.RemoveAt(10);
        /* Get index of newRank in list */
        int index = rankings.IndexOf(newRank);
        /* Add rank to PlayerPrefs leaderboard */
        AddPlayerToLeaderBoard(index, newRank);
    } 

    private void AddPlayerToLeaderBoard(int index, Rank rank) {
        PlayerPrefs.SetString("rank" + index.ToString() + "Name", rank.name);
        PlayerPrefs.SetInt("rank" + index.ToString() + "Score", rank.score);
    }

    private int SortRanks(Rank a, Rank b) {
        if (a.score < b.score) {
            return 1;
        } else if (a.score > b.score) {
            return -1;
        }
        return 0;
    }

    private void InitialiseRankings() {
        /* Fill Rank array with playerpref values */
        for (int i = 0; i < places; i++) {
            var rankname = "rank" + i.ToString();
            rankings.Add(new Rank(PlayerPrefs.GetString(rankname + "Name", "----"),
                PlayerPrefs.GetInt(rankname + "Score", 0)));
        }
    }
}

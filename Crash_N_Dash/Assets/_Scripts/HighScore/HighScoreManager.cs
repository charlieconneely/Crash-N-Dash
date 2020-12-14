using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HighScoreManager : MonoBehaviour
{
    [SerializeField] GameObject inputField;
    [SerializeField] GameObject enterButton;
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
        FindObjectOfType<AudioManager>().Play("Click");
        /* Disable button */
        enterButton.GetComponent<Button>().interactable = false;
        Rank newRank = new Rank(playerName, playerScore);
        /* Add new rank to list */
        rankings.Add(newRank);
        /* Sort based on score */
        rankings.Sort(SortRanks);
        /* Remove 11th item from list */
        rankings.RemoveAt(10);
        /* Reinitialse PlayerPrefs vals with new list */
        ReInitialiseRankings();
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
        /* Fill Ranks list with playerpref values */
        for (int i = 0; i < places; i++) {
            var rankname = "rank" + i.ToString();
            rankings.Add(new Rank(PlayerPrefs.GetString(rankname + "Name", "----"),
                PlayerPrefs.GetInt(rankname + "Score", 0)));
        }
    }

    private void ReInitialiseRankings () {
        /* Update player prefs with new ranks list */
        for (int i = 0; i < places; i++) {
            PlayerPrefs.SetString("rank" + i.ToString() + "Name", rankings[i].name);
            PlayerPrefs.SetInt("rank" + i.ToString() + "Score", rankings[i].score);
        }
    }
}

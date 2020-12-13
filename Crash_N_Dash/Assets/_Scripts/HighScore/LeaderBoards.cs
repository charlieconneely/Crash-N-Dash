using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LeaderBoards : MonoBehaviour
{
    List<Rank> rankings = new List<Rank>(); 
    public List<TextMeshProUGUI> rankingsText;
    private int places = 10;

    void Start() {
        InitialiseRankings();
    }

    void Update() {
        OutputRankings();
    }

    public bool CheckScore(int score) {
        var ranks = false;
        /* if score is higher than any of the playerpref values... */
        foreach (Rank r in rankings) {
            if (score > r.score) {
                ranks = true;
            }
        }
        Debug.Log("Got to bottom of method");
        return ranks;
    }

    public void InitialiseRankings() {
        /* Fill Rank array with playerpref values */
        for (int i = 0; i < places; i++) {
            var rankname = "rank" + i.ToString();
            rankings.Add(new Rank(PlayerPrefs.GetString(rankname + "Name", "----"),
                PlayerPrefs.GetInt(rankname + "Score", 0)));
        }
    }

    private void OutputRankings() {
        var counter = 0;
        foreach(TextMeshProUGUI t in rankingsText) {
            t.text = (counter+1).ToString() + ". " + rankings[counter].name + " " + rankings[counter].score.ToString();
            counter++;
        }
    }
}

using UnityEngine;

[System.Serializable]
public class Rank
{
    public string name;
    public int score;

    public Rank (string n, int s) {
        this.name = n;
        this.score = s;
    }
}

using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    private static Animator animator;
    private static TextMeshProUGUI text;

    private static int score;
    private static int previousScore;

    public static int Score
    {
        get {return score;}
        set 
        {
            previousScore = score;
            score = value;
            UpdateScore();
        }
    }

    // Start is called before the first frame update
    void Start()
    { 
        text = GetComponent<TextMeshProUGUI>();
        animator = GetComponent<Animator>();
        previousScore = 0;
        Score = 0;
    }

    private static void UpdateScore()
    {
        text.text = score.ToString();

        //if (Score % 10 == 0 && Score > previousScore)
        //{
        //    animator.Play("PositiveTextAnimation");
        //}

        //if (Score % 10 == 0 && Score < previousScore)
        //{
        //    animator.Play("NegativeTextAnimation");
        //}

        //PlayerPrefs.SetInt("ScoreToUpdate", score);
    }

    public void OpenLeaderboard()
    {
        Social.ShowLeaderboardUI();
    }

    public void UpdateLeaderboard()
    {
        if(PlayerPrefs.GetInt("ScoreToUpdate", 0) == 0)
        {
            return;
        }

        //Social.ReportScore(PlayerPrefs.GetInt("ScoreToUpdate", 1), etherscapeIds.leaderboard_distance_travelled, (bool success) =>
        //{
        //    if(success)
        //    {
        //        PlayerPrefs.SetInt("ScoreToUpdate", 0);
        //    }
        //});
    }
}

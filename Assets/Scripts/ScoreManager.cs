using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    private int score;

    private float gold;
    private float silver;
    private float copper;
    private float emerald;
    private float diamond;

    private float goldMultiplier = 7;
    private float silverMultiplier = 3;
    private float copperMultiplier = 1;
    private float emeraldMultiplier = 10;
    private float diamondMultiplier = 20;

    public List<CollectablePropertiesStereo> collectedObjects;

    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
        {
            score = 0;
            gold = 0;
            silver = 0;
            copper = 0;
            emerald = 0;
            collectedObjects = new List<CollectablePropertiesStereo>();
            instance = this;
        }
        //else
        //{
        //    Destroy(gameObject);
        //}

        //if (SceneManager.GetActiveScene().name == "EndScene")
        //{
        //    TallyScore();
        //    return;
        //}

        StartCoroutine(CheckActiveScene());

        DontDestroyOnLoad(gameObject);
    }

    public void Add(CollectableProperties collectableProperties)
    {
        instance.collectedObjects.Add(new CollectablePropertiesStereo(collectableProperties));
    }
    public CollectablePropertiesStereo ReturnLastEntry()
    {
        return instance.collectedObjects[instance.collectedObjects.Count - 1];
    }
    public int FinalIndex()
    {
        return instance.collectedObjects.Count - 1;
    }

    private void TallyScore()
    {
        foreach (CollectablePropertiesStereo collectable in instance.collectedObjects)
        {
            instance.gold += collectable.goldQuantity;
            instance.silver += collectable.silverQuantity;
            instance.copper += collectable.copperQuantity;
            instance.emerald += collectable.emeraldQuantity;
            instance.diamond += collectable.diamondQuality;
        }
        float tempScore = (instance.gold * goldMultiplier) + (instance.silver * silverMultiplier) + (instance.copper * copperMultiplier) + (instance.emerald * emeraldMultiplier) + (instance.diamond * diamondMultiplier);
        instance.score = (int)tempScore;
        StartCoroutine(instance.CountQuantity());
    }

    public IEnumerator CountQuantity()
    {
        float tempGold = 0;
        float tempSilver = 0;
        float tempCopper = 0;
        float tempEmerald = 0;
        float tempDiamond = 0;
        int count = 0;

        float totalCountTime = 1.0f;
        float waitPeriod = totalCountTime / instance.collectedObjects.Count;
        //waitPeriod = waitPeriod > 0.1f ? 0.1f : waitPeriod;

        GameObject scoreTable = GameObject.Find("Score Table");
        GameObject scoreText = scoreTable.transform.GetChild(scoreTable.transform.childCount-1).gameObject;
        GameObject goldQuantityText = scoreTable.transform.GetChild(4).gameObject;
        GameObject silverQuantityText = scoreTable.transform.GetChild(7).gameObject;
        GameObject copperQuantityText = scoreTable.transform.GetChild(10).gameObject;
        GameObject emeraldQuantityText = scoreTable.transform.GetChild(13).gameObject;
        GameObject diamondQuantityText = scoreTable.transform.GetChild(16).gameObject;

        while (count != instance.collectedObjects.Count)
        {
            tempGold += instance.collectedObjects[count].goldQuantity;
            tempSilver += instance.collectedObjects[count].silverQuantity;
            tempCopper += instance.collectedObjects[count].copperQuantity;
            tempEmerald += instance.collectedObjects[count].emeraldQuantity;
            tempDiamond += instance.collectedObjects[count].diamondQuality;

            goldQuantityText.GetComponent<TextMeshProUGUI>().text = tempGold.ToString("0.00");
            silverQuantityText.GetComponent<TextMeshProUGUI>().text = tempSilver.ToString("0.00");
            copperQuantityText.GetComponent<TextMeshProUGUI>().text = tempCopper.ToString("0.00");
            emeraldQuantityText.GetComponent<TextMeshProUGUI>().text = tempEmerald.ToString("0.00");
            diamondQuantityText.GetComponent<TextMeshProUGUI>().text = tempDiamond.ToString("0.00");

            count++;

            yield return new WaitForSeconds(waitPeriod);
        }

        scoreText.GetComponent<TextMeshProUGUI>().text = instance.score.ToString();
    }

    public IEnumerator CheckActiveScene()
    {
        while ((SceneManager.GetActiveScene().name != "EndScene"))
        {
            yield return new WaitForSeconds(0.25f);
        }

        TallyScore();
    }

    public void OpenLeaderboard()
    {
        Social.ShowLeaderboardUI();
    }

    public void UpdateLeaderboard()
    {
        if (PlayerPrefs.GetInt("ScoreToUpdate", 0) == 0)
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

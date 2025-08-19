using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    [Header("UI References")]
    public Text scoreText;
    public Text comboText;
    public Text accuracyText;

    [Header("Scoring Settings")]
    public int perfectScore = 300;
    public int greatScore = 200;
    public int goodScore = 100;

    private int totalScore = 0;
    private int currentCombo = 0;
    private int maxCombo = 0;
    private int perfectHits = 0;
    private int greatHits = 0;
    private int goodHits = 0;
    private int misses = 0;
    private int totalNotes = 0;

    void Update()
    {
        UpdateUI();
    }

    public void RegisterHit(HitResult result)
    {
        totalNotes++;

        switch (result)
        {
            case HitResult.Perfect:
                perfectHits++;
                AddScore(perfectScore);
                IncrementCombo();
                break;

            case HitResult.Great:
                greatHits++;
                AddScore(greatScore);
                IncrementCombo();
                break;

            case HitResult.Good:
                goodHits++;
                AddScore(goodScore);
                IncrementCombo();
                break;

            case HitResult.Miss:
                misses++;
                ResetCombo();
                break;
        }
    }

    void AddScore(int baseScore)
    {
        // Apply combo multiplier
        float multiplier = 1f + (currentCombo * 0.01f); // 1% per combo
        int finalScore = Mathf.RoundToInt(baseScore * multiplier);
        totalScore += finalScore;
    }

    void IncrementCombo()
    {
        currentCombo++;
        if (currentCombo > maxCombo)
            maxCombo = currentCombo;
    }

    void ResetCombo()
    {
        currentCombo = 0;
    }

    void UpdateUI()
    {
        if (scoreText) scoreText.text = $"Score: {totalScore:N0}";
        if (comboText) comboText.text = $"Combo: {currentCombo}";

        if (accuracyText && totalNotes > 0)
        {
            float accuracy = (float)(perfectHits + greatHits + goodHits) / totalNotes * 100f;
            accuracyText.text = $"Accuracy: {accuracy:F1}%";
        }
    }

    public float GetAccuracy()
    {
        if (totalNotes == 0) return 0f;
        return (float)(perfectHits + greatHits + goodHits) / totalNotes;
    }

    public ScoreData GetFinalScore()
    {
        return new ScoreData
        {
            totalScore = totalScore,
            maxCombo = maxCombo,
            accuracy = GetAccuracy(),
            perfectHits = perfectHits,
            greatHits = greatHits,
            goodHits = goodHits,
            misses = misses
        };
    }
}

[System.Serializable]
public class ScoreData
{
    public int totalScore;
    public int maxCombo;
    public float accuracy;
    public int perfectHits;
    public int greatHits;
    public int goodHits;
    public int misses;
}

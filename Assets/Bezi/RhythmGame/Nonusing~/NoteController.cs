using UnityEngine;
using UnityEngine.SceneManagement;

public class NoteController : MonoBehaviour
{
    [Header("Note Settings")]
    public float noteSpeed = 5f;
    public Color defaultColor = Color.white;
    public Color approachingColor = Color.yellow;

    public float assignedBeat;
    private SongManager songManager;
    private Vector3 startPosition;
    private Vector3 targetPosition;
    private bool hasBeenHit = false;
    private bool hasMissed = false;
    private SpriteRenderer spriteRenderer;
    private float missThreshold = 2f; // Beats after target where note is considered missed

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer == null)
            spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    public void Initialize(float beatPosition, SongManager manager)
    {
        assignedBeat = beatPosition;
        songManager = manager;
        startPosition = transform.position;
        targetPosition = songManager.hitLine.position;
    }

    public void UpdatePosition(float currentSongBeat)
    {
        if (hasBeenHit || hasMissed) return;

        // Calculate how far the note should be from start to target
        float beatsTillHit = assignedBeat - currentSongBeat;
        float progress = 1f - (beatsTillHit / songManager.beatsShownInAdvance);

        // Move note from spawn to hit line
        transform.position = Vector3.Lerp(startPosition, targetPosition, progress);

        // Change color as note approaches
        if (beatsTillHit <= 1f && beatsTillHit >= -0.5f)
        {
            spriteRenderer.color = approachingColor;
        }

        // Check if note should be considered missed
        if (beatsTillHit < -missThreshold)
        {
            Miss();
        }
    }

    public bool IsInHitWindow(float currentBeat)
    {
        float timingDiff = Mathf.Abs(currentBeat - assignedBeat);
        return timingDiff <= 0.5f; // Half a beat window
    }

    public HitResult GetHitAccuracy(float currentBeat)
    {
        float timingDiff = Mathf.Abs(currentBeat - assignedBeat);

        if (timingDiff <= 0.1f) return HitResult.Perfect;
        if (timingDiff <= 0.25f) return HitResult.Great;
        if (timingDiff <= 0.5f) return HitResult.Good;

        return HitResult.Miss;
    }

    public void Hit(HitResult result)
    {
        if (hasBeenHit) return;

        hasBeenHit = true;

        // Create hit effect
        GameObject.FindObjectOfType<ScoreManager>()?.RegisterHit(result);

        // Destroy note after hit
        Destroy(gameObject, 0.1f);
    }

    public void Miss()
    {
        if (hasMissed || hasBeenHit) return;

        hasMissed = true;
        GameObject.FindObjectOfType<ScoreManager>()?.RegisterHit(HitResult.Miss);

        // Fade out missed note
        spriteRenderer.color = Color.red;
        Destroy(gameObject, 0.5f);
    }

    public bool ShouldDestroy()
    {
        return hasBeenHit || hasMissed;
    }
}

public enum HitResult
{
    Perfect,
    Great,
    Good,
    Miss
}

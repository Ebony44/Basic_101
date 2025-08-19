using UnityEngine;

public class InputManager : MonoBehaviour
{
    [Header("Input Settings")]
    public KeyCode[] inputKeys = { KeyCode.Space, KeyCode.Return };
    public LayerMask noteLayerMask = -1;

    private SongManager songManager;
    private Camera mainCamera;

    void Start()
    {
        songManager = FindObjectOfType<SongManager>();
        mainCamera = Camera.main;
    }

    void Update()
    {
        HandleKeyboardInput();
        HandleMouseInput();
        HandleTouchInput();
    }

    void HandleKeyboardInput()
    {
        foreach (KeyCode key in inputKeys)
        {
            if (Input.GetKeyDown(key))
            {
                ProcessHitAttempt();
            }
        }
    }

    void HandleMouseInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 worldPoint = mainCamera.ScreenToWorldPoint(Input.mousePosition);
            ProcessHitAttempt(worldPoint);
        }
    }

    void HandleTouchInput()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                Vector2 worldPoint = mainCamera.ScreenToWorldPoint(touch.position);
                ProcessHitAttempt(worldPoint);
            }
        }
    }

    void ProcessHitAttempt(Vector2? position = null)
    {
        float currentBeat = songManager.GetSongPosInBeats();
        NoteController closestNote = null;
        float closestDistance = float.MaxValue;

        // Find the closest note in hit range
        NoteController[] allNotes = FindObjectsOfType<NoteController>();

        foreach (NoteController note in allNotes)
        {
            if (!note.IsInHitWindow(currentBeat)) continue;

            float distance;
            if (position.HasValue)
            {
                // Distance-based hit detection for mouse/touch
                distance = Vector2.Distance(position.Value, note.transform.position);
                if (distance > 2f) continue; // Max hit distance
            }
            else
            {
                // Timing-based hit detection for keyboard
                distance = Mathf.Abs(currentBeat - note.GetComponent<NoteController>().assignedBeat);
            }

            if (distance < closestDistance)
            {
                closestDistance = distance;
                closestNote = note;
            }
        }

        if (closestNote != null)
        {
            HitResult result = closestNote.GetHitAccuracy(currentBeat);
            closestNote.Hit(result);
        }
    }
}

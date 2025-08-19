using UnityEngine;

public class InputManager : MonoBehaviour
{
    [Header("Input Settings")]
    public KeyCode[] inputKeys = { KeyCode.Space, KeyCode.Return };
    public LayerMask noteLayerMask = -1;
    public float maxHitDistance = 2f;
    
    private SongManager songManager;
    private Camera mainCamera;
    
    void Start()
    {
        songManager = FindObjectOfType<SongManager>();
        mainCamera = Camera.main;
        if (mainCamera == null)
            mainCamera = FindObjectOfType<Camera>();
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
            if (mainCamera != null)
            {
                Vector2 worldPoint = mainCamera.ScreenToWorldPoint(Input.mousePosition);
                ProcessHitAttempt(worldPoint);
            }
        }
    }
    
    void HandleTouchInput()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began && mainCamera != null)
            {
                Vector2 worldPoint = mainCamera.ScreenToWorldPoint(touch.position);
                ProcessHitAttempt(worldPoint);
            }
        }
    }
    
    void ProcessHitAttempt(Vector2? position = null)
    {
        if (songManager == null) return;
        
        float currentBeat = songManager.GetSongPosInBeats();
        NoteController closestNote = null;
        float closestDistance = float.MaxValue;
        
        NoteController[] allNotes = FindObjectsOfType<NoteController>();
        
        foreach (NoteController note in allNotes)
        {
            if (!note.IsInHitWindow(currentBeat)) continue;
            
            float distance;
            if (position.HasValue)
            {
                distance = Vector2.Distance(position.Value, note.transform.position);
                if (distance > maxHitDistance) continue;
            }
            else
            {
                distance = Mathf.Abs(currentBeat - note.assignedBeat);
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
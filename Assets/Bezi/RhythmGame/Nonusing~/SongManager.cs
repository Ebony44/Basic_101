using UnityEngine;
using System.Collections.Generic;

public class SongManager : MonoBehaviour
{
    [Header("Song Settings")]
    public AudioSource audioSource;
    public float bpm = 140f;
    public float firstBeatOffset = 0f;

    [Header("Gameplay Settings")]
    public float beatsShownInAdvance = 8f;
    public Transform noteSpawnPoint;
    public Transform hitLine;
    public GameObject notePrefab;

    private float secPerBeat;
    private float songPosition;
    private float songPosInBeats;
    private float dspSongTime;
    private int lastBeatSpawned = -1;

    public List<float> beatmap = new List<float>(); // Beat positions for notes
    private List<NoteController> activeNotes = new List<NoteController>();

    void Start()
    {
        secPerBeat = 60f / bpm;

        // Example beatmap - spawn notes on specific beats
        for (int i = 0; i < 64; i++)
        {
            if (i % 4 == 0) // Every 4th beat
                beatmap.Add(i);
        }

        // Start the song with precise timing
        dspSongTime = (float)AudioSettings.dspTime;
        audioSource.PlayScheduled(AudioSettings.dspTime + 0.5);
    }

    void Update()
    {
        // Calculate song position using DSP time for precision
        songPosition = (float)(AudioSettings.dspTime - dspSongTime - firstBeatOffset);
        songPosInBeats = songPosition / secPerBeat;

        // Spawn notes based on beat timing
        SpawnNotes();

        // Update all active notes
        UpdateNotes();

        // Clean up notes that are too far past the hit line
        CleanupNotes();
    }

    void SpawnNotes()
    {
        foreach (float beatToSpawn in beatmap)
        {
            if (beatToSpawn > lastBeatSpawned && beatToSpawn <= songPosInBeats + beatsShownInAdvance)
            {
                GameObject noteObj = Instantiate(notePrefab, noteSpawnPoint.position, Quaternion.identity);
                NoteController note = noteObj.GetComponent<NoteController>();
                note.Initialize(beatToSpawn, this);
                activeNotes.Add(note);
                lastBeatSpawned = (int)beatToSpawn;
            }
        }
    }

    void UpdateNotes()
    {
        foreach (NoteController note in activeNotes)
        {
            if (note != null)
            {
                note.UpdatePosition(songPosInBeats);
            }
        }
    }

    void CleanupNotes()
    {
        activeNotes.RemoveAll(note => note == null || note.ShouldDestroy());
    }

    public float GetSongPosInBeats() => songPosInBeats;
    public float GetSecPerBeat() => secPerBeat;
}

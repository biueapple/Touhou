using System;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    private static ScoreManager instance = null;
    public static ScoreManager Instance
    {
        get
        {
            instance = instance != null ? instance : FindFirstObjectByType<ScoreManager>();
            instance = instance != null ? instance : new GameObject("ScoreManager").AddComponent<ScoreManager>();
            return instance;
        }
    }

    private uint score = 0;
    public uint Score => score;

    private event Action<uint> onScoreChanged;
    public event Action<uint> OnScoreChanged
    {
        add => onScoreChanged += value;
        remove => onScoreChanged -= value;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        instance = this;   
    }

    public void Add(uint score)
    {
        this.score += score;
        onScoreChanged(this.score);
    }

    public void Reset()
    {
        score = 0;
        onScoreChanged(score);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatSubject : MonoBehaviour
{
    [SerializeField] private float beatsPerSecond = 0.5f;

    public static BeatSubject Instance;
    public static event System.Action OnBeat;
    public static event System.Action OnDownBeat;

    private float currentBeatTime;
    private float currentDownBeatTime;

    private void Awake()
    {
        QualitySettings.vSyncCount = 0;
        //Application.targetFrameRate = 60;
    }

    // Start is called before the first frame update
    void Start()
    {
        currentBeatTime = 0f;
        Instance = this;
        DontDestroyOnLoad(this);
        if (FindObjectsOfType<BeatSubject>().Length > 1)
        {
            Destroy(this);
        }
    }

    // Update is called once per frame
    void Update()
    {
        currentBeatTime += Time.deltaTime;
        currentDownBeatTime += Time.deltaTime;
        if (currentBeatTime >= beatsPerSecond)
        {
            OnBeat?.Invoke();
            currentBeatTime -= beatsPerSecond;
        }
        if (currentDownBeatTime >= beatsPerSecond / 2)
        {
            OnDownBeat?.Invoke();
            currentDownBeatTime -= beatsPerSecond / 2;
        }
        
    }
}

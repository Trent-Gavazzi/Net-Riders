using UnityEngine;
using TMPro;

public class TerminalTimer : MonoBehaviour
{
    public float timeLimit = 5f;
    private float currentTime;
    private bool isRunning;

    public TextMeshProUGUI timerText;

    public System.Action OnTimerComplete;

    void Start()
    {
        ResetTimer();
    }

    void Update()
    {
        if (!isRunning) return;

        currentTime -= Time.unscaledDeltaTime;

        UpdateUI();

        if (currentTime <= 0f)
        {
            isRunning = false;
            currentTime = 0f;

            UpdateUI();

            OnTimerComplete?.Invoke();
        }
    }

    public void StartTimer()
    {
        currentTime = timeLimit;
        isRunning = true;
    }

    public void ResetTimer()
    {
        currentTime = timeLimit;
        isRunning = false;
        UpdateUI();
    }

    public void StopTimer()
    {
        isRunning = false;
    }

    public bool IsTimeRemaining()
    {
        return currentTime > 0f;
    }   

    void UpdateUI()
    {
        if (timerText != null)
        {
            timerText.text = Mathf.Ceil(currentTime).ToString();
        }
    }
}

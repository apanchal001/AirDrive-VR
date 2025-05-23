
using UnityEngine;
using TMPro;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
public class LapManager : MonoBehaviour
{
    [Header("Lap Settings")]
    public int totalLaps = 3;

    [Header("References")]
    public TextMeshProUGUI lapText;
    public TextMeshProUGUI lapTimeText;
    public TextMeshProUGUI totalTimeText;
    public GameObject lapSummaryPanel;         
    public TextMeshProUGUI lapSummaryText;     

    private float lapStartTime;
    private float totalTime;
    private int currentLap = 0;
    private bool raceStarted = false;

    private List<float> lapTimes = new List<float>();

    void Start()
    {
        ResetLapData();
    }

    void Update()
    {
        if (raceStarted)
        {
            totalTime += Time.deltaTime;
            lapTimeText.text = $"Lap Time: {Time.time - lapStartTime:F2}s";
            totalTimeText.text = $"Total Time: {totalTime:F2}s";
        }
    }

    public void OnLapTriggerEnter()
    {
        if (!raceStarted)
        {
            raceStarted = true;
            lapStartTime = Time.time;
            currentLap = 1;
            UpdateLapUI();
            Debug.Log("Race started!");
        }
        else
        {
            float lapTime = Time.time - lapStartTime;
            lapTimes.Add(lapTime);
            Debug.Log("Lap " + currentLap + " completed in " + lapTime + "s");

            if (currentLap >= totalLaps)
            {
                raceStarted = false;
                Debug.Log("Race finished! Total time: " + totalTime + "s");
                lapText.text = $"Race Finished!";
                ShowLapSummary();
            }
            else
            {
                currentLap++;
                lapStartTime = Time.time;
                UpdateLapUI();
            }
        }
    }

    void UpdateLapUI()
    {
        if (lapText != null)
            lapText.text = $"Lap: {currentLap}/{totalLaps}";
    }

    void ResetLapData()
    {
        currentLap = 0;
        totalTime = 0f;
        lapStartTime = 0f;
        lapTimes.Clear();

        lapText.text = "Lap: 0/" + totalLaps;
        lapTimeText.text = "Lap Time: 0.00s";
        totalTimeText.text = "Total Time: 0.00s";

        if (lapSummaryPanel != null)
            lapSummaryPanel.SetActive(false);
    }

    void ShowLapSummary()
    {
        if (lapSummaryPanel == null || lapSummaryText == null)
            return;

        lapSummaryPanel.SetActive(true);

        float bestTime = Mathf.Min(lapTimes.ToArray());
        string summary = "Lap Summary:\n \n";

        for (int i = 0; i < lapTimes.Count; i++)
        {
            float time = lapTimes[i];
            string lapInfo = $"Lap {i + 1}: {time:F2}s";

            if (Mathf.Approximately(time, bestTime))
                lapInfo += " <b><color=green>(Best)</color></b>";

            summary += lapInfo + "\n";
        }

        summary += $"\n<b>Total Time: {totalTime:F2}s</b>";
        lapSummaryText.text = summary;
    }

    public bool IsRaceFinished()
    {
        return !raceStarted && currentLap >= totalLaps;
    }

    public void ResetRace()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}

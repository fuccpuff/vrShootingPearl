using System.Collections.Generic;
using UnityEngine;

public class SessionAnalytics : MonoBehaviour
{
    private List<int> sessionScores = new List<int>();
    private List<float> sessionAccuracies = new List<float>();

    public void RecordSession()
    {
        sessionScores.Add(ScoreManager.Instance.GetTotalScore());
        sessionAccuracies.Add(ScoreManager.Instance.GetAccuracy());
    }

    public void DisplaySessionHistory()
    {
        for (int i = 0; i < sessionScores.Count; i++)
        {
            Debug.Log($"������ {i + 1}: ���� - {sessionScores[i]}, �������� - {sessionAccuracies[i]}%");
        }
    }
}
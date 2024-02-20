using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance; // ������� ����������� ��������� ��� ������� ������� �� ������ ��������

    private int score = 0; // ������� ����

    void Awake()
    {
        // ���������, ���������� �� ��� ��������� ��������� �����
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // �� ���������� ������ ��� �������� ����� �����
        }
        else
        {
            Destroy(gameObject); // ���������� ������ ��������� �������
        }
    }

    public void AddScore(int points)
    {
        // ��������� ���� � �������� �����
        score += points;
        Debug.Log("������� ����: " + score); // ������� ������� ���� � ������� ��� �������
    }

    public int GetScore()
    {
        // ���������� ������� ����
        return score;
    }
}

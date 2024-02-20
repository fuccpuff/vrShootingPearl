using UnityEngine;

public class TargetBehavior : MonoBehaviour
{
    public int points = 10; // ����, ����������� �� ��������� � ��� ������

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bullet"))
        {
            ScoreManager.Instance.RegisterHit(points); // ��������� ���� �� ���������
            gameObject.SetActive(false);
        }
    }
}

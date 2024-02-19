using System.Collections;
using UnityEngine;

public class bulletBehavior : MonoBehaviour
{
    public float lifetime = 5f; // ����� ����� ���� �� �� ��������������� ����������� � ���

    private void OnEnable()
    {
        // �������� ��������, ������� ������������� ������ ���� � ��� ����� ������������� �������
        StartCoroutine(LifeTimeRoutine());
    }

    private void OnTriggerEnter(Collider other)
    {
        // ���� ���� ����������� � ���-��, ����� ��������� �� � ���, ����� �������� �������� ����������
        ReturnToPool();
    }

    private void ReturnToPool()
    {
        // ����� ���� ����������, ��� ���������� �� � ���
        gameObject.SetActive(false);
    }

    private void OnDisable()
    {
        // ���������, ��� �� �������� ��������������� ����� �� ����������� � ���, ����� �������� ������
    }

    private IEnumerator LifeTimeRoutine()
    {
        // ��� ��������� ����� �����, ������ ��� ������� ���� � ���
        yield return new WaitForSeconds(lifetime);
        ReturnToPool();
    }
}

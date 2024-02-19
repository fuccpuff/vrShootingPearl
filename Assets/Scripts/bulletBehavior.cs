using System.Collections;
using UnityEngine;

public class bulletBehavior : MonoBehaviour
{
    public float lifetime = 5f;

    private void OnEnable()
    {
        // ������������ ����������� ���� � ���, ���� ��� �� ����������� � ���-����
        StartCoroutine(LifeTimeRoutine());
    }

    private void OnTriggerEnter(Collider other)
    {
        // �������� ��������������� �����������, ���� ��������� ������������
        CancelInvoke(nameof(ReturnToPool));
        // ���������� ���������� ���� � ���
        ReturnToPool();
    }

    private void ReturnToPool()
    {
        gameObject.SetActive(false);
    }

    private void OnDisable()
    {
        // �������� ��� ��������������� ������ Invoke, ����� �������� ������
        CancelInvoke();
    }

    private IEnumerator LifeTimeRoutine()
    {
        yield return new WaitForSeconds(lifetime);
        ReturnToPool();
    }
}

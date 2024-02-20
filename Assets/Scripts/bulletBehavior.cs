using System.Collections;
using UnityEngine;

public class bulletBehavior : MonoBehaviour
{
    public float lifetime = 5f; // ����� ����� ���� �� �� ��������������� ����������� � ���
    public AudioClip hitSound; // ��������� ����� ���������

    private void OnEnable()
    {
        // �������� ��������, ������� ������������� ������ ���� � ��� ����� ������������� �������
        StartCoroutine(LifeTimeRoutine());
    }

    private void OnTriggerEnter(Collider other)
    {
        // ���� ���� ����������� � �����, ����������� ������������
        if (other.CompareTag("Target"))
        {
            PlayHitSound(); // ������������ ���� ��� ���������
        }
        ReturnToPool();
    }

    private void PlayHitSound()
    {
        // ��������������� ����� ���������
        AudioSource.PlayClipAtPoint(hitSound, transform.position);
    }

    private IEnumerator LifeTimeRoutine()
    {
        // ��� ��������� ����� �����, ������ ��� ������� ���� � ���
        yield return new WaitForSeconds(lifetime);
        ReturnToPool();
    }

    private void ReturnToPool()
    {
        // ����� ���� ����������, ��� ���������� �� � ���
        gameObject.SetActive(false);
    }
}

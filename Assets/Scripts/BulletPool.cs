using System.Collections.Generic;
using UnityEngine;

public class BulletPool : MonoBehaviour
{
    public static BulletPool SharedInstance; // ����� ��������� ����� ��������� ��� ������� � ���� �� ������ ��������
    public List<GameObject> pooledBullets; // ������ ��� �������� ���� ���� � ����
    public GameObject bulletPrefab; // ������ ����, ������� ����� �������������� ��� �������� �����
    public int bulletAmount = 20; // ��������� ���������� ���� � ����

    void Awake()
    {
        SharedInstance = this; // ������������� ���� ��� ����� ���������, ����� ������ ������� ����� ���������� � ����
        pooledBullets = new List<GameObject>(); // ������ ������ ����
        GameObject tmp;
        for (int i = 0; i < bulletAmount; i++) // ��������, ����� ������� ��������� ���������� ����
        {
            tmp = Instantiate(bulletPrefab); // ������ ���� �� �������
            tmp.SetActive(false); // ���������� ����� ���� ����������
            pooledBullets.Add(tmp); // �������� ���� � ������
            tmp.transform.parent = this.transform; // ����� ���� �������� �������� ��� ����������� � ��������, �����������
        }
    }

    public GameObject GetPooledBullet()
    {
        for (int i = 0; i < pooledBullets.Count; i++) // ��������� �� ���� ����� � ����
        {
            if (!pooledBullets[i].activeInHierarchy) // ���� ������ ���������� � �������� ����� ����
            {
                return pooledBullets[i]; // ��������� �� ��� �������������
            }
        }
        // ���� ��� ���� ������������, ����������� ������ ��������������
        GameObject tmp = Instantiate(bulletPrefab); // ������ ����� ����
        tmp.SetActive(false); // ����� �� ����������
        pooledBullets.Add(tmp); // �������� � ������ �����
        tmp.transform.parent = this.transform; // ����� �������� �������� ��� �����������, �����������
        return tmp; // ��������� ����� ����
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPool : MonoBehaviour
{
    public static BulletPool SharedInstance;
    public List<GameObject> pooledBullets;
    public GameObject bulletPrefab;
    public int bulletAmount = 20;
    public int maxBullets = 100; // ������������ ���������� ���� � ����

    void Awake()
    {
        if (SharedInstance == null)
        {
            SharedInstance = this;
            DontDestroyOnLoad(gameObject); // ��������� ��� ���� ����� �������
        }
        else
        {
            Destroy(gameObject);
        }

        pooledBullets = new List<GameObject>();
        InitializePool();
    }

    // ������������� ���� � ��������������� "���������"
    void InitializePool()
    {
        for (int i = 0; i < bulletAmount; i++)
        {
            AddBulletToPool();
        }
    }

    GameObject AddBulletToPool()
    {
        if (pooledBullets.Count >= maxBullets) return null; // ���������, �� �������� �� ������������ �����

        var newBullet = Instantiate(bulletPrefab, transform);
        newBullet.SetActive(false);
        pooledBullets.Add(newBullet);
        return newBullet;
    }

    public GameObject GetPooledBullet()
    {
        foreach (var bullet in pooledBullets)
        {
            if (!bullet.activeInHierarchy)
            {
                return bullet;
            }
        }

        // ��������� ���, ���� ��������� ������������ ������
        return pooledBullets.Count < maxBullets ? AddBulletToPool() : null;
    }
}
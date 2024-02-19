using System.Collections.Generic;
using UnityEngine;

public class BulletPool : MonoBehaviour
{
    public static BulletPool SharedInstance; // делаю доступным общий экземпл€р дл€ доступа к пулу из других скриптов
    public List<GameObject> pooledBullets; // список дл€ хранени€ всех пуль в пуле
    public GameObject bulletPrefab; // префаб пули, который будет использоватьс€ дл€ создани€ пулла
    public int bulletAmount = 20; // начальное количество пуль в пуле

    void Awake()
    {
        SharedInstance = this; // инициализирую себ€ как общий экземпл€р, чтобы другие скрипты могли обращатьс€ к пулу
        pooledBullets = new List<GameObject>(); // создаю список пуль
        GameObject tmp;
        for (int i = 0; i < bulletAmount; i++) // итерирую, чтобы создать начальное количество пуль
        {
            tmp = Instantiate(bulletPrefab); // создаю пулю из префаба
            tmp.SetActive(false); // изначально делаю пулю неактивной
            pooledBullets.Add(tmp); // добавл€ю пулю в список
            tmp.transform.parent = this.transform; // делаю пулю дочерним объектом дл€ организации в иерархии, опционально
        }
    }

    public GameObject GetPooledBullet()
    {
        for (int i = 0; i < pooledBullets.Count; i++) // прохожусь по всем пул€м в пуле
        {
            if (!pooledBullets[i].activeInHierarchy) // если нахожу неактивную в иерархии сцены пулю
            {
                return pooledBullets[i]; // возвращаю ее дл€ использовани€
            }
        }
        // если все пули используютс€, опционально создаю дополнительные
        GameObject tmp = Instantiate(bulletPrefab); // создаю новую пулю
        tmp.SetActive(false); // делаю ее неактивной
        pooledBullets.Add(tmp); // добавл€ю в список пулла
        tmp.transform.parent = this.transform; // делаю дочерним объектом дл€ организации, опционально
        return tmp; // возвращаю новую пулю
    }
}

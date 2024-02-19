using System.Collections;
using UnityEngine;

public class bulletBehavior : MonoBehaviour
{
    public float lifetime = 5f; // время жизни пули до ее автоматического возвращения в пул

    private void OnEnable()
    {
        // запускаю корутину, которая автоматически вернет пулю в пул после определенного времени
        StartCoroutine(LifeTimeRoutine());
    }

    private void OnTriggerEnter(Collider other)
    {
        // если пуля столкнулась с чем-то, сразу возвращаю ее в пул, чтобы избежать ненужной активности
        ReturnToPool();
    }

    private void ReturnToPool()
    {
        // делаю пулю неактивной, что возвращает ее в пул
        gameObject.SetActive(false);
    }

    private void OnDisable()
    {
        // убеждаюсь, что не осталось запланированных задач на возвращение в пул, чтобы избежать ошибок
    }

    private IEnumerator LifeTimeRoutine()
    {
        // жду указанное время жизни, прежде чем вернуть пулю в пул
        yield return new WaitForSeconds(lifetime);
        ReturnToPool();
    }
}

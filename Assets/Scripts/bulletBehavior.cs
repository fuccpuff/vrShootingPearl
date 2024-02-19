using System.Collections;
using UnityEngine;

public class bulletBehavior : MonoBehaviour
{
    public float lifetime = 5f;

    private void OnEnable()
    {
        // Запланируйте возвращение пули в пул, если она не столкнулась с чем-либо
        StartCoroutine(LifeTimeRoutine());
    }

    private void OnTriggerEnter(Collider other)
    {
        // Отмените запланированное возвращение, если произошло столкновение
        CancelInvoke(nameof(ReturnToPool));
        // Немедленно возвращаем пулю в пул
        ReturnToPool();
    }

    private void ReturnToPool()
    {
        gameObject.SetActive(false);
    }

    private void OnDisable()
    {
        // Отменяем все запланированные вызовы Invoke, чтобы избежать ошибок
        CancelInvoke();
    }

    private IEnumerator LifeTimeRoutine()
    {
        yield return new WaitForSeconds(lifetime);
        ReturnToPool();
    }
}

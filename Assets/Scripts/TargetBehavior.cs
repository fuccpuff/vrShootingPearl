using UnityEngine;

public class TargetBehavior : MonoBehaviour
{
    public int points = 10; // Очки, начисляемые за попадание в эту мишень

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bullet"))
        {
            ScoreManager.Instance.AddScore(points); // Добавляем очки через менеджер очков
            gameObject.SetActive(false); // Делаем мишень неактивной
        }
    }
}

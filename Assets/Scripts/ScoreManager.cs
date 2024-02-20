using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance; // Создаем статический экземпляр для легкого доступа из других скриптов

    private int score = 0; // Текущий счет

    void Awake()
    {
        // Проверяем, существует ли уже экземпляр менеджера очков
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Не уничтожаем объект при загрузке новой сцены
        }
        else
        {
            Destroy(gameObject); // Уничтожаем лишний экземпляр объекта
        }
    }

    public void AddScore(int points)
    {
        // Добавляем очки к текущему счету
        score += points;
        Debug.Log("Текущий счет: " + score); // Выводим текущий счет в консоль для отладки
    }

    public int GetScore()
    {
        // Возвращаем текущий счет
        return score;
    }
}

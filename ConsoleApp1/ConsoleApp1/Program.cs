using System;
using System.Collections.Generic;

// Класс для представления персонажа
public class Character
{
    // Основные атрибуты персонажа
    public string Name { get; private set; }
    public string Type { get; private set; }
    public string Image { get; private set; }
    public int Level { get; private set; }
    public int Experience { get; private set; }

    // Конструктор
    public Character(string name, string type, string image)
    {
        Name = name;
        Type = type;
        Image = image;
        Level = 1; // начальный уровень
        Experience = 0; // начальный опыт
    }

    // Метод для добавления опыта
    public void AddExperience(int experience)
    {
        Experience += experience;
    }

    // Метод для установки уровня
    public void SetLevel(int level)
    {
        Level = level;
    }
}

// Фабрика для создания персонажей
public class CharacterFactory
{
    // Хранилище созданных персонажей
    private Dictionary<string, Character> characters = new Dictionary<string, Character>();

    // Метод для получения персонажа
    public Character GetCharacter(string name, string type, string image)
    {
        string key = name + type; // Ключ для уникальности

        // Проверяем, существует ли персонаж
        if (!characters.ContainsKey(key))
        {
            // Создаем нового персонажа, если он не существует
            Character character = new Character(name, type, image);
            characters[key] = character; // Добавляем в хранилище
        }

        // Возвращаем существующий или только что созданный персонаж
        return characters[key];
    }
}

// Пример использования
public class Program
{
    public static void Main(string[] args)
    {
        CharacterFactory factory = new CharacterFactory();

        // Создаем персонажей
        Character character1 = factory.GetCharacter("Hero", "Warrior", "warrior.png");
        Character character2 = factory.GetCharacter("Hero", "Warrior", "warrior.png");

        // Проверяем, что оба ссылки указывают на один и тот же объект
        Console.WriteLine(object.ReferenceEquals(character1, character2)); // Вывод: True

        // Изменяем уровень и опыт
        character1.SetLevel(5);
        character1.AddExperience(100);

        // Выводим атрибуты
        Console.WriteLine($"Character Name: {character1.Name}, Type: {character1.Type}, Level: {character1.Level}, Experience: {character1.Experience}");
    }
}
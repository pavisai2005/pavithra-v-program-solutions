using System;

// 1. Product Interface/Abstract Class: Defines the interface for the objects the factory method creates.
public interface IEnemy
{
    void Attack();
    void Defend();
}

// 2. Concrete Products: Implement the Product interface.
public class Goblin : IEnemy
{
    public void Attack()
    {
        Console.WriteLine("Goblin attacks with a rusty sword!");
    }

    public void Defend()
    {
        Console.WriteLine("Goblin tries to dodge.");
    }
}

public class Orc : IEnemy
{
    public void Attack()
    {
        Console.WriteLine("Orc smashes with a club!");
    }

    public void Defend()
    {
        Console.WriteLine("Orc raises its shield.");
    }
}

public class Dragon : IEnemy
{
    public void Attack()
    {
        Console.WriteLine("Dragon breathes fire!");
    }

    public void Defend()
    {
        Console.WriteLine("Dragon flaps its wings and flies away.");
    }
}

// 3. Creator Abstract Class: Declares the factory method, which returns an object of the Product type.
//    It may also define an implementation of an operation that calls the factory method.
public abstract class EnemyFactory
{
    // The Factory Method
    public abstract IEnemy CreateEnemy();

    // An example operation that uses the factory method
    public void SpawnEnemyAndEngage()
    {
        IEnemy enemy = CreateEnemy(); // Call the factory method
        Console.WriteLine("\nSpawning a new enemy...");
        enemy.Attack();
        enemy.Defend();
        Console.WriteLine("Enemy engaged.");
    }
}

// 4. Concrete Creators: Override the factory method to return an instance of a Concrete Product.
public class GoblinFactory : EnemyFactory
{
    public override IEnemy CreateEnemy()
    {
        return new Goblin();
    }
}

public class OrcFactory : EnemyFactory
{
    public override IEnemy CreateEnemy()
    {
        return new Orc();
    }
}

public class DragonFactory : EnemyFactory
{
    public override IEnemy CreateEnemy()
    {
        return new Dragon();
    }
}

// Client Code: Uses the Creator classes to create products.
public class Game
{
    public static void Main(string[] args)
    {
        Console.WriteLine("--- Game Start ---");

        // Create a GoblinFactory and spawn a Goblin
        EnemyFactory goblinCreator = new GoblinFactory();
        goblinCreator.SpawnEnemyAndEngage();

        // Create an OrcFactory and spawn an Orc
        EnemyFactory orcCreator = new OrcFactory();
        orcCreator.SpawnEnemyAndEngage();

        // Create a DragonFactory and spawn a Dragon
        EnemyFactory dragonCreator = new DragonFactory();
        dragonCreator.SpawnEnemyAndEngage();

        Console.WriteLine("\n--- Game End ---");
    }
}
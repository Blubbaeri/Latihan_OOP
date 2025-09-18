using System;

class Program
{
    static void Main(string[] args)
    {
        Karakter hero = new Karakter("Cloud", 100);
        Karakter monster = new Karakter("Nemesis", 80);

        hero.Info();
        monster.Info();
    }
}

// CLASS + CONSTRUCTOR

public class Karakter
{
    public string Nama;
    public int HP;
    public Karakter(string nama, int hp)
    {
        Nama = nama;
        HP = hp;
    }

    public void Info()
    {
        Console.WriteLine($"{Nama} punya {HP} HP");
    }
}

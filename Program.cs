using System;

class Program
{
    static void Main(string[] args)
    {
        Karakter hero = new Karakter("Cloud", 100);
        Karakter monster = new Karakter("Nemesis", 80);
        Karakter hero2 = new Karakter("Tifa", 90);
        Karakter monster2 = new Karakter("Licker", 70);

        hero.Info();
        monster.Info();
        hero2.Info();
        monster2.Info();
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

// Initial commit test

using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Buat objek petarung & monster
        Karakter hero = new Petarung("Arjuna", 100, 20);
        Karakter monster = new Monster("Goblin", 80, 15);
        Karakter boss = new Boss("Naga Hitam", 200, 30);

        // Buat arena (composition)
        Arena arena = new Arena();
        arena.TambahKarakter(hero);
        arena.TambahKarakter(monster);
        arena.TambahKarakter(boss);

        // Tampilkan peserta
        arena.TampilkanPeserta();

        // Pertarungan dimulai
        Console.WriteLine("\n=== Pertarungan Dimulai ===");
        hero.Serang(monster);
        monster.Serang(hero);
        boss.Serang(hero);
        hero.Serang(boss, "Skill Pedang Api"); // Overloading
    }
}

// =====================
// CLASS KARAKTER (Parent)
// =====================
public class Karakter
{
    private string nama;
    private int hp;
    private int attack;

    public Karakter(string nama, int hp, int attack)
    {
        this.nama = nama;
        this.hp = hp;
        this.attack = attack;
    }

    // Encapsulation
    public string Nama { get { return nama; } }
    public int HP
    {
        get { return hp; }
        set { hp = value < 0 ? 0 : value; } // data hiding, gak boleh negatif
    }
    public int Attack { get { return attack; } }

    // Virtual method (polymorphism)
    public virtual void Serang(Karakter target)
    {
        Console.WriteLine($"{nama} menyerang {target.Nama} dengan serangan biasa!");
        target.HP -= attack;
        Console.WriteLine($"{target.Nama} sekarang punya {target.HP} HP");
    }

    // Overloading (method dengan parameter beda)
    public void Serang(Karakter target, string skill)
    {
        Console.WriteLine($"{nama} menggunakan {skill} kepada {target.Nama}!");
        target.HP -= attack * 2;
        Console.WriteLine($"{target.Nama} sekarang punya {target.HP} HP");
    }

    public virtual void Info()
    {
        Console.WriteLine($"{nama} [HP: {hp}, ATK: {attack}]");
    }
}

// =====================
// INHERITANCE & OVERRIDING
// =====================
public class Petarung : Karakter
{
    public Petarung(string nama, int hp, int attack) : base(nama, hp, attack) { }

    public override void Serang(Karakter target)
    {
        Console.WriteLine($"{Nama} (Petarung) menghantam {target.Nama}!");
        target.HP -= Attack;
        Console.WriteLine($"{target.Nama} sekarang punya {target.HP} HP");
    }
}

public class Monster : Karakter
{
    public Monster(string nama, int hp, int attack) : base(nama, hp, attack) { }

    public override void Serang(Karakter target)
    {
        Console.WriteLine($"{Nama} (Monster) menggigit {target.Nama}!");
        target.HP -= Attack;
        Console.WriteLine($"{target.Nama} sekarang punya {target.HP} HP");
    }
}

public class Boss : Karakter
{
    public Boss(string nama, int hp, int attack) : base(nama, hp, attack) { }

    public override void Serang(Karakter target)
    {
        Console.WriteLine($"{Nama} (BOSS) melepaskan serangan dahsyat ke {target.Nama}!!!");
        target.HP -= Attack + 10; // Boss lebih kuat
        Console.WriteLine($"{target.Nama} sekarang punya {target.HP} HP");
    }
}

// =====================
// COMPOSITION
// =====================
public class Arena
{
    private List<Karakter> peserta = new List<Karakter>();

    public void TambahKarakter(Karakter k)
    {
        peserta.Add(k);
    }

    public void TampilkanPeserta()
    {
        Console.WriteLine("=== Peserta Arena ===");
        foreach (var p in peserta)
        {
            p.Info(); // Polymorphism jalan di sini
        }
    }
}

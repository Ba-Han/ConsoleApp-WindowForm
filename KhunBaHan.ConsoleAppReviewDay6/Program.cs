using System.Runtime.InteropServices;

public class Program
{
	public static void Main(string[] args)
	{
		Console.WriteLine(Sum(1,2,3));
		Animal animal = new Animal("Nang Zar Chi Win", 22);
		//animal.MakeSound();
		Console.WriteLine(animal._name);
		Console.WriteLine(animal._age);
	}

	public static int Sum(int a, int b)
	{
		return a + b;
	}

	public static int Sum(int a, int b, int c)
	{
		return a + b + c;
	}
}

public class Animal
{
	#region Properties / class fields
	public string _name { get; set; }
	public int _age { get; set; }
	#endregion

	public void MakeSound() => Console.WriteLine("Animal is making sound.");

	#region Consutror / Setter
	public Animal(string name, int age)
	{
		_name = name;
		_age = age;
	}
	#endregion
}

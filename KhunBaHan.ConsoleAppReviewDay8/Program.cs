//public class Program
//{
//	public static void Main(string[] args)
//	{
//		Dog dog = new();
//		dog.MakeSound();

//		UserRepository user = new UserRepository();
//		Console.WriteLine(user.CreateUser("CR7"));
//	}
//}

//public abstract class Animal
//{
//	public abstract void MakeSound();
//}

//public class Dog : Animal
//{
//	public override void MakeSound()
//	{
//		Console.WriteLine("Leo");
//	}
//}

//public interface IHumanWorker
//{
//	public void Run();
//	public void Eat();
//}

//public interface IRobotWorker
//{
//	public void Work();
//	public void Think();
//}

//public class Worker : IHumanWorker , IRobotWorker
//{
//	public void Run()
//	{

//	}

//	public void Eat()
//	{

//	}

//	public void Work()
//	{

//	}
//	public void Think()
//	{

//	}
//}

//public interface IUserRepository
//{
//	Task<int> CreateUser(string userName);
//}

//public class UserRepository : IUserRepository
//{
//	public Task<int> CreateUser(string userName)
//	{
//		throw new NotImplementedException();
//	}
//}

public class Program
{
	public static void Main(string[] args)
	{
		Console.WriteLine("Please enter your name:");
		string? name = Console.ReadLine();

		Console.WriteLine("Please enter your age:");
		int? age = Convert.ToInt32(Console.ReadLine());

		if (age > 18)
			Console.WriteLine($"Hello {name}" + " your age is greater than 18 year old.");
		else
			Console.WriteLine($"Hello {name}" + " your age is not greater than 18 year old.");
	}
}
public class Program
{
	public static void Main(string[] args)
	{
		// Class.MethodName
		//Console.WriteLine("Hello World!"); // WriteLine is the static method

		// variable declaration
		int age; // int data type
		age = 18; // assignment

		string greetingText = "Hello!"; // string data type
		//bool isActive = true; // bool data type
		double myNum = 1.5; // double data type
		char myChar = 'A';

		greetingText = "Khun Ba Han"; // re-assign

		Console.WriteLine(greetingText);

		string userName = "Khun Ba Han";
		string FirstName = "Khun Ba";
		string last_name = "Han";

		// concatenate
		string fullName = FirstName + " " + last_name;

		const double PI = 3.14;

		//Console.WriteLine("Please enter your name: ");
		//string? name = Console.ReadLine(); // allow null (optinal)

		////Console.WriteLine("Your name is: " + name); // concatenate

		//// interpolate (interpolation)
		//Console.WriteLine($"Your name is: {name}");

		// assignment operators (+, -, *, /)
		int num = 10;
		num += 1; // num = num + 1;
		num -= 1; // num = num - 1;
		num *= 2; // 20

		// comparison operators (==, >, <, >=, <=, !)
		bool isActive = true;
		Console.WriteLine(!isActive);

		// logical (&&)
		string email = "bh@gmail.com";
		string password = "123123";

		Console.WriteLine(email.Equals("bh@gmail.com") && password == "123123");
		// Logical (OR ||)
		Console.WriteLine(email.Equals("bh@gamil.com") || password != "123123");
	}
}
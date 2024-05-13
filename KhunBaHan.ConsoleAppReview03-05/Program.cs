public class Porgram
{
	public int age;
	public static string nickName = string.Empty;
	public static void Main(string[] args)
	{
		//Console.WriteLine("Please enter your name:");
		//string? name = Console.ReadLine();

		//if (!string.IsNullOrEmpty(name))
		//{
		//	Console.WriteLine("Your name is" + name);
		//}

		DateTime dateTime = DateTime.Today;
		switch (dateTime.DayOfWeek)
		{
			case DayOfWeek.Sunday:
				Console.WriteLine("Today is Sundary");
				break;
			
			case DayOfWeek.Monday:
				Console.WriteLine("Today is Monday");
				break;

			case DayOfWeek.Tuesday:
				Console.WriteLine("Today is Tuesday");
				break;

			case DayOfWeek.Wednesday:
				Console.WriteLine("Today is Wednesday");
				break;

			case DayOfWeek.Thursday:
				Console.WriteLine("Today is Thursday");
				break;

			case DayOfWeek.Friday:
				Console.WriteLine("Today is Friday");
				break;

			case DayOfWeek.Saturday:
				Console.WriteLine("Today is Saturaday");
				break;

			default:
				break;
		}

		//for loop
		//for (int i = 0; i < 10; i++)
		//{
		//	Console.WriteLine(i);
		//}

		//while loop
		//int num = 10;
		//while (num <= 10)
		//{
		//	Console.WriteLine(num);
		//	num++;
		//}

		//do while loop
		//string adminEmail = "bh@gmai.com";
		//string adminPw = "123";
		//bool isSuccess = false;

		//do
		//{
		//	Console.WriteLine("Please enter your email");
		//	string? email = Console.ReadLine();

		//	Console.WriteLine("Please enter your pw");
		//	string? pw = Console.ReadLine();

		//	if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(pw))
		//		return;

		//	if( email.Equals(adminEmail) && pw.Equals(adminPw))
		//	{
		//		isSuccess = true;
		//	}else {
		//		isSuccess = false;
		//		Console.WriteLine("Login is not successful");
		//	}
		//} while (!isSuccess);
		//Console.WriteLine("Login is successful");

		//array, array lists
		int[] nums = { 1, 2, 3, 4, 5 };
		//foreach(int num in nums)
		//{
		//	Console.WriteLine(num);
		//}

		List<string> lists = new List<string>();
		lists.Add("CR7");
		lists.Add("Leo");
		lists.Add("KBH");

		//foreach(string list in lists)
		//{
		//	Console.WriteLine(list);
		//}

		//lists.ForEach(list => Console.WriteLine(list));

		//foreach(int i in nums)
		//{
		//	if(i == 5)
		//		break;
		//		//Console.WriteLine(i);

		//	if (i == 2)
		//		continue;
		//		Console.WriteLine(i);
		//}

		Greeting();

		string firstName = "Ba";
		string lastName = "Han";
		string fullName = firstName + lastName;
		Console.WriteLine(fullName);
		Console.WriteLine(fullName.ToUpper());
		Console.WriteLine(fullName.ToLower());
		Console.WriteLine(fullName.Length);

		string id = "C001";
		Console.WriteLine($"New id is: {id.Substring(1,3)}");

		Console.WriteLine(Sum(b:3, a:2));
	}

	public static void Greeting ()
	{
		Console.WriteLine("Hello Greeting");
	}

	public void NonStaticMethod ()
	{
		age = 10;
		nickName = "Ba Han";
	}

	public static int Sum (int a, int b)
	{
		return a + b;
	}

}
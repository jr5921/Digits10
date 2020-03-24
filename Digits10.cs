using System;

namespace Digits10
{
	class SumDigit
	{
		private int[] numbers;
		private int sum;

		public SumDigit(int first, int second, int sum)
		{
			int[] numbers = new int[second - first + 1];
			for (int i = 0; i < numbers.Length; i++)
			{
				numbers[i] = first++;
			}
			this.numbers = numbers;
			this.sum = sum;
		}

		public int getNumber(int pos)
		{
			return numbers[pos];
		}

		public bool[] getBooleans()
		{
			bool[] answer = new bool[numbers.Length];
			for (int i = 0; i < numbers.Length; i++)
			{
				answer[i] = (computeSum(numbers[i]) == sum);
			}
			return answer;
		}

		public String toString(int number)
		{
			int count = 0;
			String answer = ")";
			int num = getNumber(number);
			while (num != 0)
			{
				int digit = num % (int)Math.Pow(10, ++count);
				num -= digit;
				if (count != 1)
				{
					answer = digit / (int)Math.Pow(10, count - 1) + "," + answer;
				}
				else
				{
					answer = digit / (int)Math.Pow(10, count - 1) + answer;
				}
			}
			answer = "(" + answer;
			return answer;
		}

		public static void Main()
		{
			Console.WriteLine("Sample Output\n");
			SumDigit sumDigit = new SumDigit(1, 99, 10);
			bool[] values = sumDigit.getBooleans();
			for (int i = values.Length - 1; i >= 0; i--)
			{
				if (values[i])
				{
					Console.WriteLine("Match found for " + sumDigit.getNumber(i) + ": " + sumDigit.toString(i));
				}
			}
			Console.WriteLine("\nNo match found for:\n");
			String falseNumbers = "";
			for (int i = values.Length - 1; i >= 0; i--)
			{
				if (!values[i])
				{
					falseNumbers += sumDigit.getNumber(i) + ", ";
				}
			}
			Console.WriteLine(falseNumbers.Substring(0, falseNumbers.Length - 2));
		}

		private int computeSum(int number)
		{
			int sum = 0;
			int count = 0;
			while (number != 0)
			{
				int digit = number % (int)Math.Pow(10, ++count);
				sum += digit / (int)Math.Pow(10, count - 1);
				number -= digit;
			}
			return sum;
		}
	}
}

using System;
using System.Collections.Generic;

class EncryptThesymbols
{
	static void Main()
	{
		int n = 0;
		string 
			normal,
			message = "";
		List<string> encrypted = new List<string>();
		while(true)
		{
			normal = Console.ReadLine();
			if(normal == "start" || normal == "START")
			{
				break;
			}
		}
		while(true)
		{
			message = Console.ReadLine();
			if(message == "")
			{
				continue;
			}
			if(message == "end" || message == "END")
			{
				break;
			}
			char[] symbols = message.ToCharArray();
			for(int y = 0, lengthMessage = symbols.Length; y < lengthMessage; ++y)
			{
				int asciiValue = symbols[y];
				if((symbols[y] >= 'A' && symbols[y] <= 'M') || (symbols[y] >= 'a' && symbols[y] <= 'm'))
				{
					asciiValue += 13;
				}
				else if((symbols[y] >= 'N' && symbols[y] <= 'Z') || (symbols[y] >= 'N' && symbols[y] <= 'z'))
				{
					asciiValue -= 13;
				}
				symbols[y] = Convert.ToChar(asciiValue);
				switch(symbols[y])
				{
					case ' ': symbols[y] = '+'; break;
					case ',': symbols[y] = '%'; break;
					case '.': symbols[y] = '&'; break;
					case '?': symbols[y] = '#'; break;
					case '!': symbols[y] = '$'; break;
				}
			}
			Array.Reverse(symbols);
			encrypted.Add(new string(symbols));
			n++;
		}
		if(n == 0)
		{
			Console.WriteLine("No messages sent.");
		}
		else
		{
			Console.WriteLine("Total number of messages: {0}", n);
			foreach(string msg in encrypted)
			{
				Console.WriteLine(msg);
			}
		}		
	}
}


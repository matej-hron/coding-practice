<Query Kind="Statements" />

int a = 55;
int b = 950;
int partial = 0;
while (a > 0 || b > 0)
{
	a = a + partial / 10;
	partial = (a % 10) + (b % 10);
	Console.WriteLine(partial % 10);
	a /= 10;
	b /= 10;
}
if (partial > 0 ) Console.WriteLine(partial / 10);
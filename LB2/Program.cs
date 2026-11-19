using System;
using System.Text;

Console.OutputEncoding = Encoding.UTF8;
Console.InputEncoding = Encoding.UTF8;

Random random = new Random();
int groupCount = random.Next(3, 6);
int[][] groups = new int[groupCount][];

for (int i = 0; i < groups.Length; i++)
{
    int students = random.Next(10, 31);
    groups[i] = new int[students];
    for (int j = 0; j < groups[i].Length; j++)
    {
        groups[i][j] = random.Next(1, 101);
    }
}

int totalSum = 0;
int totalStudents = 0;
int streamMin = groups[0][0];
int streamMax = groups[0][0];

for (int i = 0; i < groups.Length; i++)
{
    int sum = 0;
    int min = groups[i][0];
    int max = groups[i][0];

    for (int j = 0; j < groups[i].Length; j++)
    {
        int grade = groups[i][j];
        sum += grade;
        if (grade < min) min = grade;
        if (grade > max) max = grade;

        totalSum += grade;
        totalStudents++;
        if (grade < streamMin) streamMin = grade;
        if (grade > streamMax) streamMax = grade;
    }

    double avg = (double)sum / groups[i].Length;
    Console.WriteLine($"Група {i + 1} ({groups[i].Length} студ.): середній бал = {avg:F2}, min = {min}, max = {max}");
}

double streamAvg = (double)totalSum / totalStudents;
Console.WriteLine($"\nПотік ({totalStudents} студ.): середній бал = {streamAvg:F2}, min = {streamMin}, max = {streamMax}");

const string Path = "input";
var lines = File.ReadAllLines(Path);

List<int> array1 = [];
List<int> array2 = [];

for (var i = 0; i < lines.Length; i += 1)
{
    var line = lines[i];
    var split = line.Split("   ");

    if (split.Length < 2)
    {
        throw new Exception("Did not split correctly. Input was " + split);
    }

    if (int.TryParse(split[0], out int number1))
    {
        array1.Add(number1);
    }
    else
    {
        throw new Exception("Could not parse " + split[0]);
    }

    if (int.TryParse(split[1], out int number2))
    {
        array2.Add(number2);
    }
    else
    {
        throw new Exception("Could not parse " + split[1]);
    }
}

if (array1.Count != array2.Count)
{
    throw new Exception("List lengths do not match.");
}

array1.Sort();
array2.Sort();

int sumOfDistances = 0;
for (var i = 0; i < array1.Count; i += 1)
{
    sumOfDistances += Math.Abs(array1[i] - array2[i]);
}

Console.WriteLine(sumOfDistances);

int similarityScore = 0;
for (var i = 0; i < array1.Count; i += 1)
{
    similarityScore += array1[i] * array2.Count(number2 => number2 == array1[i]);
}

Console.WriteLine(similarityScore);
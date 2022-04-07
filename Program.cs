using Newtonsoft.Json;
using System.Text;

//Знайти найбільше та найменше значення словника, видалити їх та відсортувати словник по ключам.
//Якщо результатом виконання програми є словник, зберегти цей результат у JSON файл
static void Build(Dictionary<int, int> arrs)
{
    foreach (var arr in arrs)
    {
        Console.Write(arr + " ");
    }
}
var dict = new Dictionary<int, int>()
{
    { 5, 1},
    { 3, 2},
    { 11, 3},
    { 4, 4},
    { 80, 5},
    { 2, 6},
};
Build(dict);
int min = dict.Values.Min();
int max = dict.Values.Max();
foreach (KeyValuePair<int, int> kvp in dict)
{
    if (kvp.Value == min)
    {
        dict.Remove(kvp.Key);
    }
    if (kvp.Value == max)
    {
        dict.Remove(kvp.Key);
    }
}

List<int> Sort = new List<int>(dict.Keys);
Sort.Sort();
List<int> help = new List<int>();
foreach (var num in Sort)
{
    help.Add(dict[num]);
}
dict.Clear();
for (int i = 0; i < Sort.Count; i++)
{
    dict[Sort[i]] = help[i];
}
Console.WriteLine();
Build(dict);

var jarr = JsonConvert.SerializeObject(dict);
string json = jarr.ToString();
var path = @"C:\Users\deadd\Desktop";
path = Path.Combine(path, "data.json");
using (FileStream fstream = new FileStream(path, FileMode.OpenOrCreate))
{
    // преобразуем строку в байты
    byte[] buffer = Encoding.Default.GetBytes(json);
    // запись массива байтов в файл
    await fstream.WriteAsync(buffer, 0, buffer.Length);
    Console.WriteLine();
    Console.WriteLine("Текст записан в файл");
}

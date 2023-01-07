namespace Module8.Task2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"{GetDirSize(@"C:\\Projects\")} байт");

        }

        static double GetDirSize(string path)
        {
            double sizeFile = 0;
            try
            {
                if (Directory.Exists(path))
                {
                    DirectoryInfo directory = new DirectoryInfo(path);
                    var dirs = directory.GetDirectories();

                    foreach (var dir in dirs)
                    {
                        sizeFile += GetDirSize(dir.FullName);
                    }

                    foreach (var file in directory.GetFiles())
                    {
                        sizeFile += file.Length;
                    }
                }
                else Console.WriteLine($"Передан некоректный путь: {path}");

                    return sizeFile;
            }
            catch (DirectoryNotFoundException e)
            {
                Console.WriteLine($"Директория не обнаружена! {e.Message}");
                return 0;
            }
            catch (UnauthorizedAccessException e)
            {
                Console.WriteLine($"Отсутствует доступ! {e.Message}");
                return 0;
            }
            catch (Exception e)
            {
                Console.WriteLine($"Возникла неопознанная ошибка ошибка: {e.Message}");
                return 0;
            }
        }
    }
}
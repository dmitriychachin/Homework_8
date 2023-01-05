//функция получения числа с консоли
int GetNumber(string message)
{
    int result = 0;
    bool isCorrect = false;


    while (!isCorrect)
    {
        Console.WriteLine(message);

        if (int.TryParse(Console.ReadLine(), out result) && result > 0)
        {
            isCorrect = true;
        }
        else
        {
            Console.WriteLine("Ввели не число или 0. Введите корректное число");
        }
    }

    return result;
}

//Создание массива
double[,] createMatrix(int x, int y)
{
    double[,] matrix = new double[x, y];

    Random rnd = new Random();

    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            matrix[i, j] = rnd.Next(1, 10);
        }
    }

    return matrix;
}

void PrintMatrix(double[,] matrix)
{
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            Console.Write($"{matrix[i, j]} ");
        }
        Console.WriteLine();
    }
}

//Сортировака каждой строчки матрицы от большего к меньшему
double[,] sortMatrix(double[,] matrix)
{
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        double[] array = new double[matrix.GetLength(1)];
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            array[j] = matrix[i, j];
        }
        Array.Sort(array);
        Array.Reverse(array);
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            matrix[i, j] = array[j];
        }
    }
    return matrix;
}


int x = GetNumber("Введите количество строчек:");
int y = GetNumber("Введите количество столбцов:");
double[,] matrix = createMatrix(x, y);
PrintMatrix(matrix);
double[,] sortedMatrix = sortMatrix(matrix);
Console.WriteLine();
Console.WriteLine("Отсортированная матрица");
PrintMatrix(sortedMatrix);
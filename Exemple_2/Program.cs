/*
Задайте прямоугольный двумерный массив. Напишите программу, которая будет находить строку с наименьшей суммой элементов.

Например, задан массив:

1 4 7 2

5 9 2 3

8 4 2 4

5 2 6 7

Программа считает сумму элементов в каждой строке и выдаёт номер строки с наименьшей суммой элементов: 1 строка
*/

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

//Проверка массива на прямоугольность
(int x, int y) matrixIsRectangular(int x, int y)
{
    if ( x == y )
    { 
    Console.WriteLine("Эта матрица не будет прямоугольной");
    x = GetNumber("Введите количество строчек:");
    y = GetNumber("Введите количество столбцов:");
    (x , y) = matrixIsRectangular(x, y);
    }
    else 
    {
        x = x; 
        y = y;
    }

    return (x, y);
}

//Создание массива
double [,] createMatrix(int x, int y)
{
    double[,] matrix = new double[x,y];

    Random rnd = new Random();

    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            matrix[i, j ] = rnd.Next(1 , 10);
        }
    }

    return matrix;
}

//Нахождение строчки с меньшей суммой
double minSumStitch(double[,] matrix)
{
    double min = 0;
    double sum = 0;
    int minStitch = 0;
    for (int i = 0; i < 1; i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            sum += matrix[i,j];
        }
        min = sum;
        minStitch = i;
    }

    sum = 0;
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            sum += matrix[i,j];
        }
        if (sum < min)
        {
            min = sum;
            minStitch = i;
        }
        else;
        sum = 0;
    }
    return minStitch + 1; 
}

void PrintMatrix(double [,] matrix)
{
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            Console.Write($"{matrix [i,j]} ");
        }
        Console.WriteLine();
    }
}

int x = GetNumber("Введите количество строчек:");
int y = GetNumber("Введите количество столбцов:");
double [,]matrix = createMatrix(x,y);
PrintMatrix(matrix);
double stitch = minSumStitch(matrix);
Console.WriteLine();
Console.WriteLine($"В строчке номер {stitch} наименьшая сумма");
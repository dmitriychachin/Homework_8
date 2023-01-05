/*
Напишите программу, которая заполнит спирально массив 4 на 4.
Например, на выходе получается вот такой массив:
01 02 03 04
12 13 14 05
11 16 15 06
10 09 08 07
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

//Проверка на равность чисел


//Создание массива одномерного чисел
int[] createArray(int x, int y)
{
    int[] array = new int[x * y];
    int m = 01;

    for (int i = 0; i < array.Length; i++)
    {
        array[i] = m;
        m += 1;
    }
    return array;
}

//Печать спирали на матрице
void PrintMatrix(int[,] matrix)
{
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            if(matrix[i, j] < 10)
            {
                Console.Write($"0{matrix[i, j]} ");
            }
            else
            {
            Console.Write($"{matrix[i, j]} ");
            }
        }
        Console.WriteLine();
    }
}

//Создание и заполнение матрицы
int[,] matrixCreate(int[] array, int x, int y)
{
    int[,] matrix = new int[x, y];
    int m = 0;
    int i = -1;
    int j = -1;
    int q = matrix.GetLength(0);
    int w = matrix.GetLength(1);
    int e = -1;
    int r = 0;
    int z = x;
    int a = y;
    int rowTime = 0;
    int colTime = 0;

    while (rowTime < z && colTime < a)
    {
        if (rowTime < z)
        {
            j += 1;
            i += 1;
            while (j < q)
            {
                matrix[i, j] = array[m];
                m += 1;
                j += 1;
                //Console.WriteLine($"{array[m]} {matrix[i, j]}");
            }
            q -= 1;
            rowTime += 1;
        }
        if (colTime < a)
        {
            i += 1;
            j -= 1;
            while (i < w)
            {
                matrix[i, j] = array[m];
                m += 1;
                i += 1;
                //Console.WriteLine($"{array[m]} {matrix[i, j]}");
            }
            w -= 1;
            colTime += 1;
        }
        if (rowTime < z)
        {
            j -= 1;
            i -= 1;
            while (j > e)
            {
                matrix[i, j] = array[m];
                m += 1;
                j -= 1;
                //Console.WriteLine($"{array[m]} {matrix[i, j]}");
            }
            e += 1;
            rowTime += 1;
        }
        if (colTime < a)
        {
            j += 1;
            i -= 1;
            while (i > r)
            {
                matrix[i, j] = array[m];
                m += 1;
                i -= 1;
                //Console.WriteLine($"{array[m]} {matrix[i, j]}");
            }
            r += 1;
            colTime += 1;
        }
        else;
    }
    return matrix;
}

void PrintArray(int[] array)
{
    for (int i = 0; i < array.Length; i++)
    {
        Console.Write($"{array[i]} ");
    }
}


int x = GetNumber("Введите количество строчек:");
int y = GetNumber("Введите количество столбцов:");

int[] array = createArray(x, y);

PrintArray(array);
Console.WriteLine();
Console.WriteLine();

int[,] matrix = matrixCreate(array, x, y);

PrintMatrix(matrix);


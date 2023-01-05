/*
Задайте две матрицы. Напишите программу, которая будет находить произведение двух матриц.
Например, даны 2 матрицы:
2 4 | 3 4
3 2 | 3 3
Результирующая матрица будет:
18 20
15 18
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

//Создание массива
int[,] createMatrix(int x, int y)
{
    int[,] matrix = new int[x, y];

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

//Печать матрицы
void PrintMatrix(int[,] matrix)
{
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            if (matrix[i, j] > 100)
            {
                Console.Write($"{matrix[i, j]} ");
            }
            else
            {
                Console.Write($"{matrix[i, j]}  ");
            }
        }
        Console.WriteLine();
    }
}

//Умножение матриц
int[,] increaseMatrix(int[,] matrixOne, int[,] matrixTwo)
{
    int[,] resultMatrix = new int[matrixTwo.GetLength(1), matrixOne.GetLength(0)];
    int result = 0;
    int j = 0;

    for (int k = 0; k < resultMatrix.GetLength(0); k++)
    {
        for (int c = 0; c < resultMatrix.GetLength(1); c++)
        {
            while (j < matrixOne.GetLength(1))
            {
                result = result + (matrixOne[k, j] * matrixTwo[j, c]);
                j += 1;
            }

            resultMatrix[k, c] = result;

            j = 0;
            result = 0;
        }
    }

    return resultMatrix;
}

int x = GetNumber("Введите количество строк:");
int y = GetNumber("Введите количество столбцов:");

int[,] matrixOne = createMatrix(x, y);
int[,] matrixTwo = createMatrix(x, y);

Console.WriteLine();
PrintMatrix(matrixOne);
Console.WriteLine();
PrintMatrix(matrixTwo);
Console.WriteLine();

int[,] resultMatrix = increaseMatrix(matrixOne, matrixTwo);

PrintMatrix(resultMatrix);

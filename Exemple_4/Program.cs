/*
Сформируйте трёхмерный массив из неповторяющихся двузначных чисел. 
Напишите программу, которая будет построчно выводить массив, добавляя индексы каждого элемента.
Массив размером 2 x 2 x 2
66(0,0,0) 25(0,1,0)
34(1,0,0) 41(1,1,0)
27(0,0,1) 90(0,1,1)
26(1,0,1) 55(1,1,1)
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

//Метод выбора, какими числами заполнять
int numType()
{
    int result = 0;
    Console.WriteLine("Какие числа вы хотите видеть в массиве?(однозначные, двухзначные, трехзначные)");
    string num = Console.ReadLine();

    switch (num)
    {
        case "двухзначные":
            result = 90;
            break;
        case "однозначные":
            result = 10;
            break;
        case "трехзначные":
            result = 900;
            break;
        default:
            Console.WriteLine("Вы ввели не обозначение цифр или допустили орфографическую ошибку.");
            result = numType();
            break;

    }
    return result;
}


//Создание массива двухзначных чисел
int[] createArray(int num)
{
    int[] array = new int[num];
    int m = 0;
    
    switch (num)
    {
        case 10:
        m = 0;
        break;
        case 90:
        m = 10;
        break;
        default:
        m = 100;
        break;
    }

    for (int i = 0; i < array.Length; i++)
    {
        array[i] = m;
        m += 1;
    }
    return array;
}

//Метод вывода массива неповторяющихся случайных чисел
int[] unicalArray(int[] array, int lenght)
{
    Random rnd = new Random();
    int size = array.Length;
    int i = 0;
    int m = 0;
    int[] unicArray = new int[lenght];


    for (int j = 0; j < lenght; j++)
    {
        i = rnd.Next(0, size);
        unicArray[m] = array[i];
        size = size - 1;
        array[i] = array[size];
        m += 1;
    }
    return unicArray;
}


//Создание и наполнение трехмерного массива
int[,,] binmatrix(int x, int y, int z, int[] unicArray)
{
    int[,,] array = new int[x, y, z];
    int m = 0;

    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            for (int n = 0; n < array.GetLength(2); n++)
            {
                array[i, j, n] = unicArray[m];
                m += 1;
            }
        }
    }

    return array;
}

//Печать массива
void PrintBimatrix(int[,,] bimatrix)
{
    for (int i = 0; i < bimatrix.GetLength(0); i++)
    {
        for (int j = 0; j < bimatrix.GetLength(1); j++)
        {
            for (int n = 0; n < bimatrix.GetLength(2); n++)
            {
                Console.Write($"{bimatrix[i, j, n]} ({i},{j},{n}) ");
            }
            Console.WriteLine();
        }
    }
}

//Печать одномерного массива
void PrintArray(int [] array)
{
    for (int i = 0; i < array.Length; i++)
    {
        Console.Write($"{array[i]} ");
    }
}

int x = GetNumber("Введите количество строк:");
int y = GetNumber("Введите количество столбцов:");
int z = GetNumber("Введите количество углублений:");

int lenght = (x + y) * z;

int num = numType();

int[] array = createArray(num);

PrintArray(array);
Console.WriteLine();
Console.WriteLine();

int[] unicArray = unicalArray(array, lenght);

PrintArray(unicArray);
Console.WriteLine();
Console.WriteLine();

int [,,] binMatrix = binmatrix(x, y, z, unicArray);

PrintBimatrix(binMatrix);
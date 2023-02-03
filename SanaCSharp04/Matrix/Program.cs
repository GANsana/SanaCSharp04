using System;

Random rnd = new Random();
uint rowcount;
uint colcount;
Console.WriteLine("row");
rowcount = uint.Parse(Console.ReadLine());
Console.WriteLine("col");
colcount = uint.Parse(Console.ReadLine());

int[,] matrix = new int[rowcount, colcount];
Console.WriteLine($"-----------------------------------------------------");

for (int row = 0; row < matrix.GetLength(0); row++)
    for (int col = 0; col < matrix.GetLength(1); col++)
    {
        matrix[row, col] = rnd.Next(-10, 10);

    }

for (int row = 0; row < matrix.GetLength(0); row++)
{
    if (row % 2 == 0)
        Console.ForegroundColor = ConsoleColor.Cyan;
    else
        Console.ForegroundColor = ConsoleColor.White;


    for (int col = 0; col < matrix.GetLength(1); col++)
    {
        Console.Write($"{matrix[row, col]}\t");

    }
    Console.WriteLine();
} //print matrix

Console.WriteLine($"-----------------------------------------------------");



uint poscount = 0;
for (int row = 0; row < matrix.GetLength(0); row++)
    for (int col = 0; col < matrix.GetLength(1); col++)
    {
        if (matrix[row, col] > 0)
            poscount++;

    }
Console.WriteLine($"Count of positive vaules {poscount}");



double maxdubvaule = double.MinValue;


int[] Arr = new int[matrix.GetLength(0) * matrix.GetLength(1)];
for (int i = 0; i < matrix.GetLength(0); i++)
    for (int j = 0; j < matrix.GetLength(1); j++)
    {
        Arr[i * matrix.GetLength(1) + j] = matrix[i, j];
    }


for (int i = 0; i < Arr.Length; i++)
{
    for (int j = 0; j < Arr.Length; j++)
    {
        if (Arr[i] == Arr[j] && i != j)
        {
            maxdubvaule = Arr[j];


        }
        else if (maxdubvaule == double.MinValue)
        {
            maxdubvaule = double.NaN;
        }
    }


}
Console.WriteLine($"max duplicated vaule {maxdubvaule}");



int count_zero = 0;
int count_rows_no_zero = 0;
for (int row = 0; row < matrix.GetLength(0); row++)
{
    count_zero = 0;
    for (int col = 0; col < matrix.GetLength(1); col++)
    {

        if (matrix[row, col] == 0)
        {
            count_zero++;
            break;
        }

    }
    if (count_zero == 0)
    {
        count_rows_no_zero++;
    }
}
Console.WriteLine($"rows ithout zero {count_rows_no_zero}");




int col_with_zero = 0;

for (int col = 0; col < matrix.GetLength(1); col++)
{
    for (int row = 0; row < matrix.GetLength(0); row++)
    {
        if (matrix[row, col] == 0)
        {
            col_with_zero++;
            break;
        }

    }

}
Console.WriteLine($"coumns with at least one zero {col_with_zero}");





int multuply = 1;
int count_neg = 0;


for (int row = 0; row < matrix.GetLength(0); row++)
{
    count_neg = 0;
    for (int col = 0; col < matrix.GetLength(1); col++)
    {

        if (matrix[row, col] < 0)
        {
            count_neg++;
            break;
        }

    }
    if (count_neg == 0)
    {
        for (int col_sub = 0; col_sub < matrix.GetLength(1); col_sub++)
        {
            multuply *= matrix[row, col_sub];
        }
        Console.WriteLine($"row {row} has no negative elements, multiply of elements in it is {multuply} ");
    }
}




int sum_least_one_neg = 0;

for (int col = 0; col < matrix.GetLength(1); col++)
{
    for (int row = 0; row < matrix.GetLength(0); row++)
    {

        if (matrix[row, col] < 0)
        {
            for (int row_sub = 0; row_sub < matrix.GetLength(0); row_sub++)
            {
                sum_least_one_neg += matrix[row_sub, col];
                row = matrix.GetLength(0) + 1;
            }
        }

    }

}
Console.WriteLine($"sum in column with at least one negative element = {sum_least_one_neg}");




int max_sum_main_diagonal = int.MinValue;

for (int row = 0; row < matrix.GetLength(0); row++) //від головної вниз
{
    int sum = 0;
    for (int cordrow = row, cordcol = 0; cordrow < matrix.GetLength(0) && cordcol < matrix.GetLength(1); cordrow++, cordcol++)
    {
        sum += matrix[cordrow, cordcol];


    }
    if (sum > max_sum_main_diagonal)
    {
        max_sum_main_diagonal = sum;
    }

}

for (int row = 0, col = 0; col <= matrix.GetLength(1); col++) //від головної вверх
{
    int sum = 0;
    for (int cordrow = row, cordcol = col; cordrow < matrix.GetLength(0) && cordcol < matrix.GetLength(1); cordrow++, cordcol++)
    {
        sum += matrix[cordrow, cordcol];



    }
    if (sum > max_sum_main_diagonal)
    {
        max_sum_main_diagonal = sum;
    }
}
Console.WriteLine($"max sum of main diagonals==={max_sum_main_diagonal}");




int min_sum_Abs_antidiagonal = int.MaxValue;

for (int row = 0, col = matrix.GetUpperBound(1); col >= 0; col--) //від побічної вгору
{
    int sumpob = 0;
    for (int cordrow = row, cordcol = col; cordrow < matrix.GetLength(0) && cordcol >= 0; cordrow++, cordcol--)
    {
        sumpob += Math.Abs(matrix[cordrow, cordcol]);

    }
    if (sumpob < min_sum_Abs_antidiagonal)
    {
        min_sum_Abs_antidiagonal = sumpob;
    }
}

for (int row = 0, col = matrix.GetUpperBound(1); row < matrix.GetLength(0); row++) //від побічної вниз
{
    int sumpob = 0;
    for (int cordrow = row, cordcol = col; cordrow < matrix.GetLength(0) && cordcol >= 0; cordrow++, cordcol--)
    {
        sumpob += Math.Abs(matrix[cordrow, cordcol]);

    }
    if (sumpob < min_sum_Abs_antidiagonal)
    {
        min_sum_Abs_antidiagonal = sumpob;
    }
}

Console.WriteLine($"minimum of sum of absolute vaules of counter diagonal {min_sum_Abs_antidiagonal}");






Console.WriteLine($"Transposed Matrix");


int[,] matrix_transposed = new int[colcount, rowcount];


for (int row = 0; row < matrix_transposed.GetLength(0); row++)
    for (int col = 0; col < matrix_transposed.GetLength(1); col++)
    {
        matrix_transposed[row, col] = matrix[col, row];

    }

Console.WriteLine($"-----------------------------------------------------");

for (int row = 0; row < matrix_transposed.GetLength(0); row++)
{
    if (row % 2 == 0)
        Console.ForegroundColor = ConsoleColor.Cyan;
    else
        Console.ForegroundColor = ConsoleColor.White;


    for (int col = 0; col < matrix_transposed.GetLength(1); col++)
    {
        Console.Write($"{matrix_transposed[row, col]}\t");

    }
    Console.WriteLine();
} //print matrix

Console.WriteLine($"-----------------------------------------------------");

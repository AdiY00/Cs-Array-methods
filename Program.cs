static void PrintArray(int[] arr)
{
    if (arr == null) Console.WriteLine("null");
    else foreach (int e in arr) Console.Write(e + " ");
    Console.WriteLine();
}

//1.
static int[] Append(int[] arr, int num)
{
    int oLength = arr.Length;
    int[] ret = new int[oLength+1];
    for (int i = 0; i < oLength; i++)
        ret[i] = arr[i];

    ret[oLength] = num;
    return ret;
}

//2-5.
static int[] Get(int[] arr, int num, string op, bool returnIndexes = false)
{//would be way better with lists but ok
    
    int[] tempArray = new int[arr.Length];
    int len = 0;

    for (int i = 0; i < arr.Length; i++)
    {
        bool shouldGet =
            op == "==" ? arr[i] == num :
            op == ">" ? arr[i] > num :
            op == "!=" ? arr[i] != num :
            op == "~=" && arr[i].ToString().Contains(num.ToString());

        if (shouldGet)
        {
            if (returnIndexes) tempArray[len] = i;
            else tempArray[len] = arr[i];
            len++;
        }
    }

    int[] ret = new int[len];

    for (int i = 0; i < ret.Length; i++)
        ret[i] = tempArray[i];

    return len > 0 ? ret : null;
}


//2.
static int[] GetIndexes(int[] arr, int num)
{// DRY
    return Get(arr, num, "==", true);
}

//3.
int[] GetItemsAbove(int[] arr, int num)
{//DRY
    return Get(arr, num, ">");
}

//4.
int[] GetItemsExcept(int[] arr, int num)
{//DRY
    return Get(arr, num, "!=");
}

//5.
int[] GetAllContains(int[] arr, int num)
{//DRY
    return Get(arr, num, "~=");
}


int[] arr1 = new int[] {1,4,1,5,9,2};
int[] arr2 = new int[] {11,4,15,5,29,2};

PrintArray(GetIndexes(arr1,1));
PrintArray(GetIndexes(arr1,3));
Console.WriteLine();

PrintArray(GetItemsAbove(arr1, 4));
PrintArray(GetItemsAbove(arr1, 31));
Console.WriteLine();

PrintArray(GetItemsExcept(arr1, 1));
Console.WriteLine();

PrintArray(GetAllContains(arr2, 1));


//6.
static int[] GetSorted(int[] arr)
{
    int[] sorted = new int[arr.Length];
    for (int i = 0; i < arr.Length; i++) sorted[i] = arr[i];

    for (int i = 0; i < sorted.Length; i++)
        for (int j = i + 1; j < sorted.Length; j++)
            if (sorted[i] > sorted[j])
                (sorted[i], sorted[j]) = (sorted[j], sorted[i]);

    return sorted;
}

PrintArray(GetSorted(arr1));
PrintArray(GetSorted(arr2));
Console.WriteLine();

//7.
static bool AreItemsSame(int[] arr)
{
    int num = arr[0];
    foreach (int item in arr)
        if (item != num) return false;

    return true;
}

Console.WriteLine(AreItemsSame(new int[3] {4,4,4}));
Console.WriteLine(AreItemsSame(new int[3] {4,1,4}));

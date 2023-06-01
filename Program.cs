using System;
/*
Challenge 1. Given a jagged array of integers (two dimensions).
Find the common elements in the nested arrays.
Example: int[][] arr = { new int[] {1, 2}, new int[] {2, 1, 5}}
Expected result: int[] {1,2} since 1 and 2 are both available in sub arrays.
*/

bool Contains(int[] arr, int element)
{
    for (int i = 0; i < arr.Length; i++)
    {
        if (arr[i] == element)
        {
            return true;
        }
    }
    return false;
}

int[] CommonItems(int[][] jaggedArray)
{
    int[] result = new int[0];

    for (int i = 0; i < jaggedArray[0].Length; i++)
    {
        bool isCommon = true;

        for (int j = 0; j < jaggedArray.Length; j++)
        {
            if (!Contains(jaggedArray[j], jaggedArray[0][i]))
            {
                isCommon = false;
                break;
            }
        }

        if (isCommon && !Contains(result, jaggedArray[0][i]))
        {
            int[] newArray = new int[result.Length + 1];
            Array.Copy(result, newArray, result.Length);
            newArray[newArray.Length - 1] = jaggedArray[0][i];
            result = newArray;
        }
    }

    return result;
}

int[][] arr1 = { new int[] { 1, 2 }, new int[] { 2, 1, 5 } };
int[] arr1Common = CommonItems(arr1);
Console.WriteLine($"Common elements: {string.Join(", ", arr1Common)}");

/* 
Challenge 2. Inverse the elements of a jagged array.
For example, int[][] arr = {new int[] {1,2}, new int[]{1,2,3}} 
Expected result: int[][] arr = {new int[]{2, 1}, new int[]{3, 2, 1}}
*/

void InverseJagged(int[][] jaggedArray)
{
    for (int i = 0; i < jaggedArray.Length; i++)
    {
        int start = 0;
        int end = jaggedArray[i].Length - 1;
        while (start < end)
        {
            // Swap the start and end elements
            int temporary = jaggedArray[i][start];
            jaggedArray[i][start] = jaggedArray[i][end];
            jaggedArray[i][end] = temporary;

            start++;
            end--;
        }
    }
}

int[][] arr2 = { new int[] { 1, 2 }, new int[] { 1, 2, 3 } };
InverseJagged(arr2);

// Print the reversed arrays
Console.WriteLine($"Array 0: {string.Join(", ", arr2[0])}");
Console.WriteLine($"Array 1: {string.Join(", ", arr2[1])}");


// /* 
// Challenge 3.Find the difference between 2 consecutive elements of an array.
// For example, int[][] arr = {new int[] {1,2}, new int[]{1,2,3}} 
// Expected result: int[][] arr = {new int[] {-1}, new int[]{-1, -1}}
//  */
void CalculateDiff(int[][] jaggedArray)
{
    for (int i = 0; i < jaggedArray.Length; i++)
    {
        int[] resultArray = new int[jaggedArray[i].Length - 1];

        for (int j = 0; j < jaggedArray[i].Length - 1; j++)
        {
            resultArray[j] = jaggedArray[i][j] - jaggedArray[i][j + 1];
        }

        jaggedArray[i] = resultArray;
    }
}

int[][] arr3 = { new int[] { 1, 2 }, new int[] { 1, 2, 3 } };
CalculateDiff(arr3);
/* write method to print arr3 */
Console.WriteLine($"Array 1: {string.Join(", ", arr3[0])}");
Console.WriteLine($"Array 2: {string.Join(", ", arr3[1])}");

// /* 
// Challenge 4. Inverse column/row of a rectangular array.
// For example, given: int[,] arr = {{1,2,3}, {4,5,6}}
// Expected result: {{1,4},{2,5},{3,6}}
//  */

int[,] InverseRec(int[,] recArray)
{
    int rowCount = recArray.GetLength(0);
    int columnCount = recArray.GetLength(1);

    int[,] result = new int[columnCount, rowCount];

    for (int i = 0; i < rowCount; i++)
    {
        for (int j = 0; j < columnCount; j++)
        {
            result[j, i] = recArray[i, j];
        }
    }
    return result;
}
int[,] arr4 = { { 1, 2, 3 }, { 4, 5, 6 } };
int[,] arr4Inverse = InverseRec(arr4);

/* write method to print arr4Inverse */
void PrintArray(int[,] array)
{
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            Console.Write(array[i, j] + " ");
        }
        Console.WriteLine(" ");
    }
}

PrintArray(arr4Inverse);

// /* 
// Challenge 5. Write a function that accepts a variable number of params of any of these types: 
// string, number. 
// - For strings, join them in a sentence. 
// - For numbers then sum them up. 
// - Finally print everything out. 
// Example: Demo("hello", 1, 2, "world") 
// Expected result: hello world; 3 */
void Demo(params object[] args)
{
    string words = "";
    int sum = 0;

    foreach (object element in args)
    {
        if (element is string)
        {
            words += (string)element + " ";
        }
        else if (element is int)
        {
            sum += (int)element;
        }
    }

    Console.WriteLine(words.Trim() + "; " + sum);
}
Demo("hello", 1, 2, "world"); //should print out "hello world; 3"
Demo("My", 2, 3, "daughter", true, "is");//should print put "My daughter is; 5"


/* Challenge 6. Write a function to swap 2 objects but only if they are of the same type 
and if they’re string, lengths have to be more than 5. 
If they’re numbers, they have to be more than 18. */
void SwapTwo(ref object arg1, ref object arg2)
{
    if (arg1 != null && arg2 != null)
    {
        if (arg1.GetType() == arg2.GetType())
        {
            if (arg1 is string)
            {
                string string1 = (string)arg1;
                string string2 = (string)arg2;

                if (string1.Length > 5 && string2.Length > 5)
                {

                    object temporary = arg1;
                    arg1 = arg2;
                    arg2 = temporary;
                }
            }
            else if (arg1 is int)
            {
                int number1 = (int)arg1;
                int number2 = (int)arg2;

                if (number1 > 18 && number2 > 18)
                {
                    object temporary = arg1;
                    arg1 = arg2;
                    arg2 = temporary;
                }
            }

        }
    }
}

/* Challenge 7. Write a function that does the guessing game. 
The function will think of a random integer number (lets say within 100) 
and ask the user to input a guess. 
It’ll repeat the asking until the user puts the correct answer. */
void GuessingGame()
{
    Random rnd = new Random();
    int choosenNumber = rnd.Next(101);

    bool isCorrect = false;
    while (isCorrect == false)
    {
        Console.WriteLine("Pick a number between 0 and 100: ");
        string? userInput = Console.ReadLine();
        int userInputNumber = Convert.ToInt16(userInput);

        if (userInputNumber != choosenNumber)
        {
            Console.WriteLine("You are wrong :( Try again!");
            continue;
        }
        else
        {
            isCorrect = true;
            Console.WriteLine("Congratulations! You are right!");
        }
    }
}
GuessingGame();

/* Challenge 8. Provide class Product, OrderItem, Cart, which make a feature of a store
Complete the required features in OrderItem and Cart, so that the test codes are error-free */

var product1 = new Product(1, 30);
var product2 = new Product(2, 50);
var product3 = new Product(3, 40);
var product4 = new Product(4, 35);
var product5 = new Product(5, 75);

var orderItem1 = new OrderItem(product1, 2);
var orderItem2 = new OrderItem(product2, 1);
var orderItem3 = new OrderItem(product3, 3);
var orderItem4 = new OrderItem(product4, 2);
var orderItem5 = new OrderItem(product5, 5);
var orderItem6 = new OrderItem(product2, 2);

var cart = new Cart();
cart.AddToCart(orderItem1, orderItem2, orderItem3, orderItem4, orderItem5, orderItem6);

//get 1st item in cart
var firstItem = cart[0];
Console.WriteLine(firstItem);

//Get cart info
cart.GetCartInfo(out int totalPrice, out int totalQuantity);
Console.WriteLine("Total Quantity: {0}, Total Price: {1}", totalQuantity, totalPrice);

//get sub array from a range
var subCart = cart[1, 3];
Console.WriteLine(subCart);

class Product
{
    public int Id { get; set; }
    public int Price { get; set; }

    public Product(int id, int price)
    {
        this.Id = id;
        this.Price = price;
    }
}

class OrderItem : Product
{
    public int Quantity { get; set; }
    private Product _product;

    public OrderItem(Product product, int quantity) : base(product.Id, product.Price)
    {
        this.Quantity = quantity;
        this._product = product;
    }

    public override string ToString()
    {
        return $"Id: {this._product.Id}, Price: {this._product.Price}, Quantity: {this.Quantity}";
    }
}

class Cart
{
    private List<OrderItem> _cart { get; set; } = new List<OrderItem>();

    /* Write indexer property to get nth item from _cart */
    public OrderItem this[int index]
    {
        get
        {
            if (index >= 0 && index < _cart.Count)
            {
                return _cart[index];
            }
            else
            {
                throw new Exception("Index is out of range.");
            }
        }
    }

    /* Write indexer property to get items of a range from _cart */
    public List<OrderItem> this[int startIndex, int endIndex]
    {
        get
        {
            if (startIndex >= 0 && endIndex < _cart.Count)
            {

                return _cart.GetRange(startIndex, endIndex - startIndex + 1);
            }
            else
            {
                throw new Exception("Indexes are out of range.");
            }

        }
    }

    public void AddToCart(params OrderItem[] items)
    {
        foreach (OrderItem item in items)
        {
            OrderItem existingItem = _cart.FirstOrDefault(i => i.Id == item.Id);

            if (existingItem != null)
            {
                existingItem.Quantity += item.Quantity;
            }
            else
            {
                _cart.Add(item);
            }
        }
    }
    /* Write another method called Index */
    public OrderItem Index(int index)
    {
        if (index >= 0 && index < _cart.Count)
        {
            return _cart[index];
        }
        else
        {
            throw new Exception("Index is out of range.");
        }
    }

    /* Write another method called GetCartInfo(), which out put 2 values: 
    total price, total products in cart*/
    public (int totalPrice, int totalProducts) GetCartInfo(out int totalPrice, out int totalProducts)
    {
        totalPrice = 0;
        totalProducts = 0;

        foreach (OrderItem item in _cart)
        {
            totalPrice += (item.Price * item.Quantity);
            totalProducts += item.Quantity;
        }

        return (totalPrice, totalProducts);
    }

    /* Override ToString() method so Console.WriteLine(cart) can print
    id, unit price, unit quantity of each item*/

    public override string ToString()
    {
        string result = "";

        foreach (OrderItem item in _cart)
        {
            result += $"Id: {item.Id}, Price: {item.Price}, Quantity: {item.Quantity}, ";
        }

        return result;
    }
}
﻿using System;
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
            int temp = jaggedArray[i][start];
            jaggedArray[i][start] = jaggedArray[i][end];
            jaggedArray[i][end] = temp;

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
// int[,] InverseRec(int[,] recArray)
// {

// }
// int[,] arr4 = { { 1, 2, 3 }, { 4, 5, 6 } };
// int[,] arr4Inverse = InverseRec(arr4);
// /* write method to print arr4Inverse */

// /* 
// Challenge 5. Write a function that accepts a variable number of params of any of these types: 
// string, number. 
// - For strings, join them in a sentence. 
// - For numbers then sum them up. 
// - Finally print everything out. 
// Example: Demo("hello", 1, 2, "world") 
// Expected result: hello world; 3 */
// void Demo()
// {

// }
// Demo("hello", 1, 2, "world"); //should print out "hello world; 3"
// Demo("My", 2, 3, "daughter", true, "is");//should print put "My daughter is; 5"


// /* Challenge 6. Write a function to swap 2 objects but only if they are of the same type 
// and if they’re string, lengths have to be more than 5. 
// If they’re numbers, they have to be more than 18. */
// void SwapTwo()
// {

// }

// /* Challenge 7. Write a function that does the guessing game. 
// The function will think of a random integer number (lets say within 100) 
// and ask the user to input a guess. 
// It’ll repeat the asking until the user puts the correct answer. */
// void GuessingGame()
// {

// }
// GuessingGame();

// /* Challenge 8. Provide class Product, OrderItem, Cart, which make a feature of a store
// Complete the required features in OrderItem and Cart, so that the test codes are error-free */

// var product1 = new Product(1, 30);
// var product2 = new Product(2, 50);
// var product3 = new Product(3, 40);
// var product4 = new Product(4, 35);
// var product5 = new Product(5, 75);

// var orderItem1 = new OrderItem(product1, 2);
// var orderItem2 = new OrderItem(product2, 1);
// var orderItem3 = new OrderItem(product3, 3);
// var orderItem4 = new OrderItem(product4, 2);
// var orderItem5 = new OrderItem(product5, 5);
// var orderItem6 = new OrderItem(product2, 2);

// var cart = new Cart();
// cart.AddToCart(orderItem1, orderItem2, orderItem3, orderItem4, orderItem5, orderItem6);

// //get 1st item in cart
// var firstItem = cart[0];
// Console.WriteLine(firstItem);

// //Get cart info
// cart.GetCartInfo(out int totalPrice, out int totalQuantity);
// Console.WriteLine("Total Quantity: {0}, Total Price: {1}", totalQuantity, totalPrice);

// //get sub array from a range
// var subCart = cart[1, 3];
// Console.WriteLine(subCart);

// class Product
// {
//     public int Id { get; set; }
//     public int Price { get; set; }

//     public Product(int id, int price)
//     {
//         this.Id = id;
//         this.Price = price;
//     }
// }

// class OrderItem : Product
// {
//     public int Quantity { get; set; }

//     public OrderItem(Product product, int quantity) : base(product.Id, product.Price)
//     {
//         this.Quantity = quantity;
//     }

//     /* Override ToString() method so the item can be printed out conveniently with Id, Price, and Quantity */
// }

// class Cart
// {
//     private List<OrderItem> _cart { get; set; } = new List<OrderItem>();

//     /* Write indexer property to get nth item from _cart */

//     /* Write indexer property to get items of a range from _cart */

//     public void AddToCart(params OrderItem[] items)
//     {
//         /* this method should check if each item exists --> increase value / or else, add item to cart */
//     }
//     /* Write another method called Index */

//     /* Write another method called GetCartInfo(), which out put 2 values: 
//     total price, total products in cart*/

//     /* Override ToString() method so Console.WriteLine(cart) can print
//     id, unit price, unit quantity of each item*/

// }
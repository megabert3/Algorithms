using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Algoritms {
    class Program {
        static void Main(string[] args) {

            List<int> list = new List<int>() { 3, 8, 5, 1, 1};

            Random rand = new Random();

            //int indx = binarySearch(rand.Next(0, 150), list.ToArray());

            //int[] arr = insertionSort(list.ToArray());
            int[] arr = MergeSort.sortArr(list.ToArray());

            Console.WriteLine();
        }
            

        //Бинарный поиск
        public static int binarySearch(int value, int[] valuesArr) {

            int minBound = 0;
            int maxBound = valuesArr.Length - 1;
            int middleIndex;

            int currValue;

            while (true) {

                middleIndex = (minBound + maxBound) / 2;

                currValue = valuesArr[middleIndex];

                if (currValue == value) {
                    return middleIndex;

                } else if (minBound > maxBound) {
                    Console.WriteLine("Значение не найдено");

                } else {

                    if (value > currValue) {

                        minBound = middleIndex + 1;

                    } else {
                        maxBound = middleIndex - 1;
                    }
                }
            }
        }

        //Сортировка пузырьком
        public static int[] bubbleSort(int[] arr) {

            for (int i = arr.Length - 1; i > 1; i--) {
                for (int j = 0; j < i; j++) {

                    if (arr[j] < arr[j + 1]) {

                        int val = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = val;
                    }
                }
            }

            return arr;
        }

        //Сортировка выбором
        public static int[] selectionSort(int[] arr) {
            //Индекс минимального элемента
            int min;

            for (int i = 0; i < arr.Length - 1; i++) {
                min = i;

                for (int j = i + 1; j < arr.Length; j++) {

                    if (arr[j] < arr[min]) {
                        min = j;
                    }
                }

                int val = arr[i];
                arr[i] = arr[min];
                arr[min] = val;
            }

            return arr;
        }

        //Сортировка вставками
        public static int[] insertionSort(int[] arr) {
            int j;

            for (int i = 1; i < arr.Length; i++) {
                int temp = arr[i]; // Скопировать помеченный элемент
                j = i; // Начать перемещения с out

                // Пока не найден меньший элемент
                while (j > 0 && arr[j - 1] >= temp) {
                    arr[j] = arr[j - 1]; // Сдвинуть элемент вправо
                    --j; // Перейти на одну позицию влево
                }

                arr[j] = temp; // Вставить помеченный элемент
            }

            return arr;
        }

        //Сортировка слиянием
        public class MergeSort {
            public static int[] sortArr(int[] arr) {

                if (arr == null) return null;

                if (arr.Length < 2) return arr;

                int[] a = new int[arr.Length / 2];
                int[] b = new int[arr.Length - (arr.Length / 2)];

                Array.Copy(arr, a, arr.Length / 2);
                Array.Copy(arr, a.Length, b, 0, b.Length);

                a = sortArr(a);
                b = sortArr(b);

                return mergeArrs(a, b);
            }

            private static int[] mergeArrs(int[] arrA, int[] arrB) {

                int[] arrayC = new int[arrA.Length + arrB.Length];

                int positionA = 0, positionB = 0;

                for (int i = 0; i < arrayC.Length; i++) {

                    if (positionA == arrA.Length) {
                        arrayC[i] = arrB[positionB];
                        positionB++;

                    } else if (positionB == arrB.Length) {
                        arrayC[i] = arrA[positionA];
                        positionA++;

                    } else if (arrA[positionA] < arrB[positionB]) {
                        arrayC[i] = arrA[positionA];
                        positionA++;

                    } else {
                        arrayC[i] = arrB[positionB];
                        positionB++;
                    }
                }

                return arrayC;
            }
        }
    }
}
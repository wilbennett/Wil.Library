using System;
using System.Collections.Generic;

namespace Wil.Core
{
    public static class ArrayUtils
    {
        public static void ZeroOut(this double[] array) => Array.Clear(array, 0, array.Length);
        public static void ZeroOut(this float[] array) => Array.Clear(array, 0, array.Length);

        public static void ZeroOut(this double[][] matrix)
        {
            foreach (double[] row in matrix)
                ZeroOut(row);
        }

        public static void ZeroOut(this float[][] matrix)
        {
            foreach (float[] row in matrix)
                ZeroOut(row);
        }

        public static void Initialize(this double[] array, double value)
        {
            for (var i = 0; i < array.Length; ++i)
                array[i] = value;
        }

        public static void Initialize(this float[] array, float value)
        {
            for (var i = 0; i < array.Length; ++i)
                array[i] = value;
        }

        public static int IndexOfLargest(this double[] array, int excludeTrailing = 0)
        {
            int indexOfLargest = 0;
            double maxVal = array[0];
            int count = array.Length - excludeTrailing;

            for (int i = 0; i < count; ++i)
            {
                if (!(array[i] > maxVal)) continue;

                maxVal = array[i];
                indexOfLargest = i;
            }

            return indexOfLargest;
        }

        public static int IndexOfLargest(this float[] array, int excludeTrailing = 0)
        {
            int indexOfLargest = 0;
            float maxVal = array[0];
            int count = array.Length - excludeTrailing;

            for (int i = 0; i < count; ++i)
            {
                if (!(array[i] > maxVal)) continue;

                maxVal = array[i];
                indexOfLargest = i;
            }

            return indexOfLargest;
        }

        public static double[][] MakeMatrix(int rows, int cols, double v = 0)
        {
            var result = new double[rows][];

            for (int r = 0; r < result.Length; ++r)
                result[r] = new double[cols];

            if (!(v < 0) && !(v > 0)) return result;

            for (int i = 0; i < rows; ++i)
                for (int j = 0; j < cols; ++j)
                    result[i][j] = v;

            return result;
        }

        public static float[][] MakeFloatMatrix(int rows, int cols, float v = 0)
        {
            var result = new float[rows][];

            for (int r = 0; r < result.Length; ++r)
                result[r] = new float[cols];

            if (!(v < 0) && !(v > 0)) return result;

            for (int i = 0; i < rows; ++i)
                for (int j = 0; j < cols; ++j)
                    result[i][j] = v;

            return result;
        }

        public static double[][] ToJagged(this double[,] matrix)
        {
            int rowCount = matrix.GetUpperBound(0) + 1;
            int colCount = matrix.GetUpperBound(1) + 1;
            var result = new double[rowCount][];

            for (int row = 0; row < rowCount; row++)
            {
                result[row] = new double[colCount];

                for (int col = 0; col < colCount; col++)
                    result[row][col] = matrix[row, col];
            }

            return result;
        }

        public static float[][] ToJagged(this float[,] matrix)
        {
            int rowCount = matrix.GetUpperBound(0) + 1;
            int colCount = matrix.GetUpperBound(1) + 1;
            var result = new float[rowCount][];

            for (int row = 0; row < rowCount; row++)
            {
                result[row] = new float[colCount];

                for (int col = 0; col < colCount; col++)
                    result[row][col] = matrix[row, col];
            }

            return result;
        }

        public static double[,] ToMultiDimension(this double[][] matrix)
        {
            int rowCount = matrix.Length;
            int colCount = matrix[0].Length;
            var result = new double[rowCount, colCount];

            for (int row = 0; row < rowCount; row++)
            {
                for (int col = 0; col < colCount; col++)
                    result[row, col] = matrix[row][col];
            }

            return result;
        }

        public static float[,] ToMultiDimension(this float[][] matrix)
        {
            int rowCount = matrix.Length;
            int colCount = matrix[0].Length;
            var result = new float[rowCount, colCount];

            for (int row = 0; row < rowCount; row++)
            {
                for (int col = 0; col < colCount; col++)
                    result[row, col] = matrix[row][col];
            }

            return result;
        }

        public static double[] ToArray(this double[,] matrix)
        {
            int rowCount = matrix.GetUpperBound(0) + 1;
            int colCount = matrix.GetUpperBound(1) + 1;
            var result = new double[rowCount * colCount];
            int index = 0;

            for (int row = 0; row < rowCount; row++)
            {
                for (int col = 0; col < colCount; col++)
                    result[index++] = matrix[row, col];
            }

            return result;
        }

        public static float[] ToArray(this float[,] matrix)
        {
            int rowCount = matrix.GetUpperBound(0) + 1;
            int colCount = matrix.GetUpperBound(1) + 1;
            var result = new float[rowCount * colCount];
            int index = 0;

            for (int row = 0; row < rowCount; row++)
            {
                for (int col = 0; col < colCount; col++)
                    result[index++] = matrix[row, col];
            }

            return result;
        }

        public static double[] ToArray(this double[][] matrix)
        {
            int rowCount = matrix.Length;
            int colCount = matrix[0].Length;
            var result = new double[rowCount * colCount];
            int index = 0;

            for (int row = 0; row < rowCount; row++)
            {
                for (int col = 0; col < colCount; col++)
                    result[index++] = matrix[row][col];
            }

            return result;
        }

        public static float[] ToArray(this float[][] matrix)
        {
            int rowCount = matrix.Length;
            int colCount = matrix[0].Length;
            var result = new float[rowCount * colCount];
            int index = 0;

            for (int row = 0; row < rowCount; row++)
            {
                for (int col = 0; col < colCount; col++)
                    result[index++] = matrix[row][col];
            }

            return result;
        }

        public static double[][] ToJagged(this double[] array, int rowCount, int colCount)
        {
            var result = new double[rowCount][];
            int index = 0;

            for (int row = 0; row < rowCount; row++)
            {
                result[row] = new double[colCount];

                for (int col = 0; col < colCount; col++)
                    result[row][col] = array[index++];
            }

            return result;
        }

        public static float[][] ToJagged(this float[] array, int rowCount, int colCount)
        {
            var result = new float[rowCount][];
            int index = 0;

            for (int row = 0; row < rowCount; row++)
            {
                result[row] = new float[colCount];

                for (int col = 0; col < colCount; col++)
                    result[row][col] = array[index++];
            }

            return result;
        }

        public static double[,] ToMultiDimension(this double[] array, int rowCount, int colCount)
        {
            var result = new double[rowCount, colCount];
            int index = 0;

            for (int row = 0; row < rowCount; row++)
            {
                for (int col = 0; col < colCount; col++)
                    result[row, col] = array[index++];
            }

            return result;
        }

        public static float[,] ToMultiDimension(this float[] array, int rowCount, int colCount)
        {
            var result = new float[rowCount, colCount];
            int index = 0;

            for (int row = 0; row < rowCount; row++)
            {
                for (int col = 0; col < colCount; col++)
                    result[row, col] = array[index++];
            }

            return result;
        }

        public static T[][] ToJagged<T>(this IList<IList<T>> lists)
        {
            var result = new T[lists.Count][];

            for (int i = 0; i < lists.Count; i++)
            {
                IList<T> list = lists[i];
                result[i] = new T[list.Count];

                for (int j = 0; j < list.Count; j++)
                {
                    result[i][j] = list[j];
                }
            }

            return result;
        }
    }
}
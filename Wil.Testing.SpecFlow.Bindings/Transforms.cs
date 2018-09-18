using System;
using System.Collections.Generic;
using TechTalk.SpecFlow;
using Wil.Core;

namespace Wil.Testing.SpecFlow.Bindings
{
    [Binding]
    public class Transforms
    {
        //[StepArgumentTransformation(@"(?i)(yes|no)")]
        //public bool Booleans(string value) => value.Equals("yes", StringComparison.OrdinalIgnoreCase);

        //[StepArgumentTransformation] public IEnumerable<string> Strings(string value) => value.ToStrings();
        //[StepArgumentTransformation] public string[] StringArray(string value) => value.ToStringsArray();
        //[StepArgumentTransformation] public List<string> StringList(string value) => value.ToStringsList();

        //[StepArgumentTransformation] public IEnumerable<char> Chars(string value) => value.ToChars();
        //[StepArgumentTransformation] public char[] CharArray(string value) => value.ToCharsArray();
        //[StepArgumentTransformation] public List<char> CharList(string value) => value.ToCharsList();

        //[StepArgumentTransformation] public IEnumerable<int> Ints(string value) => value.ToInts();
        [StepArgumentTransformation] public List<int> IntList(string value) => value.ToIntsList();
        //[StepArgumentTransformation] public int[] IntArray(string value) => value.ToIntsArray();

        //[StepArgumentTransformation] public IEnumerable<double> Doubles(string value) => value.ToDoubles();
        //[StepArgumentTransformation] public List<double> DoubleList(string value) => value.ToDoublesList();
        //[StepArgumentTransformation] public double[] DoubleArray(string value) => value.ToDoublesArray();

        //[StepArgumentTransformation] public IEnumerable<float> Floats(string value) => value.ToFloats();
        //[StepArgumentTransformation] public List<float> FloatList(string value) => value.ToFloatsList();
        //[StepArgumentTransformation] public float[] FloatArray(string value) => value.ToFloatsArray();

        //[StepArgumentTransformation] public IEnumerable<byte> Bytes(string value) => value.ToBytes();
        //[StepArgumentTransformation] public List<byte> ByteList(string value) => value.ToBytesList();
        //[StepArgumentTransformation] public byte[] ByteArray(string value) => value.ToBytesArray();

        //[StepArgumentTransformation] public IEnumerable<bool> Bools(string value) => value.ToBools();
        //[StepArgumentTransformation] public List<bool> BoolList(string value) => value.ToBoolsList();
        //[StepArgumentTransformation] public bool[] BoolArray(string value) => value.ToBoolsArray();

        //[StepArgumentTransformation]
        //public double[,] MultiDimensionDouble(string value) => value.ToMultiDimensionDouble();

        //[StepArgumentTransformation]
        //public float[,] MultiDimensionFloat(string value) => value.ToMultiDimensionFloat();

        //[StepArgumentTransformation] public double[][] JaggedDouble(string value) => value.ToJaggedDouble();
        //[StepArgumentTransformation] public float[][] JaggedFloat(string value) => value.ToJaggedFloat();
        [StepArgumentTransformation] public byte[][] JaggedByte(string value) => value.ToJaggedByte();
        //[StepArgumentTransformation] public char[][] JaggedChar(string value) => value.ToJaggedChar();
        //[StepArgumentTransformation] public bool[][] JaggedBool(string value) => value.ToJaggedBool();
    }
}

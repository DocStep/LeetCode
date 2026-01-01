public static class lib {

    public static void ArrayWrite<T> (T[] arr) {
        int length = arr.Length;
        for (int i = 0; i < length; i++) 
            Console.WriteLine(arr[i]);
    }

}

public class SubstringSearch {

    // Returns the last index j where p[j] != t[i+j], or -1
    static private int LastUnequalChar(string p, Func<int, char> t, int i)
    {
        for (int j = p.Length - 1; j >= 0; j--) {
            if (t(i+j) != p[j]) { return j; }
        }
        return -1;
    }

    // Returns the first index i where p == t[i..(i+p.Length)]
    // t is accessed via function rather than array
    static public int NotSoNaiveHeuristicSubstringSearch(string p, Func<int, char> t, int n, int l)
    {
        // Modify this function to use l-grams
        var pChars = new HashSet<char>(p);
        int i = 0;
        int s = 0;
        while (i <= n - p.Length) {
            int j = LastUnequalChar(p, t, i);
            if (j == -1) { return i; }    // equal!
            if (!pChars.Contains(t(i+j))) {
                s = j + 1;               // fast-forward
            } else {
                s = 1;
            }
            i += s;
        }
        return -1;
    }

    // Returns the optimal value of l for the given pattern length m
    static public int OptimalL(int m)
    {
        // Implement your solution here
        return 3;
    }

}


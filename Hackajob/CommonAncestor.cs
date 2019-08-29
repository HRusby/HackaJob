using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hackajob
{
    public class CommonAncestor
    {

    public static int Run(int index1, int index2)
    {
        // TODO: find common ancestors of each index
        // Compare Common Ancestors
        // Find Greatest Common Ancestor
        // Return
        List<int> Index1Ancestors = FindCommonAncestors(index1);
        List<int> Index2Ancestors = FindCommonAncestors(index2);
        List<int> commonAncestors = (Index1Ancestors.SelectMany(i => Index2Ancestors.Where(y => i == y).Select(y => i))).ToList();
        return commonAncestors.Max();
        //return 1;
    }

    private static List<int> FindCommonAncestors(int index)
    {
        if(index == 1)
        {
            return new List<int> { 1 };
        }
        List<int> CommonAncestors = new List<int>();
        int currentIndex = index;
        while (currentIndex > 1)
        {
            int parent = FindParent(currentIndex);
            CommonAncestors.Add(parent);
            currentIndex = parent;
        }
        return CommonAncestors;
    }

    private static int FindParent(int index)
    {
        // Nearest multiple of 2
        int nearestMultiple = (int)Math.Floor((double)index / 2) * 2;
        int depth = (int)Math.Log(nearestMultiple, 2.0); // As Binary Tree
        int startOfLine = (int)Math.Pow(2, depth);
        int positionInLine = index - startOfLine; // 0-Indexed
        if (positionInLine % 2 != 0)
        {
            positionInLine -= 1;
        } // Doesn't matter actual position finding the first child is more useful as is even
        int parentStartOfLine = (int)Math.Pow(2, depth - 1);
        int parentPositionInLine = positionInLine / 2; // 0-Indexed
        int parent = parentStartOfLine + parentPositionInLine;
        return parent;
    }
    }
}

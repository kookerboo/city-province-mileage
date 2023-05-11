using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace CityProvMileage.Extensions
{
  public static class IEnumerableExtensions
  {
    /// <summary>
    /// Enumerates with all possible combinations(ordering not important) from picking [k] items from this [source]
    /// </summary>
    /// <typeparam name="TSource"></typeparam>
    /// <param name="source">Enumeration of items to choose from</param>
    /// <param name="k">number of items each combination should contain</param>
    /// <returns></returns>
    public static IEnumerable<IEnumerable<TItem>> Combinate<TItem>(this IEnumerable<TItem> source, int k)
    {
      if (source == null)
        throw new ArgumentException("[source] cannot be NULL", "source");
      if (k < 1)
        throw new ArgumentException("[k] must be greater than or equal to 1", "k");
      if (k > source.Count())
        throw new ArgumentException("[k] cannot be larger than the number of items in [source]", "k");

      //if we only want the single combinations of a source, its the a list of each item
      if (k == 1)
      {
        foreach (TItem item in source)
          yield return new TItem[] { item };
      }

      //if we bigger combinations then we need to break down the list into smaller sets
      if (k > 1)
      {
        for (Int32 sourceIndex = 0; sourceIndex < source.Count() - 1; sourceIndex++)
        {
          TItem item = source.ElementAt(sourceIndex);
          IEnumerable<TItem> recurseSource = source.Skip(sourceIndex + 1);
          Int32 recurseK = k - 1;

          //make sure we aren't trying to pull more than what's in source
          if (recurseSource.Count() >= recurseK)
          {
            var subCombinations = recurseSource.Combinate(recurseK).ToList();
            foreach (var subCombination in subCombinations)
            {
              yield return subCombination.Prepend(item);
            }
          }
        }
      }

    }

    /// <summary>
    /// Projects each element from this [source] sequence and resulting sequences from the [selector] into one sequence.
    /// </summary>
    /// <typeparam name="TItem"></typeparam>
    /// <param name="source"></param>
    /// <param name="selector"></param>
    /// <returns></returns>
    public static IEnumerable<TItem> Compound<TItem>(this IEnumerable<TItem> source, Func<TItem, IEnumerable<TItem>> selector)
    {
      foreach (TItem item in source)
      {
        yield return item;

        IEnumerable<TItem> selectedItems = selector.Invoke(item);

        foreach (TItem selectedItem in selectedItems)
        {
          yield return selectedItem;
        }


      }

    }


    /// <summary>
    /// Returns the indexes of items in the source that meet the given predicate.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="source"></param>
    /// <param name="predicate"></param>
    /// <returns></returns>
    public static IEnumerable<Int32> IndexesOf<T>(this IEnumerable<T> source, Predicate<T> predicate)
    {
      for (Int32 index = 0; index < source.Count(); index++)
      {
        if (predicate.Invoke(source.ElementAt(index)))
          yield return index;
      }
    }


    /// <summary>
    /// Determines if each element in this [setA] is equal to an unique unordered element in [setB] and each element in [setB] is equal to an unique unordered element in this [setA].
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="setA"></param>
    /// <param name="setB"></param>
    /// <returns></returns>
    public static Boolean IsEqualSetOf<T>(this IEnumerable<T> setA, IEnumerable<T> setB)
    {
      //if both are don't exist then are equal to each other
      if ((setA == null) && (setB == null))
        return true;

      //if only one of the sets is null then there is a mismatch
      if ((setA == null) || (setB == null))
        return false;

      //equal sets must have the same cardinality
      if (setA.Count() != setB.Count())
        return false;

      //techically if both are subsets of each other then they are equalsets
      //but we already know they have the same cardinality so if one matches all elements the other has to match
      return IsSubSetOf(setA, setB);
    }

    /// <summary>
    /// Determines if each element in this [setA] is equal to an unique unordered element in [setB].
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="subSet"></param>
    /// <param name="parentSet"></param>
    /// <returns></returns>
    public static Boolean IsSubSetOf<T>(this IEnumerable<T> subSet, IEnumerable<T> parentSet)
    {
      //gather up all elements into lists so we don't modify the orginals
      List<T> subSetCopy = subSet.ToList();
      List<T> parentSetCopy = parentSet.ToList();

      //loop over the subset elements and try to find a match
      while (subSetCopy.Count > 0)
      {
        Boolean matchingElementFound = false;
        T elementA = subSetCopy[0];
        for (Int32 parentIndex = 0; parentIndex < parentSetCopy.Count && !matchingElementFound; parentIndex++)
        {
          T elementB = parentSetCopy[parentIndex];
          if (Object.Equals(elementA, elementB))
          {
            matchingElementFound = true;
            subSetCopy.RemoveAt(0);
            parentSetCopy.RemoveAt(parentIndex);
          }
        }
        if (!matchingElementFound)
          return false;
      }

      return true;
    }

    /// <summary>
    /// Sorts the IComparable elements of this [source] in ascending order using System.Collections.Generic.Comparer.Default
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="source"></param>
    /// <returns></returns>
    public static IOrderedEnumerable<T> OrderBy<T>(this IEnumerable<T> source) where T : IComparable<T>
    {
      return source.OrderBy(item => item, Comparer<T>.Default);
    }

    /// <summary>
    /// Sorts the IComparable elements of this [source] in descending order using System.Collections.Generic.Comparer.Default
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="source"></param>
    /// <returns></returns>
    public static IOrderedEnumerable<T> OrderByDescending<T>(this IEnumerable<T> source) where T : IComparable<T>
    {
      return source.OrderByDescending(item => item, Comparer<T>.Default);
    }

    /// <summary>
    /// Enumerates all possible permutations(ordering is important) of this [source]
    /// </summary>
    /// <typeparam name="TSource"></typeparam>
    /// <param name="source"></param>
    /// <returns></returns>
    public static IEnumerable<IEnumerable<TItem>> Permutate<TItem>(this IEnumerable<TItem> source)
    {
      if (source == null)
        throw new ArgumentException("[source] cannot be NULL", "source");


      if (source.Count() == 1)
      {
        yield return source;
      }

      if (source.Count() > 1)
        for (Int32 sourceIndex = 0; sourceIndex < source.Count(); sourceIndex++)
        {
          TItem item = source.ElementAt(sourceIndex);
          IEnumerable<TItem> recurseSource = source.Take(sourceIndex)
                                                  .Concat(
                                            source.Skip(sourceIndex + 1))
                                                  .ToList();

          var subCombinations = recurseSource.Permutate().ToList();
          foreach (var subCombination in subCombinations)
          {
            yield return subCombination.Prepend(item);
          }
        }

    }

    /// <summary>
    /// Generates an enumeration containing the [prependItem] at the begining and contents of this [source] following after
    /// </summary>
    /// <typeparam name="TSource"></typeparam>
    /// <param name="source"> enumeration of items to be added after the [item]</param>
    /// <param name="item"> item to be added before the [source]</param>
    /// <returns></returns>
    public static IEnumerable<TItem> Prepend<TItem>(this IEnumerable<TItem> source, TItem prependItem)
    {
      if (source == null)
        throw new ArgumentNullException("source");

      yield return prependItem;

      foreach (TItem item in source)
        yield return item;
    }

    /// <summary>
    /// Creates a new Arraylist for the this [source]
    /// </summary>
    /// <param name="source"></param>
    /// <returns></returns>
    public static System.Collections.ArrayList ToArrayList(this IEnumerable<Object> source)
    {
      return new System.Collections.ArrayList(source.ToArray());
    }

    /// <summary>
    /// Creates a new list of items of type TItem for this [source]
    /// </summary>
    /// <param name="source"></param>
    /// <returns></returns>
    public static List<TItem> ToList<TItem>(this IEnumerable source)
    {
      return source.OfType<TItem>().ToList();
    }


  }
  
}

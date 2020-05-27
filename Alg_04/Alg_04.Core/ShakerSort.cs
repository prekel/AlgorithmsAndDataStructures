using System;
using System.Collections.Generic;

namespace Alg_04.Core
{
    public class ShakerSort<T> : AbstractSort<T>
        where T : IComparable
    {
        public override void Sort(IList<T> list)
        {
            base.Sort(list);

            var left = 0;

            var right = list.Count - 1;
            var flag = 0;

            for (var i = 0; i < list.Count; i++)
            {
                flag = 0;
                if (i % 2 == 0)
                {
                    for (var j = right; j > left; j--)
                    {
                        if (Compare(list[j], list[j - 1]) < 0)
                        {
                            AssignmentCount += 2;
                            flag++;
                            var temp = list[j];
                            list[j] = list[j - 1];
                            list[j - 1] = temp;
                        }
                    }

                    left++;
                    if (flag == 0)
                    {
                        break;
                    }
                }
                else
                {
                    for (var j = left; j < right; j++)
                    {
                        if (Compare(list[j], list[j + 1]) > 0)
                        {
                            AssignmentCount += 2;
                            flag++;
                            var temp = list[j];
                            list[j] = list[j + 1];
                            list[j + 1] = temp;
                        }
                    }

                    right--;
                }

                if (flag == 0)
                {
                    break;
                }
            }
        }
    }
}

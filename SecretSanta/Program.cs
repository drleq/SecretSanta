using System;
using System.Linq;

namespace SecretSanta
{
    class Program
    {
        readonly struct Partners {
            public readonly string First;
            public readonly string Second;

            public Partners(string first, string second) {
                First = first;
                Second = second;
            }

            public bool IsInvalid(string name_a, string name_b) {
                if (First == name_a) {
                    return Second == name_b;
                }
                if (Second == name_a) {
                    return First == name_b;
                }
                return false;
            }
        }

        static readonly string[] Names = new[] {
            "Name1",
            "Name2",
            "Name3"
        };
        static readonly Partners[] InvalidPairs = new Partners[] {
            new Partners("Name1", "Name2")
        };


        static void Main() {
            var shuffled_indices = new int[Names.Length];
            for (int i = 0; i < shuffled_indices.Length; ++i) {
                shuffled_indices[i] = i;
            }

            var rand = new Random();
            while (!IsShuffledAndValid(shuffled_indices)) {
                int index = rand.Next(shuffled_indices.Length);
                int to_swap = rand.Next(shuffled_indices.Length);

                int tmp = shuffled_indices[index];
                shuffled_indices[index] = shuffled_indices[to_swap];
                shuffled_indices[to_swap] = tmp;
            }

            for (int i = 0; i < shuffled_indices.Length; ++i) {
                Console.WriteLine("{0} => {1}", Names[i], Names[shuffled_indices[i]]);
            }
        }

        static bool IsShuffledAndValid(int[] indices) {
            for (int i = 0; i < indices.Length; ++i) {
                if (indices[i] == i) {
                    return false;
                }

                var name_a = Names[i];
                var name_b = Names[indices[i]];
                if (InvalidPairs.Any(invalid_pair => invalid_pair.IsInvalid(name_a, name_b))) {
                    return false;
                }
            }

            return true;
        }
    }
}

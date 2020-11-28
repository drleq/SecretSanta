using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecretSanta
{
    class Program
    {
        static void Main(string[] args)
        {
            var Names = new string[] {
                "Name1",
				"Name2"
            };

            var shuffled_indices = new int[Names.Length];
            for (int i = 0; i < shuffled_indices.Length; ++i) {
                shuffled_indices[i] = i;
            }

            var rand = new Random();
            while (!IsShuffled(shuffled_indices)) {
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

        static bool IsShuffled(int[] indices) {
            for (int i = 0; i < indices.Length; ++i) {
                if (indices[i] == i) {
                    return false;
                }
            }

            return true;
        }
    }
}

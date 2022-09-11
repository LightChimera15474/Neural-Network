using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralNetwork
{
    class Program
    {
        static void Main(string[] args)
        {
            var topologe = new Topology(4, 1, 2);
            var neuralNetwork = new NeuralNetworks(topologe);
            neuralNetwork.Layers[1].Neurons[0].SetWeight(0.5, -0.1, 0.3, -0.1);
            neuralNetwork.Layers[1].Neurons[1].SetWeight(0.1, -0.3, 0.7, -0, 3);
            neuralNetwork.Layers[2].Neurons[0].SetWeight(1.2, 0, 8);

            var result = neuralNetwork.FeedForward(new List<double> { 1, 0, 0, 0 });
            Console.WriteLine(result);

            Console.ReadLine();
        }
    }
}

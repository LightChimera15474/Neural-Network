using System.Collections.Generic;

namespace NeuralNetwork
{
    public class Layer
    {
        public List<Neuron> Neurons { get; }
        public int Count => Neurons?.Count ?? 0;

        public Layer(List<Neuron> neurons, NeuronType neuronType = NeuronType.Normal)
        {
            if (neurons != null && neurons.Count > 0)
            {
                Neurons = neurons;
            }
        }

        public List<double> CollectAllSignals()
        {
            var result = new List<double>();
            foreach(var neuron in Neurons)
            {
                result.Add(neuron.Output);
            }
            return result;
        }

    }
}

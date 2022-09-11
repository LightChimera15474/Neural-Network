using System.Collections.Generic;

namespace NeuralNetwork
{
    public class Topology
    {
        public int InputCount { get; }
        public int OutputCount { get; }
        public List<int> HiddenLayers { get; }

        public Topology(int inputCount, int outputCount, params int[] hiddenLayers)
        {
            if (inputCount > 0 && outputCount > 0 && hiddenLayers != null && hiddenLayers.Length > 0)
            {
                InputCount = inputCount;
                OutputCount = outputCount;
                HiddenLayers = new List<int>();
                HiddenLayers.AddRange(hiddenLayers);
            }
        }
    }
}

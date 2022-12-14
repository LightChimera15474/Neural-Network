using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralNetwork
{
    public class NeuralNetworks
    {
        public List<Layer> Layers { get; }
        public Topology Topology { get; }

        public NeuralNetworks(Topology topology)
        {
            if (topology != null )
            {
                Topology = topology;
                Layers = new List<Layer>();

                CreateInputLayer();
                CreateHiddenLayers();
                CreateOutputLayer();
            }
        }
        
        public Neuron FeedForward(List<double> inputSignals)
        {
            SendSignalsToInputNeurons(inputSignals);
            FedForwardAllLayersAfterInput();

            if (Topology.OutputCount == 1)
            {
                return Layers.Last().Neurons[0];
            }
            else
            {
                return Layers.Last().Neurons.OrderByDescending(n => n.Output).First();
            }
        }

        private void FedForwardAllLayersAfterInput()
        {
            for (int i = 1; i < Layers.Count; i++)
            {
                var layer = Layers[i];
                var lastLayerSignals = Layers[i - 1].CollectAllSignals();
                foreach (var neuron in layer.Neurons)
                {
                    neuron.FeedForward(lastLayerSignals);
                }
            }
        }

        private void SendSignalsToInputNeurons(List<double> inputSignals)
        {
            if (inputSignals.Count == Topology.InputCount)
            {
                for (int i = 0; i < inputSignals.Count; i++)
                {
                    var signal = new List<double> { inputSignals[i] };
                    var neuron = Layers[0].Neurons[i];
                    neuron.FeedForward(signal);
                }
            }
        }

        private void CreateInputLayer()
        {
            var inputNeurons = new List<Neuron>();
            for (int i = 0; i < Topology.InputCount; i++)
            {
                var neuron = new Neuron(1, NeuronType.Input);
                inputNeurons.Add(neuron);
            }
            var inputLayer = new Layer(inputNeurons, NeuronType.Input);
            Layers.Add(inputLayer);
        }

        private void CreateHiddenLayers()
        {
            var hiddenNeurons = new List<Neuron>();
            var lastLayer = Layers.Last();
            for (int j = 0; j < Topology.HiddenLayers.Count; j++)
            {
                for (int i = 0; i < Topology.HiddenLayers[j]; i++)
                {
                    var neuron = new Neuron(lastLayer.Count);
                    hiddenNeurons.Add(neuron);
                }
                var hiddenLayer = new Layer(hiddenNeurons);
                Layers.Add(hiddenLayer);
            }
        }

        private void CreateOutputLayer()
        {
            var outputNeurons = new List<Neuron>();
            var lastLayer = Layers.Last();
            for (int i = 0; i < Topology.OutputCount; i++)
            {
                var neuron = new Neuron(lastLayer.Count, NeuronType.Output);
                outputNeurons.Add(neuron);
            }
            var outputLayer = new Layer(outputNeurons, NeuronType.Output);
            Layers.Add(outputLayer);
        }
    }
}

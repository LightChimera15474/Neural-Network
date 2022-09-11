using System;
using System.Collections.Generic;

namespace NeuralNetwork
{
    public class Neuron
    {
        public NeuronType NeuronType { get; }
        public List<double> Weights { get; }
        public double Output { get; private set; }

        public Neuron(int inputCount, NeuronType neuronType = NeuronType.Normal)
        {
            NeuronType = neuronType;
            Weights = new List<double>();

            for (int i = 0; i < inputCount; i++)
            {
                Weights.Add(1);
            }
        }

        public void SetWeight(params double[] weights)
        {
            for (int i = 0; i < weights.Length - 1; i++)
            {
                Weights[i] = weights[i];
            }
        }

        public double FeedForward(List<double> inputs)
        {
            if (inputs.Count == Weights.Count)
            {
                var sum = 0.0;
                for (int i = 0; i < inputs.Count; i++)
                {
                    sum += inputs[i] * Weights[i];
                }

                if (NeuronType != NeuronType.Input)
                {
                    Output = Sigmoid(sum);
                }
                else
                {
                    Output = sum;
                }
                return Output;
            }
            return double.NaN;
        }

        private double Sigmoid(double x)
        {
            return 1 / (1 + Math.Exp(-x));
        }

        public override string ToString()
        {
            return Output.ToString();
        }
    }
}

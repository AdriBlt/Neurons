// Copyright (c) Microsoft Corporation. All rights reserved.
namespace Neurons.Entities
{
    using System;
    using System.Collections.Generic;

    public class NeuralNetwork<T>
    {
        public readonly NeuralNetworkConfiguration Configuration = new NeuralNetworkConfiguration();

        private readonly NeuralNetworkGraph<T> _graph;

        private readonly NeuralNetworkModel _model;

        public NeuralNetwork(NeuralNetworkGraph<T> graph)
        {
            _graph = graph;
            _model = new NeuralNetworkModel();
        }

        public void InitializeTraining(Random random)
        {
            _model.NeuronComputations = new Dictionary<Neuron, NeuronComputation>();

            foreach (List<Neuron> hiddenLayer in _graph.HiddenLayers)
            {
                foreach (Neuron neuron in hiddenLayer)
                {
                    InitializeNeuronComputationValues(neuron, random);
                }
            }
            
            foreach (OutputNeuron<T> output in _graph.Outputs)
            {
                InitializeNeuronComputationValues(output, random);
            }
        }

        public void Train(List<TrainingData<T>> trainintData)
        {
            // TRAIN ON SMALL CHUNCKS
            // COMPUTE GRADIANT
            // APPLY GRADIANT
            throw new NotImplementedException();    
        }

        public T Evaluate(InputData input)
        {
            if (input?.Inputs == null
                || input.Inputs.Count != _graph.Inputs.Count)
            {
                throw new ArgumentException(nameof(input));
            }

            Dictionary<Neuron, float> neuronValues = new Dictionary<Neuron, float>();

            for (int i = 0; i < input.Inputs.Count; i++)
            {
                neuronValues.Add(_graph.Inputs[i], input.Inputs[i]);
            }
            
            foreach (List<Neuron> hiddenLayer in _graph.HiddenLayers)
            {
                foreach (Neuron neuron in hiddenLayer)
                {
                    ComputeValue(neuron, neuronValues);
                }
            }

            T bestOutput = default(T);
            float bestFitness = float.NegativeInfinity;
            foreach (OutputNeuron<T> output in _graph.Outputs)
            {
                float value = ComputeValue(output, neuronValues);
                if (value > bestFitness)
                {
                    bestFitness = value;
                    bestOutput = output.Value;
                }
            }

            return bestOutput;
        }

        private void InitializeNeuronComputationValues(Neuron neuron, Random random)
        {
            NeuronComputation computation = new NeuronComputation
                {
                    NeuronWeights = new Dictionary<Neuron, float>(),
                    Bias = Configuration.GenerateParameter(),
            };

            foreach (Neuron ancestor in neuron.Ancestors)
            {
                computation.NeuronWeights[ancestor] = Configuration.GenerateParameter();
            }
        }
        
        private float ComputeValue(Neuron neuron, Dictionary<Neuron, float> ancestorsValues)
        {
            NeuronComputation function = _model.NeuronComputations[neuron];
            float value = function.Bias;
            foreach (KeyValuePair<Neuron, float> pair in function.NeuronWeights)
            {
                value += pair.Value * ancestorsValues[pair.Key];
            }

            return ancestorsValues[neuron] = Configuration.Project(value);
        }
    }
}

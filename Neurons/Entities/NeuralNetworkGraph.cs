// Copyright (c) Microsoft Corporation. All rights reserved.
namespace Neurons.Entities
{
    using System.Collections.Generic;

    public class NeuralNetworkGraph<T>
    {
        public List<Neuron> Inputs;

        public List<List<Neuron>> HiddenLayers;

        public List<OutputNeuron<T>> Outputs;

        public NeuralNetworkGraph(
            int inputSize,
            List<T> outputs)
        {
            Inputs = new List<Neuron>(inputSize);
            for (int i = 0; i < inputSize; i++)
            {
                Inputs.Add(new InputNeuron());
            }

            Outputs = new List<OutputNeuron<T>>(outputs.Count);
            foreach (T output in outputs)
            {
                Outputs.Add(new OutputNeuron<T> { Value = output });
            }
        }

        public void SetHiddenLayersConfiguration(List<int> hiddenLayersSizes) {
            HiddenLayers = new List<List<Neuron>>(hiddenLayersSizes.Count);

            List<Neuron> previousLayer = Inputs;

            foreach (int layersSize in hiddenLayersSizes)
            {
                List<Neuron> layer = new List<Neuron>(layersSize);
                for (int i = 0; i < layersSize; i++)
                {
                    layer.Add(new Neuron { Ancestors = previousLayer });
                }

                HiddenLayers.Add(layer);
                previousLayer = layer;
            }

            foreach (OutputNeuron<T> outputNeuron in Outputs)
            {
                outputNeuron.Ancestors = previousLayer;
            }
        }
    }
}

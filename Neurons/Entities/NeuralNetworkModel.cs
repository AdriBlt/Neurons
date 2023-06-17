// Copyright (c) Microsoft Corporation. All rights reserved.
namespace Neurons.Entities
{
    using System.Collections.Generic;

    public class NeuralNetworkModel
    {
        public Dictionary<Neuron, NeuronComputation> NeuronComputations;
    }
}

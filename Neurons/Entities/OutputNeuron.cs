// Copyright (c) Microsoft Corporation. All rights reserved.
namespace Neurons.Entities
{
    public class OutputNeuron<T> : Neuron
    {
        public T Value { get; set; }
    }
}

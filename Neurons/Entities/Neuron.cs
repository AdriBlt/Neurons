// Copyright (c) Microsoft Corporation. All rights reserved.
namespace Neurons.Entities
{
    using System.Collections.Generic;

    public class Neuron
    {
        public List<Neuron> Ancestors { get; set; }
    }
}

// Copyright (c) Microsoft Corporation. All rights reserved.
namespace Neurons.Entities
{
    using System;

    public class NeuralNetworkConfiguration
    {
        public float MinValue = -1;

        public float MaxValue = 1;

        public int TrainingBatchesSize = 100;

        public Random Random = new Random();

        public float GenerateParameter()
        {
            return (float)((MaxValue - MinValue) * Random.NextDouble() - MinValue);
        }

        public float Project(float value)
        {
            if (value < MinValue)
            {
                return MinValue;
            }

            if (value > MaxValue)
            {
                return MaxValue;
            }

            return value;
        }
    }
}

// Copyright (c) Microsoft Corporation. All rights reserved.
namespace Neurons.Entities
{
    public class TrainingData<T> : InputData 
    {
        public T ExpectedResult { get; set; }
    }
}

using Alea.CUDA;
using Alea.CUDA.IL;
using Alea.CUDA.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPUAleaTest
{
    class Program
    {
        static void Main(string[] args)
        {
            SquareTest();
            Console.ReadKey();

        }

        static void SquareCPU(double[] inputs)
        {
            var outputs = new double[inputs.Length];
            for (var i = 0; i < inputs.Length; i++)
            {
                outputs[i] = inputs[i] * inputs[i];
            }
        }

        [AOTCompile]
        static void SquareKernel(deviceptr<double> outputs, deviceptr<double> inputs, int n)
        {
            var start = blockIdx.x * blockDim.x + threadIdx.x;
            var stride = gridDim.x * blockDim.x;
            for (var i = start; i < n; i += stride)
            {
                outputs[i] = inputs[i];
            }
        }

        static double[] SquareGPU(double[] inputs)
        {
            var worker = Worker.Default;
            using (var dInputs = worker.Malloc(inputs))
            using (var dOutputs = worker.Malloc<double>(inputs.Length))
            {
                const int blockSize = 256;
                var numSm = worker.Device.Attributes.MULTIPROCESSOR_COUNT;
                var gridSize = Math.Min(16 * numSm, Common.divup(inputs.Length, blockSize));
                var lp = new LaunchParam(gridSize, blockSize);
                worker.Launch(SquareKernel, lp, dOutputs.Ptr, dInputs.Ptr, inputs.Length);
                return dOutputs.Gather();
            }
        }

        //static double[] SquareGPU(double[] inputs)
        //{
        //    var worker = Worker.Default;
        //    double[] firstHalf = new double[inputs.Length/2];
        //    double[] secondHalf = new double[inputs.Length / 2];
        //    double[] firstOutput;
        //    double[] secondOutput;
        //    double[] totalOutput = new double[inputs.Length];

        //    for (int i = 0; i < inputs.Length; i++)
        //    {
        //        if (i < inputs.Length / 2)
        //            firstHalf[i] = inputs[i];
        //        else
        //            secondHalf[i - firstHalf.Length] = inputs[i];
        //    }

        //    //Allocate amount of addresses needed for the input.
        //    using (var dFirstInputs = worker.Malloc(firstHalf))
        //    using (var dSecondInputs = worker.Malloc(secondHalf))
        //    //Allocate amount of addresses needed for the output.
        //    using (var dOutputs = worker.Malloc<double>(firstHalf.Length + secondHalf.Length))
        //    {
        //        const int blockSize = 256;
        //        //Gets the count of multiprocessors of the graphic card.
        //        var numSm = worker.Device.Attributes.MULTIPROCESSOR_COUNT;

        //        var gridSize = Math.Min(16 * numSm, Common.divup(inputs.Length, blockSize));
        //        var lp = new LaunchParam(gridSize, blockSize);
        //        worker.Launch(SquareKernel, lp, dOutputs.Ptr, dFirstInputs.Ptr, firstHalf.Length);
        //        firstOutput = dOutputs.Gather();
        //        worker.Launch(SquareKernel, lp, dOutputs.Ptr, dSecondInputs.Ptr, secondHalf.Length);
        //        secondOutput = dOutputs.Gather();

        //        for(int i = 0; i < dOutputs.Length; i++)
        //        {
        //            if (i < dOutputs.Length / 2)
        //                totalOutput[i] = firstOutput[i];
        //            else
        //                totalOutput[i] = secondOutput[i - firstOutput.Length/2];
        //        }


        //        return totalOutput;
        //    }
        //}

        public static void SquareTest()
        {
            var inputs = Enumerable.Range(0, 1000000).Select(i => 0 + i * .1).ToArray();
            var outputs = SquareGPU(inputs);
        }

    }
}

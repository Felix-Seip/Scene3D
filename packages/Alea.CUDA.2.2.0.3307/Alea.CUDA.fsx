#I __SOURCE_DIRECTORY__
#r "lib/net40/Alea.CUDA.dll"
#r "System.Configuration"
open System.IO
Alea.CUDA.Settings.Instance.Resource.AssemblyPath <- Path.Combine(__SOURCE_DIRECTORY__, "private")
Alea.CUDA.Settings.Instance.Resource.Path <- Path.GetTempPath()

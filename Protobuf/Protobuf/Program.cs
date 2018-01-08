using Protobuf.Object;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Protobuf
{
    static class Program
    {
        static void Main(string[] args)
        {
            var stopWatch = Stopwatch.StartNew();

            for (int i = 0; i < 5000000; i++)
            {
                var obj = CreateCliente(i);
                Newtonsoft.Json.JsonConvert.SerializeObject(obj);
            }

            stopWatch.Stop();

            TimeSpan ts = stopWatch.Elapsed;

            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}", ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds / 10);

            Console.WriteLine("RunTime Json " + elapsedTime);

            var stopProto = Stopwatch.StartNew();

            for (int i = 0; i < 5000000; i++)
            {
                var obj = CreateCliente(i);
                Protobuf.Serializer.ProtoSerialize.Serialize<Cliente>(obj);
            }

            stopProto.Stop();

            TimeSpan tsProto = stopProto.Elapsed;

            string elapsedTimeProto = String.Format("{0:00}:{1:00}:{2:00}.{3:00}", tsProto.Hours, tsProto.Minutes, tsProto.Seconds, tsProto.Milliseconds / 10);

            Console.WriteLine("RunTime Proto " + elapsedTimeProto);

            Console.Read();
        }

        private static Cliente CreateCliente(int i)
        {
            return new Object.Cliente()
            {
                DataNascimento = DateTime.Now,
                PrimeroNome = $"Cliente{i}",
                UltimoNome = $"UltimoNome{i}",
                Enderecos = new List<Endereco>()
                {
                    new Object.Endereco()
                    {
                        Bairro = $"Bairro{i}",
                        Cidade = $"Cidade{i}",
                        Complemento = $"Complemento{i}",
                        Logradouro = $"Logradouro{i}",
                        Pais = $"Pais{i}"
                    }
                }

            }; 
        }
    }
}

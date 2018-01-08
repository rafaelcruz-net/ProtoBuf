using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Protobuf.Object
{
    [ProtoContract()]
    public class Cliente
    {
        [ProtoMember(1)]
        public string PrimeroNome { get; set; }

        [ProtoMember(2)]
        public string UltimoNome { get; set; }

        [ProtoMember(3)]
        public DateTime DataNascimento { get; set; }

        [ProtoMember(4)]
        public List<Endereco> Enderecos { get; set; }
    }

    [ProtoContract()]
    public class Endereco
    {
        [ProtoMember(1)]
        public string Logradouro { get; set; }

        [ProtoMember(2)]
        public string Complemento { get; set; }

        [ProtoMember(3)]
        public string Bairro { get; set; }

        [ProtoMember(4)]
        public string Cidade { get; set; }

        [ProtoMember(5)]
        public string Pais { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace UeharaApi_91Tel.Models
{
    public class LogResponse
    {
        [JsonIgnore]
        public int Id { get; set;   }

        public int? LogSistemaId { get; set; }
        public DateTime Data { get; set; }
        public string Origem { get; set; }
        public string Contexto { get; set; }
        public string Severidade { get; set; }
        public string Mensagem { get; set; }
        public string ArquivoFonte { get; set; }
        public string MetodoFonte { get; set; }
        public string Maquina { get; set; }
        public int? LinhaFonte { get; set; }
        public string Propriedades { get; set; }
        public string Excecao { get; set; }
        public int? OrigemId { get; set; }
        public int? LogContextoId { get; set; }
        public int? UsuarioId { get; set; }
        public string NomeUsuario { get; set; }
    };
}

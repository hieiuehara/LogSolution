export class Log{
    position: number
    firstName: string
    lastName: string
    email: string
  }

  export class LogRespondeModel {
    public logSistemaId     :   string;
    public data             :   Date;
    public origem           :   string;
    public contexto         :   number;
    public severidade       :   string;
    public mensagem         :   string;
    public arquivoFonte     :   string;
    public metodoFonte      :   string;
    public maquina          :   string;
    public linhaFonte       :   number;
    public propriedades     :   string;
    public excecao          :   string;
    public origemiD         :   number;
    public logContextoiD    :   number;
    public usuarioiD        :   number;
    public nomeUsuario      :   string;
    }

export interface Produto {
  nome: string;
  DataPublicacao: Date;
  valor: number;
  cidade: string;
  categoria: string;
  modelo: string;
  condicao: string;
  quantidade: string;
}

export interface Servico {
  nome: string;
  DataPublicacao: Date;
  valor: number;
  cidade: string;
}

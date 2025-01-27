import React from "react";
import { Link } from "react-router-dom";
import "./Card.css";
import { Produto, Servico } from "../../Models/Ad";

interface Props {
  id: string;
  searchResult: Produto | Servico;
}

const Card: React.FC<Props> = ({ id, searchResult }: Props): JSX.Element => {
  // Verifica se é um Produto ou Serviço com base na propriedade 'categoria'
  const isProduto = (result: Produto | Servico): result is Produto => {
    return (result as Produto).categoria !== undefined;
  };

  return (
    <div
      className="flex flex-col items-center justify-between w-full p-6 bg-slate-100 rounded-lg md:flex-row"
      key={id}
      id={id}
    >
      {isProduto(searchResult) ? (
        // Caso seja Produto
        <div className="font-bold text-center text-veryDarkViolet md:text-left"
        >
          {/* Exibe as informações específicas de Produto */}
          {searchResult.nome} - R$ {searchResult.valor.toFixed(2)} <br />
          Cidade: {searchResult.cidade} <br />
          Categoria: {searchResult.categoria} <br />
          Condição: {searchResult.condicao} <br />
          Quantidade: {searchResult.quantidade}
        </div>
      ) : (
        // Caso seja Serviço
        <div className="font-bold text-center text-veryDarkViolet md:text-left" >
          {searchResult.nome} - R$ {searchResult.valor.toFixed(2)} <br />
          Cidade: {searchResult.cidade}
        </div>
      )}
    </div>
  );
};

export default Card;
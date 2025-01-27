import React, { useState, ChangeEvent, SyntheticEvent, useEffect } from "react";
import { getProdutos, getServicos } from "../../api"; // Importando as funções de produto e serviço
import CardList from "../../Components/CardList/CardList"; // Suponho que o componente CardList já sirva para exibir tanto produtos quanto serviços
import { Produto, Servico } from "../../Models/Ad"; // Certifique-se de que estas interfaces estão corretas

interface Props {}

const SearchPage = (props: Props) => {
  const [searchResult, setSearchResult] = useState<(Produto | Servico)[]>([]); // Resultados de busca, agora incluindo produtos e serviços
  const [serverError, setServerError] = useState<string | null>(null); // Erros de conexão com a API

  useEffect(() => {
    const fetchAll = async () => {
      try {
        const produtos = (await getProdutos()) || []; // Garante que seja um array
        const servicos = (await getServicos()) || []; // Garante que seja um array
        setSearchResult([...produtos, ...servicos]); // Coloca ambos na lista inicial
      } catch (error) {
        setServerError("Erro ao carregar produtos e serviços.");
      }
    };
    fetchAll();
  }, []);

  return (
    <>

      <CardList
        searchResults={searchResult}
      />

      {serverError && <div>{serverError}</div>} {/* Exibe erro caso haja */}
    </>
  );
};

export default SearchPage;
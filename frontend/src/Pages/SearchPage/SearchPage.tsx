import React, { useState, ChangeEvent, SyntheticEvent, useEffect } from "react";
import { getProdutos, getServicos } from "../../api";
import CardList from "../../Components/CardList/CardList";
import { Produto, Servico } from "../../Models/Ad";

interface Props {}

const SearchPage = (props: Props) => {
  const [searchResult, setSearchResult] = useState<(Produto | Servico)[]>([]);
  const [serverError, setServerError] = useState<string | null>(null);

  useEffect(() => {
    const fetchAll = async () => {
      try {
        const produtos = (await getProdutos()) || [];
        const servicos = (await getServicos()) || [];
        setSearchResult([...produtos, ...servicos]);
      } catch (error) {
        setServerError("Erro ao carregar produtos e serviços.");
      }
    };
    fetchAll();
  }, []);

  return (
    <>
      <CardList searchResults={searchResult} />

      {serverError && <div>{serverError}</div>}
    </>
  );
};

export default SearchPage;


import React, { SyntheticEvent } from "react";
import Card from "../Card/Card";
import { Produto, Servico } from "../../Models/Ad";
import { v4 as uuidv4 } from "uuid";

interface Props {
  searchResults: (Produto | Servico)[];
}

const CardList: React.FC<Props> = ({
  searchResults,
}: Props): JSX.Element => {
  return (
    <div>
      {searchResults.length > 0 ? (
        searchResults.map((result) => {
          return (
            <Card
              id={uuidv4()}
              key={uuidv4()}
              searchResult={result} 
            />
          );
        })
      ) : (
        <p className="mb-3 mt-3 text-xl font-semibold text-center md:text-xl">
          No results!
        </p>
      )}
    </div>
  );
};

export default CardList;
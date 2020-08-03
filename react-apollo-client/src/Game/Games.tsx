import React from "react";
import { gql, useQuery } from "@apollo/client";
import Game from "./Game";
import { GameModel } from "./game.model";

const GAMES_QUERY = gql`
  query {
    games {
      id
      name
      price
      stock
      reviews {
        id
        review
        title
      }
    }
  }
`;

const Games: React.FC<any> = () => {
  const { loading, data, error } = useQuery(GAMES_QUERY);

  if (loading) return <p>loading...</p>;

  if (error) return <pre>{JSON.stringify(error)}</pre>;

  return (
    <div style={{ margin: "1rem" }}>
      <h1>Store</h1>
      {data.games.map((game: GameModel) => (
        <div key={game.id}>
          <Game game={game} />
        </div>
      ))}
    </div>
  );
};

export default Games;

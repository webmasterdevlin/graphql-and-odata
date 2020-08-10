import { gql } from "@apollo/client";

export const GAMES_QUERY = gql`
  query {
    games {
      id
      name
      price
      stock
      rating
      reviews {
        id
        review
        title
      }
    }
  }
`;

export const GAME_QUERY = gql`
  query gameQuery($gameId: ID!) {
    game(id: $gameId) {
      id
      name
      rating
      price
      stock
      developedBy {
        name
      }
      publishedBy {
        name
      }
      genre {
        type
      }
      reviews {
        title
        review
      }
    }
  }
`;

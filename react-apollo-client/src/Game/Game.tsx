import React from "react";
import { gql, useMutation } from "@apollo/client";
import { GameModel } from "../GraphQL/GamesType";

const CREATE_REVIEW = gql`
  mutation createReview($review: reviewInput!) {
    createReview(review: $review) {
      review
    }
  }
`;

type Props = {
  game: GameModel;
};

const Game: React.FC<Props> = ({ game }) => {
  const [mutate, { data, error }] = useMutation(CREATE_REVIEW);

  const handleOnSubmit = () => {
    mutate({
      variables: {
        review: {
          title: "Batman fan here!",
          review: "I never get tired of playing this.",
          gameId: 1,
        },
      },
    });
  };

  return (
    <div style={{ display: "flex", justifyContent: "space-between" }}>
      <div>
        <div>{game.name}</div>
        <ol>
          {game.reviews.map((r) => (
            <li>
              <div>title: {r.title}</div>
              <div>review: {r.review.slice(0, 56)}... continue</div>
            </li>
          ))}
        </ol>
        <hr />
      </div>
    </div>
  );
};

export default Game;

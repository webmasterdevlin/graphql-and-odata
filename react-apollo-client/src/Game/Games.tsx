import React from "react";
import { gql, useQuery } from "@apollo/client";
import { GameModel, GamesType } from "../GraphQL/GamesType";
import {
  Badge,
  Box,
  Button,
  Paper,
  Tooltip,
  Typography,
} from "@material-ui/core";
import RateReviewIcon from "@material-ui/icons/RateReview";
import { useNavigate } from "react-router-dom";

const GAMES_QUERY = gql`
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

const Games: React.FC<any> = () => {
  const { loading, data, error } = useQuery<GamesType>(GAMES_QUERY);

  const navigate = useNavigate();

  if (loading) return <p>loading...</p>;
  if (error) return <pre>{JSON.stringify(error)}</pre>;

  return (
    <div style={{ margin: "1rem" }}>
      <h1>Games</h1>
      {data?.games.map((game: GameModel) => (
        <Box mb={4} key={game.id}>
          <Paper key={game.id}>
            <Box mx={3} py={3}>
              <Typography
                onClick={() => alert("Hello")}
                gutterBottom
                variant="h5"
                component="h2"
              >
                {game.name}
              </Typography>

              <Typography>Price: $ {game.price}</Typography>
              <Typography>Rating: ⭐{game.rating}</Typography>
              <Box my={2}>
                Reviews:{" "}
                <Badge badgeContent={game.reviews.length} color="primary">
                  <RateReviewIcon />
                </Badge>
              </Box>
              <Button
                onClick={() => navigate("game-details/" + game.id)}
                color={"primary"}
              >
                See Details
              </Button>
            </Box>
          </Paper>
        </Box>
      ))}
    </div>
  );
};

export default Games;

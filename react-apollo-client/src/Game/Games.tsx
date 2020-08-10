import React from "react";
import { useQuery } from "@apollo/client";
import { GamesType } from "./type-responses/game.type";
import { useNavigate } from "react-router-dom";
import { GameModel } from "./models/game.model";
import RateReviewIcon from "@material-ui/icons/RateReview";
import { GAMES_QUERY } from "../graphql-requests/queries";
import {
  Badge,
  Box,
  Button,
  Container,
  Paper,
  Typography,
} from "@material-ui/core";

const Games: React.FC<any> = () => {
  const { loading, data, error } = useQuery<GamesType>(GAMES_QUERY);

  const navigate = useNavigate();

  if (loading) return <Container>Loading...</Container>;
  if (error) return <Container>{JSON.stringify(error)}</Container>;

  return (
    <Container>
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
    </Container>
  );
};

export default Games;

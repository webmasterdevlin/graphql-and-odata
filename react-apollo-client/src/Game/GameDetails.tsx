import React from "react";
import { useParams } from "react-router";
import { useQuery } from "@apollo/client";
import { GameType } from "./type-responses/game.type";
import ReviewForm from "../components/review-form";
import { useStyles } from "./game.material.style";

import Card from "@material-ui/core/Card";
import CardActionArea from "@material-ui/core/CardActionArea";
import CardActions from "@material-ui/core/CardActions";
import CardContent from "@material-ui/core/CardContent";
import CardMedia from "@material-ui/core/CardMedia";
import Typography from "@material-ui/core/Typography";
import ExpandMoreIcon from "@material-ui/icons/ExpandMore";
import {
  Accordion,
  AccordionDetails,
  AccordionSummary,
  Box,
  Container,
} from "@material-ui/core";
import { GAME_QUERY } from "../graphql-requests/queries";

const GameDetails: React.FC<any> = (props) => {
  const classes = useStyles();

  const { id } = useParams();

  const { loading, data, error } = useQuery<GameType>(GAME_QUERY, {
    variables: { gameId: id },
    // pollInterval: 500,
  });

  if (loading) return <Container>Loading..</Container>;
  if (error) return <Container>{error.message}</Container>;

  return (
    <Container maxWidth={"sm"}>
      <Card className={classes.root}>
        <CardActionArea>
          <CardMedia
            className={classes.media}
            image="https://picsum.photos/200/300"
          />
          <CardContent>
            <Typography gutterBottom variant="h5" component="h2">
              🎮 {data?.game.name}
            </Typography>
            <Box mb={1}>
              <Typography variant="body1" color="textSecondary" component="p">
                Developed By:{" "}
                {data?.game.developedBy.map((d) => (
                  <span>{d.name}, </span>
                ))}
              </Typography>
              <Typography variant="body1" color="textSecondary" component="p">
                Published By:{" "}
                {data?.game.publishedBy.map((p) => (
                  <span>{p.name}, </span>
                ))}
              </Typography>
              <Typography variant="body1" color="textSecondary" component="p">
                Genre(s):{" "}
                {data?.game.genre.map((g) => (
                  <span>{g.type}, </span>
                ))}
              </Typography>
            </Box>
            <Typography>Stock: 💿 {data?.game.stock}</Typography>
          </CardContent>
        </CardActionArea>
        <Box display={"flex"} justifyContent={"center"}>
          <CardActions>Reviews</CardActions>
        </Box>
      </Card>
      {data?.game.reviews.map((review) => (
        <>
          <Accordion>
            <AccordionSummary
              expandIcon={<ExpandMoreIcon />}
              aria-controls="panel1a-content"
              id="panel1a-header"
            >
              <Box fontWeight={"700"}>{review.title}</Box>
            </AccordionSummary>
            <AccordionDetails>
              <Typography>{review.review}</Typography>
            </AccordionDetails>
          </Accordion>
        </>
      ))}
      <ReviewForm id={id} />
    </Container>
  );
};

export default GameDetails;

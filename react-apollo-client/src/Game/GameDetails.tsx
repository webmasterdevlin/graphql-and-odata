import React from "react";
import { useParams } from "react-router";
import { gql, useQuery } from "@apollo/client";
import { GameType } from "../GraphQL/GamesType";
import {
  Accordion,
  AccordionDetails,
  AccordionSummary,
  Box,
  Container,
} from "@material-ui/core";
import { Theme, createStyles, makeStyles } from "@material-ui/core/styles";
import Card from "@material-ui/core/Card";
import CardActionArea from "@material-ui/core/CardActionArea";
import CardActions from "@material-ui/core/CardActions";
import CardContent from "@material-ui/core/CardContent";
import CardMedia from "@material-ui/core/CardMedia";
import Button from "@material-ui/core/Button";
import Typography from "@material-ui/core/Typography";
import ExpandMoreIcon from "@material-ui/icons/ExpandMore";
import ReviewForm from "../components/review-form";

const useStyles = makeStyles((theme: Theme) =>
  createStyles({
    root: {
      maxWidth: 690,
    },
    media: {
      height: 280,
    },
    heading: {
      fontSize: theme.typography.pxToRem(15),
      fontWeight: theme.typography.fontWeightRegular,
    },
  })
);

const GAME_QUERY = gql`
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

const GameDetails: React.FC<any> = (props) => {
  const classes = useStyles();

  const { id } = useParams();

  const { loading, data, error } = useQuery<GameType>(GAME_QUERY, {
    variables: { gameId: id },
    // pollInterval: 500,
  });

  if (loading) return <h2>Loading...</h2>;
  if (error) return <h2>{error.message}</h2>;

  return (
    <Container maxWidth={"md"}>
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

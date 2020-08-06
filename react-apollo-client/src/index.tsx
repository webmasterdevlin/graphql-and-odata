import React from "react";
import ReactDOM from "react-dom";
import CssBaseline from "@material-ui/core/CssBaseline";
import App from "./App";
import * as serviceWorker from "./serviceWorker";

import { ApolloClient, ApolloProvider, gql } from "@apollo/client";
import { cache } from "./graphql-cache";

const client = new ApolloClient({
  cache: cache,
  uri: "http://localhost:5000/graphql",
  resolvers: {},
});

client
  .query({
    query: gql`
      {
        games {
          id
          name
          price
          reviews {
            title
          }
        }
      }
    `,
  })
  .then((res) => console.log(res));

ReactDOM.render(
  <React.StrictMode>
    <CssBaseline>
      <ApolloProvider client={client}>
        <App />
      </ApolloProvider>
    </CssBaseline>
  </React.StrictMode>,
  document.getElementById("root")
);

// If you want your app to work offline and load faster, you can change
// unregister() to register() below. Note this comes with some pitfalls.
// Learn more about service workers: https://bit.ly/CRA-PWA
serviceWorker.unregister();

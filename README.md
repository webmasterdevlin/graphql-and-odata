#### Dockerizing a ASP.NET GraphQL

Login to Docker Hub

```zsh
$ docker login
```

create an ASP.NET Web API container

```zsh
$ docker build -t {yourDockerUsername}/asp-api:1.0.0 .
```

Test the ASP.NET Web API container by running it. It should be visible at localhost:8080

```zsh
$ docker run -p 8080:80 {yourDockerUsername}/asp-api:1.0.0
```

Push the container to your Docker Hub account repository

```zsh
$ docker push {yourDockerUsername}/asp-api:1.0.0
```

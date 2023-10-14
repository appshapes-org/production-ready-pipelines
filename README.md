# What is this for?

This repository contains production-ready pipeline implementations for GitHub, GitLab, Harness, and Jenkins.

# Who is this for?

Developers, platform engineers, and others may use this repository setting up and/or improving pipelines.

# What is here?

## Docker Compose

`docker-compose.yml` defines GitLab, Jenkins, and Harness services.

# What are the dependencies?

- Docker

# How do I run GitLab?

## Start GitLab

```shell
~/projects/pipelines # docker compose up -d gitlab
```

Wait approximately 5 minutes for GitLab complete its initialization before proceding.

## Configure GitLab

- Log in to [GitLab Home](http://localhost/admin/runners) (Password: `5x3(^[!X<Iq'l0M2`)
- Open [Admin Area > Runners](http://localhost/admin/runners)
- Click [Create a new runner](http://localhost/admin/runners/new)
- Select "Run untagged jobs"
- Click "Create runner"
- On "Register runner" page, save the registration token somewhere safe.
- Copy the "Step 1" command
- Start your runner container:

```shell
~/projects/pipelines # docker compose up -d gitlab-runner
```

- Shell into GitLab container:

```shell
~/projects/pipelines # docker exec -it production-ready-pipelines-gitlab-runner sh
```

- Register the runner:

```shell
# gitlab-runner register --url http://gitlab --token glrt-Moz88ZNxwnMeMVyjqByB
```

- Hit enter to accept default URL
- Hit enter to accept default name
- Enter `docker`
- Enter `alpine:latest`
- Enter `exit` to exit your runner container

## Start GitLab

```shell
~/projects/pipelines # docker compose up -d gitlab-runner
```
